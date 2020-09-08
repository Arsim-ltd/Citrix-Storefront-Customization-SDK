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

namespace StoreCustomization_SessionEnumeration
{
    /// <summary>
    /// Example session list modifier which filters out certain sessions based upon the access conditions (which may have been set by a related input customization).
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class SessionListModifier_Example_PreventReconnectUsingAccessConditions : ResultModifierBase, ISessionListModifier
    {
        private readonly XmlSerializationHelper<sessionState> serializer = new XmlSerializationHelper<sessionState>();

        public string Modify(string valueToModify, CustomizationContextData context)
        {
            // Example: we set the ClientTabletOS Access Condition in the InputModifer CustomizeAccessCondiitions 
            // example, but this would equally apply to any externally set access condition.
            //
            // The presence of this Session Customization point is to provide consistent control for scenarios
            // where access to resources is dynamically controlled. As well as limiting visibility to resource 
            // enumeration, block the clients 'view' of any active sessions for such apps which may have been established 
            // in a permitted context.
            if (!HasAccessCondition(context, "ClientTabletOS"))
            {
                // No changes required as context not applicable
                return valueToModify;
            }

            Tracer.TraceInfo("Session filtering customization applies");

            var sessions = serializer.Deserialize(valueToModify);

            var resultantList = new List<sessionType>();
            foreach (sessionType s in sessions.sessions)
            {
                TraceSession(s);

                // Having NT in the resource internal name used as shorthand for 'No Tablets'in this example
                // Note: limited info on the apps in the target session is available here so either use an explicit 
                // list of apps or have some encoding in the available data.
                if (!s.initialapp.Contains("NT"))
                {
                    resultantList.Add(s);
                }
            }

            sessions.sessions = resultantList.ToArray();
            string newSessions = serializer.Serialize(sessions);

            if (newSessions == null)
            {
                Tracer.TraceInfo("Failure to reform session document, revert to original");
                return valueToModify;
            }

            Tracer.TraceInfo("Resultant Session String: {0}", newSessions);
            return newSessions;
        }

        private void TraceSession(sessionType s)
        {
            Tracer.TraceInfo(
                " App: {0} Session ID: {1} ResID: {2} Agg({3})",
                s.initialapp,
                s.id,
                s.initialappresourceid,
                s.initialappresourceaggregated);

            Tracer.TraceInfo(" Publisher: {0} Server type: {1}", s.publishername, s.servertype);
        }

        /// <summary>
        /// Determines whether the specified access condition applies in the current context.
        /// Note, this currently ignores the Access Condition farm value.
        /// </summary>
        /// <param name="context">The customization context.</param>
        /// <param name="accessCondition">The access condition.</param>
        /// <returns><c>true</c> if the specified access condition exists; otherwise <c>false</c>.</returns>
        private bool HasAccessCondition(CustomizationContextData context, string accessCondition)
        {
            AccessConditions accessConditions = context.AccessConditions;
            return accessConditions != null
                && accessConditions.Conditions != null
                && accessConditions.Conditions.Contains(accessCondition);
        }
    }
}
