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

namespace StoreCustomization_Launch
{
    // It is not necessary to implement both ILaunchResultModifier and IHdxRoutingModifier if only customizing
    // the ICA file generation or only customizing the HDX Routing customization.
    public class LaunchResultModifier : ILaunchResultModifier, IHdxRoutingModifier
    {
        public bool RunExtendedValidation { get { return false; } }
        public bool ReturnOriginalValueOnFailure { get { return false; } }

        #region ICA File customization

        public string Modify(string valueToModify, CustomizationContextData context)
        {
            string finalValue = valueToModify;

            //// TODO: Insert your code here.

            return finalValue;
        }

        #endregion

        #region HDX Routing customization

        //// The following methods will be ignored unless the class declares that is implements the IHdxRouting interface.
        //// If not customizing HDX Routing, it will improve performance not to declare that this interface is implemented.  

        public bool ModifyAlternateAddress(bool alternateAddress, CustomizationContextData context)
        {
            Tracer.TraceInfo("Resource SDK: Launch customization point: HDX Routing, alternate address");
            bool finalValue = alternateAddress;

            //// TODO: Insert your code here.

            return finalValue;
        }

        public Address ModifyHdxAddress(Address hdxAddress, CustomizationContextData context)
        {
            Tracer.TraceInfo("Resource SDK: Launch customization point: HDX Routing, HDX address");
            Address finalValue = hdxAddress;

            //// TODO: Insert your code here.

            return finalValue;
        }

        public Address ModifyCgpAddress(Address cgpAddress, CustomizationContextData context)
        {
            Tracer.TraceInfo("Resource SDK: Launch customization point: HDX Routing, CGP address");
            Address finalValue = cgpAddress;

            //// TODO: Insert your code here.

            return finalValue;
        }

        public GatewayData ModifyGateway(GatewayData gateway, CustomizationContextData context)
        {
            Tracer.TraceInfo("Resource SDK: Launch customization point: HDX Routing, gateway");
            GatewayData finalValue = gateway;

            //// TODO: Insert your code here.

            return finalValue;
        }

        #endregion
    }
}
