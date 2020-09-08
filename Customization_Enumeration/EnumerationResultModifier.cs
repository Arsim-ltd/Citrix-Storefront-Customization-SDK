using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace StoreCustomization_Enumeration
{
    public class EnumerationResultModifier : IEnumerationResultModifier
    {
        public bool RunExtendedValidation { get { return false; } }
        public bool ReturnOriginalValueOnFailure { get { return false; } }
       
        private static readonly XmlSerializer resourcesSerializer = new XmlSerializer(typeof(resources));

        public string Modify(string valueToModify, CustomizationContextData context)
        {
            Logger.DebugLine("Enumeration Started for "+ context.UserIdentity.Name);
            string GatewayName = AGCheck.ISAGEE(context);
            #if DEBUG
            GatewayName = "c.mac.org.il";
            #endif
            Logger.DebugLine("SDK in debug mode. Gateway always set to true.");

            resources AllApps = Helpers.Deserialize<resources>(valueToModify, resourcesSerializer);
            if (GatewayName != "")
            {
                try
                {
                    List<string> UserGroups = Helpers.GetGroups(context.UserIdentity.Name);
                    Logger.DebugLine("Detected " +UserGroups.Count+" AD groups.");
                    List<resourceType> AppMod = new List<resourceType>();
                    Logger.DebugLine(string.Join(",", UserGroups.ToArray()));
                    try
                    {
                        Logger.DebugLine("Match result employees:" + UserGroups.Contains("agee-employees"));
                        if(UserGroups.Contains("agee-employees"))
                        {
                            UserGroups.Clear();
                            UserGroups = null;
                            Logger.DebugLine("Adding only employees apps.");
                            foreach (resourceType App in AllApps.resource)
                            {
                                if (App.title == "Outlook2010" || App.title == "Outlook2016" || App.title == "מכבי ידע" || App.title == "מקוונים אישית אליך-פורטל סאפ")
                                {
                                    Logger.DebugLine("Matched " + App.title + ". Adding to Mod Group");
                                    AppMod.Add(App);
                                }
                            }
                            AllApps.resource = AppMod.ToArray();
                            string CustomApps = Helpers.Serialize(AllApps, resourcesSerializer);
                            return CustomApps;
                        }
                    }
                    catch (Exception rdx)
                    {
                        Logger.DebugLine("Could not do something in employees:" + rdx.Message);
                    }


                    try
                    {
                        Logger.DebugLine("match result noclicks:" + UserGroups.Contains("agee-full-without-clicks"));
                        if (UserGroups.Contains("agee-full-without-clicks"))
                        {
                            UserGroups.Clear();
                            UserGroups = null;
                            #if DEBUG
                            Logger.DebugLine("Removing Clicks from app list.");
                            #endif
                            foreach (resourceType App in AllApps.resource)
                            {
                                if (!App.title.Contains("ניהול תיק רפואי"))
                                {
                                    AppMod.Add(App);
                                }
                            }
                            AllApps.resource = AppMod.ToArray();
                            AppMod.Clear();
                            AppMod = null;
                            return Helpers.Serialize(AllApps, resourcesSerializer);
                        }
                    }
                    catch (Exception rdx)
                    {
                        Logger.DebugLine("Could not do something in no-clicks:" + rdx.Message);
                    }
                }
                catch(Exception rdx) {
                    Logger.DebugLine("Customization error:" +rdx.Message );
                    return valueToModify; }
            }
            return valueToModify;
        }



        public string ModifySingleApp(string valueToModify, CustomizationContextData context)
        {
            return valueToModify;
        }
    }
}
