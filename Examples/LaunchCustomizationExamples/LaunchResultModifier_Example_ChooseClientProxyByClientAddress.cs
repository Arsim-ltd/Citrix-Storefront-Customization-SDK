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

using System.Text.RegularExpressions;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using Examples.Helpers;

namespace StoreCustomization_Launch
{
    /// <summary>
    /// Example launch result modifier which sets the client proxy type depending on the detected client address.
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class LaunchResultModifier_Example_ChooseClientProxyByClientAddress : ResultModifierBase, ILaunchResultModifier
    {
        private readonly Regex clientsNeedingSocksProxyPattern = new Regex(@"^10\.1\.");

        public string Modify(string originalIcaFileContent, CustomizationContextData context)
        {
            var icaFile = new IcaFile(originalIcaFileContent);

            // Get the client ip address (detected from the request HTTP headers)
            var clientIpAddress = context.DeviceInfo.DetectedAddress;

            if (clientsNeedingSocksProxyPattern.IsMatch(clientIpAddress))
            {
                // the client ip address matches the range of addresses for which we want the client to use a SOCKS proxy.
                SetProxySetting(icaFile, "ProxyType", "Socks");
                SetProxySetting(icaFile, "ProxyHost", "socksproxy.mycompany.com:1080");
            }
            else
            {
                // otherwise let the client auto detect the proxy server.
                SetProxySetting(icaFile, "ProxyType", "Auto");                
            }

            string customizedIcaContent = icaFile.ToString();
            return customizedIcaContent;
        }

        private void SetProxySetting(IcaFile icaFile, string proxySettingName, string value)
        {
            // Set proxy settings in both the WFClient and Application sections
            // to avoid possible problems in older clients.
            icaFile.SetPropertyValue("WFClient", proxySettingName, value);
            icaFile.SetPropertyValue(IcaFile.ApplicationSection, proxySettingName, value);
        }
    }
}
