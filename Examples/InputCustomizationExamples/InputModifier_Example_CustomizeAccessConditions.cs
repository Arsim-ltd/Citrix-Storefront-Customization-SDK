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
using System.Collections.Generic;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;

using Examples.Helpers;

namespace StoreCustomization_Input
{
    /// <summary>
    /// Example input modifier which the access conditions depending on whether the request reached StoreFront 
    /// from a tablet (or other mobile device) running a native Receiver. The User-Agent HTTP header is used to
    /// determine the version of Receiver.
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class InputModifier_Example_CustomizeAccessConditions : ResultModifierBase, IInputModifier
    {
        public void Modify(
            out FarmSetsContext farmSetsContext,
            out DeviceInfo deviceInfo,
            out AccessConditions accessConditions,
            CustomizationContextData context)
        {
            // Example: detect native Receivers on Android or iOS devices and set Access Condition for later
            // policy handling applying to those platforms
            accessConditions = context.AccessConditions;
            if (IsRequestFromTablet(context))
            {
                // We need to specify the AG farm to which this condition applies.
                // You (as implementer) know which will be appropriate.
                const string agFarmUrl = "ag.farm.url";
                const string tabletAccessCondition = "ClientTabletOS";
                accessConditions = AddAccessCondition(accessConditions, tabletAccessCondition, agFarmUrl);
            }

            // We do not customize other parameters - pass them unchanged.
            farmSetsContext = context.FarmSetsContext;
            deviceInfo = context.DeviceInfo;
        }

        /// <summary>
        /// Returns an AccessConditions instance which contains the supplied access condition. This may be a new
        /// instance or the supplied instance.
        /// </summary>
        /// <param name="accessConditions">The original access conditions.</param>
        /// <param name="newAccessCondition">The new access condition to add.</param>
        /// <param name="gatewayFarmUrl">The gateway farm URL.</param>
        /// <returns>An AccessConditions instance which contains the specified accessCondition.</returns>
        private static AccessConditions AddAccessCondition(
            AccessConditions accessConditions, string newAccessCondition, string gatewayFarmUrl)
        {
            // if there are no access conditions then create a new instance to hold the new condition
            if (accessConditions == null)
            {
                return new AccessConditions(new List<string> { newAccessCondition }, gatewayFarmUrl);
            }
            
            // otherwise modify the supplied instance before returning it
            if (!accessConditions.Conditions.Contains(newAccessCondition))
            {
                accessConditions.Conditions.Add(newAccessCondition);
            }

            return accessConditions;
        }

        /// <summary>
        /// Determines whether the request for the current context is from an Android or iOS tablet.
        /// </summary>
        /// <remarks>
        /// See <seealso cref="http://support.citrix.com/proddocs/topic/access-gateway-10/agee-clg-session-policies-overview-con.html"/> for more examples of Citrix Receiver user agent strings.
        /// </remarks>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if the request is from a tablet; otherwise <c>false</c>.</returns>
        private bool IsRequestFromTablet(CustomizationContextData context)
        {
            // Use the user agent string to determine the Receiver version and therefore the client OS
            string useragent = context.HttpContext.Request.Headers.Get("User-Agent") ?? string.Empty;
            return useragent.Contains("CitrixReceiver")
                && (useragent.Contains("Android") || useragent.Contains("iOS"));
        }
    }
}
