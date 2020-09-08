using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.Security.Principal;
using System.IO;
using System.Xml.Serialization;
using System.Security.Claims;

namespace StoreCustomization_Enumeration
{

    public class DuplicateApprules
    {
        public string AppNames { get; set; }
        public string WinnerApp { get; set; }
        public string FinalAppName { get; set; }
    }

    class Helpers
    {
        public static string GetHeaderValueFromContext(CustomizationContextData context, string headerName)
        {
            NameValueCollection reqHeads = context.HttpContext.Request.Headers;
            string targetH = headerName.ToLower();
            string values = "";
            bool found = false;

            foreach (string hr in reqHeads.AllKeys)
            {
                if (hr.ToLower() == targetH)
                {
                    found = true;
                    int h = 0;
                    foreach (string hval in reqHeads.GetValues(hr))
                    {
                        if (h++ > 1)
                        {
                            values += ";";
                        }
                        values += hval;
                    }
                }
            }
            reqHeads = null;
            targetH = null;

            if (!found)
            {
                values = null;
                return null;
            }

            return values;
        }

        public static T Deserialize<T>(string serialized, XmlSerializer serializer)
        {
            using (var reader = new StringReader(serialized))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static string Serialize<T>(T obj, XmlSerializer serializer)
        {
            var sb = new StringBuilder();
            using (var writer = new Utf8StringWriter(sb))
            {
                serializer.Serialize(writer, obj);
            }

            return sb.ToString();
        }

        public class Utf8StringWriter : StringWriter
        {
            public Utf8StringWriter(StringBuilder sb) : base(sb) { }

            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }

        public static List<String> GetGroups(String Username)
        {
            List<string> userNestedMembership = new List<string>();
            try
            {
                DirectoryEntry domainConnection = new DirectoryEntry();
                domainConnection.Username = "mac-ad\\tovbin_i";
                domainConnection.Password = "gq2k97X~";
                domainConnection.AuthenticationType = AuthenticationTypes.Secure;

                var samSearcher = new DirectorySearcher();
                samSearcher.SearchRoot = domainConnection;
                samSearcher.Filter = "(samAccountName=" + Username + ")";
                samSearcher.PropertiesToLoad.Add("displayName");

                var samResult = samSearcher.FindOne();
                samSearcher.Dispose();
                samSearcher = null;

                if (samResult != null)
                {
                    var theUser = samResult.GetDirectoryEntry();
                    theUser.RefreshCache(new string[] { "tokenGroups" });

                    foreach (byte[] resultBytes in theUser.Properties["tokenGroups"])
                    {
                        var SID = new SecurityIdentifier(resultBytes, 0);
                        var sidSearcher = new DirectorySearcher();

                        sidSearcher.SearchRoot = domainConnection;
                        sidSearcher.Filter = "(objectSid=" + SID.Value + ")";
                        sidSearcher.PropertiesToLoad.Add("name");

                        var sidResult = sidSearcher.FindOne();
                        try
                        {
                            sidSearcher.Dispose();
                            sidSearcher = null;
                        }
                        catch (Exception er)
                        {
                            #if DEBUG
                            Logger.DebugLine("Could not clear sidSearcher:"+ er.Message);
                            #endif
                        }

                        if (sidResult != null)
                        {
                            userNestedMembership.Add(((string)sidResult.Properties["name"][0]).ToLower());
                            #if DEBUG
                            //File.AppendAllText("C:\\temp\\sflog.txt", "Proccessed group:"+ (string)sidResult.Properties["name"][0]);
                            #endif
                        }
                        SID = null;
                        sidResult = null;
                    }

                    samResult = null;
                    theUser.Dispose();
                    theUser = null;
                }

                try
                {
                    domainConnection.Close();
                    domainConnection.Dispose();
                    domainConnection = null;
                }
                catch (Exception er) {
                    #if DEBUG
                    Logger.DebugLine("Could not clear domainConnection:"+ er.Message);
                    #endif
                }

                return userNestedMembership;
            }
            catch (Exception ex) {
                #if DEBUG
                Logger.DebugLine("Error proccessing AD groups:" + ex.Message);
                #endif
                userNestedMembership.Add("Error");
                return userNestedMembership;
            }

        }

        //public static List<resourceType> CheckDuplicates(List<resourceType> AppMod, List<DuplicateApprules> DuplicateAppRules)
        //{
        //    #if DEBUG
        //    Logger.DebugLine("DupeCheck: Removing duplicate apps:" + DuplicateAppRules.Count);
        //    #endif

        //    try
        //	{
        //        char[] splitdelim = { ',' };

        //        foreach (DuplicateApprules CurrentRule in DuplicateAppRules)
        //        {
        //            List<string> SearchResult = new List<string>();
        //            string[] AppRuleApps = CurrentRule.AppNames.Split(splitdelim);
        //            string[] LoserApps = AppRuleApps.Where(s => s != CurrentRule.WinnerApp).ToArray();
        //            #if DEBUG
        //            Logger.DebugLine("DupeCheck: Split Apps - " + string.Join(", ", AppRuleApps));
        //            Logger.DebugLine("DupeCheck: Loser App - " + string.Join(", ", LoserApps));
        //            #endif
                    
        //            try
        //            {
        //                //Get all apps that are published to the user which contain the name of the apps in the current rule.
        //                SearchResult = AppMod.Where(s => AppRuleApps.Contains(s.title)).Select(s => s.title).ToList();
        //            }
        //            catch (Exception ex) {
        //                AppRuleApps = null;
        //                LoserApps = null;
        //                SearchResult.Clear();
        //                SearchResult = null;
        //                #if DEBUG
        //                Logger.DebugLine("DupeCheck: Could not search for results:" + ex.Message);
        //                #endif
        //            }
                    


        //            if (SearchResult.Count == 0)
        //            {
        //                #if DEBUG
        //                Logger.DebugLine("DupeCheck: Search found no results." + SearchResult.Count);
        //                #endif
        //            }
        //            else
        //            {
        //                #if DEBUG
        //                Logger.DebugLine("DupeCheck: Search found results:" + SearchResult.Count);
        //                #endif

        //                foreach (string a in SearchResult)
        //                {
        //                    #if DEBUG
        //                    Logger.DebugLine("DupeCheck: Result" + a);
        //                    #endif
        //                }
        //            }

        //            if (SearchResult.Count > 1)
        //            {
        //                //If there is only One application in the current rule, remove based on PreferedFarm instead of Apptile.
        //                if (AppRuleApps.Length == 1)
        //                {
        //                    #if DEBUG
        //                    Logger.DebugLine("DupeCheck: Detected only one app in rule. Assuming PreferedKeyword check required.");
        //                    #endif
        //                    string PreferedWord = null;
        //                    try
        //                    {
        //                        PreferedWord = SQL.GetConfig("PreferedKeyword");
        //                        #if DEBUG
        //                        Logger.DebugLine("DupeCheck: removing app containing keyword " + PreferedWord);
        //                        #endif
        //                        AppMod.RemoveAll(s => s.title==string.Join("",AppRuleApps) && !s.summary.Contains(PreferedWord));
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        #if DEBUG
        //                        Tracer.TraceInfo("SDK_DBG_ERR - DupeCheck: Could not set PreferedFarm. Aboring.\r\n"+e.Message);
        //                        #endif
        //                    }
        //                }
        //                else
        //                {
        //                    //Remove losers
        //                    foreach (string CurrentLoserApp in LoserApps)
        //                    {
        //                        AppMod.RemoveAll(s => s.title == CurrentLoserApp);
        //                    }

        //                    //Rename AppTitle for winner, if you want.
        //                    if (CurrentRule.FinalAppName.Length > 0)
        //                    {
        //                        AppMod.Where(s => s.title == CurrentRule.WinnerApp).ToList().ForEach(s => s.title = CurrentRule.FinalAppName);
        //                    }
        //                }

        //            }

        //            AppRuleApps = null;
        //            LoserApps = null;
        //            SearchResult.Clear();
        //            SearchResult = null;
        //        }

        //        splitdelim = null;
        //        return AppMod;
        //	}
        //	catch (Exception err)
        //	{
        //        #if DEBUG
        //        Tracer.TraceInfo("SDK_DBG_ERR - DupeCheck:"+err.Message);
        //        #endif

        //        return AppMod;
        //	}
        //}
    }

    public static class Security
    {
        public static bool IsInGroup(this ClaimsPrincipal User, string GroupName)
        {
            var groups = new List<string>();

            var wi = (WindowsIdentity)User.Identity;
            if (wi.Groups != null)
            {
                foreach (var group in wi.Groups)
                {
                    try
                    {
                        File.AppendAllText("C:\\temp\\sflog.txt", group.Value);
                        groups.Add(group.Translate(typeof(NTAccount)).ToString());
                    }
                    catch (Exception)
                    {
                    }
                }
                return groups.Contains(GroupName);
            }
            return false;
        }
    }
}
