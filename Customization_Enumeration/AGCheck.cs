using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;


namespace StoreCustomization_Enumeration
{
    public class AGCheck
    {
            public static string ISAGEE(CustomizationContextData context)
            {
                string gateway = "";
                try
                {
                    gateway = context.AccessConditions.FarmName.ToString().TrimEnd();
                }
                catch (Exception e) {
                #if DEBUG
                Logger.DebugLine("Could not get Header from context: " + e.Message); 
                #endif
                }
                #if DEBUG
                Logger.DebugLine("Access Gateway:" + gateway);
                #endif
                return gateway.TrimEnd();
            }


    }
}