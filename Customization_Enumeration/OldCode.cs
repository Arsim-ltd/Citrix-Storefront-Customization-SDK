
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreCustomization_Enumeration
{
    class OldCode
    {
#if DEBUG
        //else if (CurrentUser.IsMemberOf(GroupPrincipal.FindByIdentity(ConnectAD, "AGEE-SF-Employees")))
        //            {
        //                Tracer.TraceInfo("SDK_DBG - User is memeber of AGEE-SF-Employees.");
        //                resources AllApps = Deserialize<resources>(valueToModify, resourcesSerializer);
        //                var AppModNoClicks = new List<resourceType>();

        //                foreach (resourceType App in AllApps.resource)
        //                {
        //                    Tracer.TraceInfo("SDK_DBG - Checking app " + App.title);
        //                    if (App.title == "HighLearn" || App.title == "סאפ - מקוונים אישית אליך" || App.title == "Outlook 2010" || App.title == "מכבי-ידע")
        //                    {
        //                        AppModNoClicks.Add(App);
        //                    }
        //                }
        //                AllApps.resource = AppModNoClicks.ToArray();
        //                string CustomAppNoClicks = Serialize(AllApps, resourcesSerializer);
        //                return CustomAppNoClicks;
        //            }


        //          public static void CheckDuplicates(resourceType Apps)
        //          {
        //              Tracer.TraceInfo("SDK_DBG - DupeCheck: Checking if app {0} is a duplicate.", Apps);
        //              try
        //              {
        //                  foreach (DuplicateApprules CurrentRule in DuplicateAppRules)
        //                  {
        //                      Tracer.TraceInfo("SDK_DBG - DupeCheck: Checking current rule. Applications in rule: {0}. Winner App: {1}", CurrentRule.AppNames, CurrentRule.WinnerApp);
        //                      if (CurrentRule.AppNames.Contains(AppTitle) && CurrentRule.WinnerApp != AppTitle)
        //                      {
        //                          Tracer.TraceInfo("SDK_DBG - DupeCheck: Duplicate application detected. discarding.");
        //                          return true;
        //                      }
        //                  }
        //                  Tracer.TraceInfo("SDK_DBG - DupeCheck: Duplicate not found. Assuming this is a Winner app or no rules for it found.");
        //                  return false;
        //              }
        //              catch (Exception err)
        //              {
        //                  Tracer.TraceInfo("SDK_DBG_ERR - DupeCheck:"+ err.Message);
        //                  return false;
        //              }
        //          }

        //public static List<string> GetADGroups(string Username)
        //{
        //    Tracer.TraceInfo("SDK_DBG - Getting AD groups for " + Username);
        //    List<string> UserGroups = new List<string>();
        //    const string myDomain = "";
        //    const string SVCUsername = "";
        //    const string SVCPassword = "";
        //    try
        //    {
        //        var ConnectAD = new PrincipalContext(ContextType.Domain, myDomain, SVCUsername, SVCPassword);
        //        UserPrincipal CurrentUser = UserPrincipal.FindByIdentity(ConnectAD, Username);
        //        var MyGroups = CurrentUser.GetAuthorizationGroups();
        //        Tracer.TraceInfo("SDK_DBG - Group Count:" + MyGroups.Count());
        //        ConnectAD.Dispose();

        //        if (MyGroups.Count() > 0)
        //        {
        //            try
        //            {
        //                foreach (GroupPrincipal grp in MyGroups)
        //                {
        //                    try
        //                    {
        //                        if (grp.Name != null)
        //                        {
        //                            Tracer.TraceInfo("SDK_DBG - Adding Group " + grp.Name + " to List");
        //                            UserGroups.Add(grp.Name);
        //                            Tracer.TraceInfo("SDK_DBG - UserGroups Array count: " + UserGroups.Count());
        //                        }
        //                        else
        //                        {
        //                            Tracer.TraceInfo("SDK_DBG_ERR - Found NULL GroupName for group: " + grp.Guid);
        //                        }
        //                    }
        //                    catch (Exception ex) { Tracer.TraceInfo("SDK_DBG_ERR - Error enumerating group: " + ex.Message); }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Tracer.TraceInfo(String.Format("SDK_DBG_ERR - while tring to add a group: Exception: {0}, Trace: {1}, Source: {2}",
        //                ex.Message,
        //                ex.StackTrace,
        //                ex.Source));
        //            }
        //        }
        //        else
        //        {
        //            UserGroups.Add("Error");
        //        }

        //        return UserGroups;
        //    }
        //    catch (Exception ex)
        //    {
        //        Tracer.TraceInfo("SDK_DBG - Error Completing group enumeration: " + ex.Message);
        //    }
        //    return UserGroups;
        //}

//        public static List<String> GetGroups(String Username)
//        {
//            List<string> GetGroups = new List<string>();
//            GetGroups.Add(HttpContext.Current.Request.LogonUserIdentity.User.Value.ToString());
//            try
//            {
//                IdentityReferenceCollection ADGroupCollection = new IdentityReferenceCollection();
//                ADGroupCollection = HttpContext.Current.Request.LogonUserIdentity.Groups;
//                try
//                {
//                    foreach (IdentityReference grp in ADGroupCollection)
//                    {
//                        GetGroups.Add(grp.Value.ToString());
//#if DEBUG
//                        Tracer.TraceInfo("SDK_DBG - Proccessing AD Group:" + grp.Value.ToString());
//#endif
//                    }
//                }
//                catch (Exception e)
//                {
//#if DEBUG
//                    Tracer.TraceInfo("SDK_DBG - Error getting a group from the group list");
//#endif
//                }
//            }
//            catch (Exception e)
//            {
//#if DEBUG
//                Tracer.TraceInfo("SDK_DBG - Error getting the grouplist of the user");
//#endif
//            }
//            return GetGroups;
//        }
#endif

    }
}
