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
    /// Example launch result modifier which doesn't modify any values, but instead traces which users have launched which apps/desktops.
    /// A real use might send these details to a separate logging system.  
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class LaunchResultModifier_Example_LogonPointTracing : ResultModifierBase, ILaunchResultModifier
    {
        public string Modify(string valueToModify, CustomizationContextData context)
        {
            var icadetails = new IcaFile(valueToModify);
            string appLaunched = icadetails.GetPropertyValue(IcaFile.ApplicationSection, "InitialProgram"); // or "Title" for friendly Name
            Tracer.TraceInfo("User {0} launches app: {1}", context.UserIdentity.Name, appLaunched);

            // We're not changing the ica file, so just return the value originally supplied
            return valueToModify;
        }
    }
}
