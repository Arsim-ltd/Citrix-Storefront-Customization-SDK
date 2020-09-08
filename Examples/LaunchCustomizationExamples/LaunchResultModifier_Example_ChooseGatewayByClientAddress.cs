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
    /// Example HDX routing modifier which chooses whether to route the HDX connection through one of 2 gateways,
    /// or directly, not using a gateway, based upon the client address detected from the HTTP request reaching StoreFront.
    /// Note that the gateway objects can be contructed just once, when the class instance is created, and used many times.
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class LaunchResultModifier_Example_ChooseGatewayByClientAddress : ResultModifierBase, IHdxRoutingModifier
    {
        private static readonly string[] StaUrls = 
            new[] 
                {
                    "https://sta1server1.mycompany.com/Scripts/CtxSta.dll",
                    "https://sta1server2.mycompany.com/Scripts/CtxSta.dll"
                };

        private readonly GatewayData gateway1 = new GatewayData("gateway1", new Address("gateway1.mycompany.com"), StaUrls);

        private readonly GatewayData gateway2 = new GatewayData("gateway2", new Address("gateway2.mycompany.com"), StaUrls);

        private readonly Regex directAccessPattern = new Regex(@"^10\.1\.");

        private readonly Regex gateway1Pattern = new Regex(@"^10\.2\.");

        public GatewayData ModifyGateway(GatewayData gateway, CustomizationContextData context)
        {
            // For IPv4 client addresses 10.1.*.* do not use a gateway (ie allow direct access from Receiver)
            // For IPv4 client addresses 10.2.*.* use gateway1
            // For all other client addresses, use gateway2
            string clientAddress = context.DeviceInfo.DetectedAddress;
            if (directAccessPattern.IsMatch(clientAddress))
            {
                return null;
            }

            if (gateway1Pattern.IsMatch(clientAddress))
            {
                return gateway1;
            }

            return gateway2;
        }

        public Address ModifyHdxAddress(Address hdxAddress, CustomizationContextData context)
        {
            return hdxAddress;
        }

        public Address ModifyCgpAddress(Address cgpAddress, CustomizationContextData context)
        {
            return cgpAddress;
        }

        public bool ModifyAlternateAddress(bool alternateAddress, CustomizationContextData context)
        {
            return alternateAddress;
        }
    }
}
