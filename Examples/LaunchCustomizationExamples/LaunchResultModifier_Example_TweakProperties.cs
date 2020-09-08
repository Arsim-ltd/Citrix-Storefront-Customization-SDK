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
    /// Example launch result modifier which changes some detail of the connection parameters base upon values in the calling context. 
    /// In this example: control Special Folder Redirection so that it maps to client local folders 
    /// for interior launches and to remote folders for remote launches.
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class LaunchResultModifier_Example_TweakProperties : ResultModifierBase, ILaunchResultModifier
    {
        public string Modify(string valueToModify, CustomizationContextData context)
        {
            var icadetails = new IcaFile(valueToModify);

            // If the request is detected as having come via a gateway, then treat as remote access: 
            bool isRemoteAccess = context.RequestGateway != null;
            icadetails.SetPropertyValue(IcaFile.ApplicationSection, "SFRAllowed", isRemoteAccess ? "Off" : "On");

            // get modified string back from helper breakdown class.
            string modifiedIcaFile = icadetails.ToString();

            Tracer.TraceInfo("Launch Customisation: check modifications to ICA File");
            Tracer.TraceInfo(modifiedIcaFile);
            return modifiedIcaFile;
        }
    }
}
