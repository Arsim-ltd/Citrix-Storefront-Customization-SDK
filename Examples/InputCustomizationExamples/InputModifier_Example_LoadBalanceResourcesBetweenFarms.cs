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

using System;
using System.Collections.Generic;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using Examples.Helpers;

namespace StoreCustomization_Input
{
    /// <summary>
    /// Example input modifier which causes resources from two farms to be aggregated (ie resource in both farms are treated as a single resource by Receiever).
    /// The farms are returned in random order to cause launches to aggregated resources to be spread evenly across the two farms.
    /// More sophisticated load-blancing algorithms are possible by replacing the implementation of <see cref="PrioritiseFarm1"/>. 
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class InputModifier_Example_LoadBalanceResourcesBetweenFarms : ResultModifierBase, IInputModifier
    {
        // The names of the farms which are being load-balanced
        // these must match the names configured for the farms (called "Delivery Controllers" in the admin console) in the store.
        private const string Farm1Name = "Farm1";
        private const string Farm2Name = "Farm2";

        // The aggregation group name to use for farm1 & farm2 so that their resources are agregated
        // (ie resources from the farms with the same display name and path are treated as single resource)
        // This value is fairly arbitrary, but should not be changed once used since it appears in the aggregated resource id
        // which is used for subscriptions. If changed, users' existing subscriptions will disappear.
        private const string AggregationGroup = "group1";

        private static readonly EquivalentFarmSet Farm1 = new EquivalentFarmSet(Farm1Name, AggregationGroup);
        private static readonly EquivalentFarmSet Farm2 = new EquivalentFarmSet(Farm2Name, AggregationGroup);

        private readonly Random random = new Random();

        public void Modify(
            out FarmSetsContext farmSetsContext,
            out DeviceInfo deviceInfo,
            out AccessConditions accessConditions,
            CustomizationContextData context)
        {
            farmSetsContext = new FarmSetsContext
                                  {
                                      Farms = context.FarmSetsContext.Farms,
                                      EquivalentFarmSets =
                                          PrioritiseFarm1()
                                              ? new List<EquivalentFarmSet> { Farm1, Farm2 }
                                              : new List<EquivalentFarmSet> { Farm2, Farm1 }
                                  };

            // We do not customize other parameters - pass them unchanged.
            deviceInfo = context.DeviceInfo;
            accessConditions = context.AccessConditions;
        }

        /// <summary>
        /// Returns true if farm1 should be given priority for this request.
        /// </summary>
        /// <returns><c>true</c> if farm1 should be prioritized for this request; otherwise <c>false</c>.</returns>
        private bool PrioritiseFarm1()
        {
            // This implementation just load-balances randomly (but equally) between farm1 & farm2  
            return random.Next(1000000) < 500000;
        }
    }
}
