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

namespace StoreCustomization_Input
{
    /// <summary>
    /// Example input modifier which adds a prefix to the client name depending on whether the request reached StoreFront 
    /// via one of its configured gateways and, if so, a prefix based upon the gateway location (as determined from its hostname).  
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class InputModifier_Example_OverrideClientName : ResultModifierBase, IInputModifier
    {
        public void Modify(
            out FarmSetsContext farmSetsContext,
            out DeviceInfo deviceInfo,
            out AccessConditions accessConditions,
            CustomizationContextData context)
        {
            // Example: detect which NetScaler Gateway the user connected through and override the client name for
            // later policy or general use cases.
            // Note: client name modification only is passed to session if overrideclientname is set in web.config
            var gateway = context.RequestGateway;
            Tracer.TraceInfo("Request via gateway: {0}", gateway != null ? gateway.Name : "(None)");

            // Default to Internal Connection (not via gateway) - Add "LAN" to start of client name
            string gwPrefix = "LAN";

            if (gateway != null)
            {
                var gatewayHost = gateway.Address.Host;
                if (gatewayHost.Contains(".mycorp.co.uk") || gatewayHost.Contains(".mycorp.ch"))
                {
                    // Connection made to European gateways - Add "EU-" to start of client name
                    gwPrefix = "EU-";
                }
                else
                {
                    // Connection Not made to European gateways - Add "ROW" to start of client name
                    gwPrefix = "ROW";
                }
            }

            deviceInfo = context.DeviceInfo;

            // Now modify Client Name for use in other customisations or back end policies
            // Note: only comes out to session if overrideclientname is on
            string newClientName = gwPrefix + deviceInfo.ClientName;
            if (newClientName.Length > 20)
            {
                newClientName = newClientName.Substring(0, 20); // ensure we don't exceeed max length  
            }

            deviceInfo.ClientName = newClientName;

            // We do not customize other parameters - pass them unchanged.
            farmSetsContext = context.FarmSetsContext;
            accessConditions = context.AccessConditions;
        }
    }
}
