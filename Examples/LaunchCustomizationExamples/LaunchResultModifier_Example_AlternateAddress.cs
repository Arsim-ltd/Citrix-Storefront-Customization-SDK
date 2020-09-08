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
    ///       <add key="addressTranslations" value="fromaddress1 => toaddress1; fromaddress2 => toaddress2;...."/>
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
    public class LaunchResultModifier_Example_AlternateAddress : ResultModifierBase, IHdxRoutingModifier
    {
        private readonly bool useAlternateAddress;

        public LaunchResultModifier_Example_AlternateAddress()
        {
            // Read the value from the AppSettings, or use false if not defined or an invalid value is present.
            useAlternateAddress = GetBoolSetting("UseAlternateAddress", false);
        }

        public bool ModifyAlternateAddress(bool alternateAddress, CustomizationContextData context)
        {
            return useAlternateAddress;
        }

        public Address ModifyHdxAddress(Address hdxAddress, CustomizationContextData context)
        {
            return hdxAddress;
        }

        public Address ModifyCgpAddress(Address cgpAddress, CustomizationContextData context)
        {
            return cgpAddress;
        }

        public GatewayData ModifyGateway(GatewayData gateway, CustomizationContextData context)
        {
            return gateway;
        }
    }
}
