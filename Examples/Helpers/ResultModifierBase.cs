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

using System.Configuration;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;

namespace Examples.Helpers
{
    /// <summary>
    /// A base class which handles the RunExtendedValidation and ReturnOriginalValueOnFailure properties,
    /// allowing them to be set from the Store web.config file without requiring recompilation or
    /// redeployment of customizations.
    /// </summary>
    public abstract class ResultModifierBase : IResultModifier
    {
        protected ResultModifierBase()
        {
            // Allow these settings to be controlled from the appSettings section of the Store web.config file
            RunExtendedValidation = GetBoolSetting("RunExtendedValidation", false);
            ReturnOriginalValueOnFailure = GetBoolSetting("ReturnOriginalValueOnFailure", false);
        }

        public bool RunExtendedValidation { get; protected set; }

        public bool ReturnOriginalValueOnFailure { get; protected set; }

        /// <summary>
        /// Gets a boolean setting from the AppSettings section of the Store web.config.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <param name="defaultValue">The value to use if there is no value specified or if the specified value is not a valid boolean value.</param>
        /// <returns>The value of the specified AppSetting parsed as a boolean; or the specified defaultValue if the setting is missing or not a valid boolean.</returns>
        protected bool GetBoolSetting(string name, bool defaultValue)
        {
            var value = ConfigurationManager.AppSettings[name];
            if (value == null)
            {
                Tracer.TraceInfo("No AppSetting specified for '{0}', using default value of {1}", name, defaultValue);
                return defaultValue;
            }

            bool result;
            if (!bool.TryParse(value, out result))
            {
                Tracer.TraceInfo("Unrecognised AppSetting value '{0}' specified for '{1}', using default value of {2}", value, name, defaultValue);
                return defaultValue;
            }

            Tracer.TraceInfo("AppSetting '{0}' has value {1}", name, result);
            return result;
        }
    }
}
