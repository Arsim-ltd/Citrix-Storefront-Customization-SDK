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
using System;
using StoreCustomization_Enumeration;

namespace StoreCustomization_Input
{
    public class InputModifier : IInputModifier
    {
        public bool RunExtendedValidation { get { return false; } }
        public bool ReturnOriginalValueOnFailure { get { return false; } }

		public void Modify(out FarmSetsContext farmSetsContext,
						   out DeviceInfo deviceInfo,
						   out AccessConditions accessConditions,
						   CustomizationContextData context)
		{
			string GatewayName = AGCheck.ISAGEE(context);
			//LAN, keep clientname as is.
			string newClientName = context.DeviceInfo.ClientName;

			if (GatewayName != "")
			{
				string DetectedAddress = context.DeviceInfo.DetectedAddress;
				try
				{
					//IPVPN subnets
					if (DetectedAddress.StartsWith("10.80") || DetectedAddress.StartsWith("10.88") || DetectedAddress.StartsWith("10.89"))
					{
						newClientName = "IN_" + DetectedAddress;
					}
					//Assuta NAT.
					else if (DetectedAddress.Contains("192.168.21.12"))
					{
						newClientName = "AS_" + DetectedAddress;
					}
					//Everything else is external.
					else
					{
						newClientName = "EX_" + DetectedAddress;
					}
					//Just in case the address is not detected, set EX as client name as fallback for security.
					if (DetectedAddress == null)
					{
						newClientName = "EX_" + context.DeviceInfo.ClientName;
					}
					//Max client name is 20 characters.
					if (newClientName.Length > 20)
					{
						newClientName = newClientName.Substring(0, 20);
					}
				}
				catch (Exception rdx) { newClientName = "ERR_" + context.DeviceInfo.ClientName; }
			}
			dataCollect(context);

			farmSetsContext = context.FarmSetsContext;
			deviceInfo = context.DeviceInfo;
			deviceInfo.ClientName = newClientName;
			accessConditions = context.AccessConditions;
		}

		private void dataCollect(CustomizationContextData context)
		{
			string Useragent = context.HttpContext.Request.UserAgent;
			string Username = context.UserIdentity.Name;
			string ClientIP = context.DeviceInfo.DetectedAddress;
			Logger.DataCollectionLog(Username + "," + ClientIP + "," + Useragent);
			Useragent = null;
			Username = null;
			ClientIP = null;
		}
    }
}
