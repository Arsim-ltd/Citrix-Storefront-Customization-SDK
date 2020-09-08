/*************************************************************************
*
* Copyright (c) 2013-2015 Citrix Systems, Inc. All Rights Reserved.
* You may only reproduce, distribute, perform, display, or prepare derivative works of this file pursuant to a valid license from Citrix.
*
* THIS SAMPLE CODE IS PROVIDED BY CITRIX "AS IS" AND ANY EXPRESS OR IMPLIED
* WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
* MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
*
*************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using Examples.Helpers;

namespace StoreCustomization_Launch
{
    /// <summary>
    /// Example launch result modifier which does simple translationString for NAT firewalls.
    /// The translations are specified in the AppSettings section of the Store web.config file 
    /// <code>
    ///     <appSettings>
    ///        ...
    ///       <add key="addressTranslations" value="fromaddress1 = toaddress1; fromaddress2 = toaddress2;...."/>
    ///        ...
    ///     </appSettings>
    /// </code>
    /// The address values must contain a host (as IP address or DNS name) and port in the form host:port. 
    /// This example could be made more sophisticated by allowing wildcards for host or port, currently it needs every host and port combination to be 
    /// specified explicitly.
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class LaunchResultModifier_Example_NatTranslation : ResultModifierBase, IHdxRoutingModifier
    {
        private readonly Dictionary<Address, Address> translations;

        public LaunchResultModifier_Example_NatTranslation()
        {
            // Read the address translations from the app settings
            // eg
            //   <appSettings>
            //     <add key="addressTranslations" value="10.70.120.123:1494=46.30.212.123:1494; 10.70.120.123:2598 = 46.30.212.123:2598" />
            //   </appSettings>
            // alternatively the same translations could be set directly in the code:
            //   translations[new Address("10.70.120.123", 1494)] = new Address("46.30.212.123", 1494);
            //   translations[new Address("10.70.120.123", 2598)] = new Address("46.30.212.123", 2598);
            translations = ParseAddressTranslations(ConfigurationManager.AppSettings["addressTranslations"]);

            if (translations.Any(translation => !translation.Key.Port.HasValue))
            {
                // translation key addresses without a port will never have a match, so write a warning 
                Tracer.TraceWarning("Translations with missing ports have been defined, these will be ignored");
            }
        }

        public Address ModifyHdxAddress(Address hdxAddress, CustomizationContextData context)
        {
            return TranslateAddress(hdxAddress);
        }

        public Address ModifyCgpAddress(Address cgpAddress, CustomizationContextData context)
        {
            return TranslateAddress(cgpAddress);
        }

        public bool ModifyAlternateAddress(bool alternateAddress, CustomizationContextData context)
        {
            return alternateAddress;
        }

        public GatewayData ModifyGateway(GatewayData gateway, CustomizationContextData context)
        {
            return gateway;
        }

        private Address TranslateAddress(Address originalAddress)
        {
            Address translated;
            if (translations.TryGetValue(originalAddress, out translated))
            {
                Tracer.TraceInfo("Address {0} translated to {1}", originalAddress, translated);
                return translated;
            }

            Tracer.TraceInfo("Address {0} not translated", originalAddress);
            return originalAddress;
        }

        #region Code for parsing address translations

        private static Dictionary<Address, Address> ParseAddressTranslations(string addressTranslationsString)
        {
            var translations = (addressTranslationsString ?? string.Empty)
                .Split(new[] { ';' })
                .Select(ParseAddressTranslation)
                .Where(IsNotNull)
                .ToDictionary(translation => translation.Item1, translation => translation.Item2);

            if (translations.Count == 0)
            {
                Tracer.TraceWarning("No valid address translations found");
            }

            return translations;
        }

        private static Tuple<Address, Address> ParseAddressTranslation(string translationString)
        {
            Address[] addresses = translationString.Split(new[] { "=" }, StringSplitOptions.None).Select(ParseAddressWithPort).ToArray();
            if (addresses.Length != 2 || !addresses.All(IsNotNull))
            {
                Tracer.TraceWarning("Address Translation entry '{0}' is not of a unrecognised format and has been ignored.", translationString);
                return null;
            }

            Tracer.TraceInfo("Adding address translation: {0} => {1}", addresses[0], addresses[1]);
            return new Tuple<Address, Address>(addresses[0], addresses[1]);
        }

        private static Address ParseAddressWithPort(string addressString)
        {
            if (string.IsNullOrEmpty(addressString))
            {
                Tracer.TraceWarning("Ignoring empty address");
                return null;
            }

            string[] addressParts = addressString.Trim().Split(new[] { ':' });
            if (addressParts.Length != 2)
            {
                Tracer.TraceWarning("Ignoring address without host and port: '{0}'", addressString);
            }

            try
            {
                string host = addressParts[0];
                int port = int.Parse(addressParts[1]);
                return new Address(host, port);
            }
            catch (Exception exception)
            {
                Tracer.TraceWarning("Ignoring invalid address: '{0}' : {1}", addressString, exception);
                return null;
            }
        }

        private static bool IsNotNull<T>(T value) where T : class 
        {
            return value != null;
        }

        #endregion
    }
}
