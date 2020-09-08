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
using System.DirectoryServices.AccountManagement;
using System.Linq;
using Citrix.DeliveryServices.ResourcesCommon.Customization.Contract;
using Examples.Helpers;

namespace StoreCustomization_Enumeration
{
    /// <summary>
    /// Example enumeration result modifier which modifies the enumeration result for users in the 'Callcenter Users' AD group.
    /// For these users the resources are handled based upon the folder configured in XenApp/XenDesktop. 
    /// All apps/desktops in the BYO folder are filtered out of the enumeration result.
    /// All apps/desktops in the callcenter folder are automatically subscribed and moved to the top-level folder.
    /// </summary>
    /// <remarks>
    /// In order to be used as a customization class, this class would need to be renamed and moved into a correctly named assembly.
    /// It would also require that any helper classes are also moved into the same assembly.
    /// </remarks>
    public class EnumerationResultModifier_Example_CallCenter : ResultModifierBase, IEnumerationResultModifier
    {
        private readonly XmlSerializationHelper<resourceType> singleResourceSerializer = new XmlSerializationHelper<resourceType>();

        private readonly XmlSerializationHelper<resources> resourcesSerializer = new XmlSerializationHelper<resources>();

        public string Modify(string valueToModify, CustomizationContextData context)
        {
            // For this example, we're going to alter resources if the user in question is a member of 
            // the 'Callcenter Users' group.
            Tracer.TraceInfo("Resource SDK Enumeration customisation");
            Tracer.TraceInfo(context.ToString());

            try
            {
                if (!DoesCustomizationApply(context))
                {
                    return valueToModify;
                }

                // we have a full list of enumerated resources
                Tracer.TraceInfo("Full Resource List");
                var resources = resourcesSerializer.Deserialize(valueToModify);

                var editres = new List<resourceType>();

                // Accumulate resultant resources in list
                foreach (resourceType r in resources.resource)
                {
                    Tracer.TraceInfo("Evaluating Resource...  ");
                    TraceResource(r);

                    // apply our customisation logic to this resource
                    // only preserve resources in the list is we get a true return from the customisation method
                    if (FixupResourceForCallCenter(r))
                    {
                        editres.Add(r);
                    }
                }

                // Back to array to include in resources object.
                resources.resource = editres.ToArray();

                // Re-serialise into string
                string newDoc = resourcesSerializer.Serialize(resources);

                // Return modified XML document for further use.
                return newDoc;
            }
            catch (Exception outer)
            {
                Tracer.TraceInfo("Exception in customization: {0}" + outer);

                // Revert to pre-customisation enumeration value.
                return valueToModify;
            }
        }

        public string ModifySingleApp(string valueToModify, CustomizationContextData context)
        {
            Tracer.TraceInfo("Single Resource only");

            if (!DoesCustomizationApply(context))
            {
                return valueToModify;
            }

            // turn the input string into the single resource object
            // NB it's a string that happens to be an XML document, if you want to manipulate it in any
            // other way, feel free...
            var sRes = singleResourceSerializer.Deserialize(valueToModify);

            TraceResource(sRes);

            // Apply the customisation logic to this resource.
            if (FixupResourceForCallCenter(sRes))
            {
                string newResDoc = singleResourceSerializer.Serialize(sRes);
                Tracer.TraceInfo("Returning modified resource doc: {0}", newResDoc);
                return newResDoc;
            }

            // false return from the above indicates we want to discard this element.
            Tracer.TraceInfo("//BUGBUG Need to return empty element...");

            // no work to do here...will fall through to revert to original
            return valueToModify;
        }

        private static bool DoesCustomizationApply(CustomizationContextData context)
        {
            bool customisationApplies = false;

            // For this sample, we're going to alter resources if the user in question is a member of 
            // the 'Callcenter Users' group.
            // First, find out if they are....
            try
            {
                // This helps demonstrate an important factor to consider when interacting with the wider
                // system from within these Customisation points: the Delivery Service features execute using
                // the Application Pool identities from IIS. As such they may not automatically have permission
                // to immediately call system services. In this case, for simplicity, we assume the presence 
                // of a service account for AD access
                const string myDomain = "domain";
                const string ADserviceUser = "user";
                const string ADserviceUserPwd = "password";

                const string targetGroupName = "Callcenter Users";

                var ctx = new PrincipalContext(ContextType.Domain, myDomain, ADserviceUser, ADserviceUserPwd);
                GroupPrincipal targetGroup = GroupPrincipal.FindByIdentity(ctx, targetGroupName);
                string username = context.UserIdentity.Name;
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username);
                if (targetGroup != null && user != null)
                {
                    if (user.IsMemberOf(targetGroup))
                    {
                        Tracer.TraceInfo("User {0} is member of group {1} so apply customizations", username, targetGroupName);
                        customisationApplies = true;
                    }
                    else
                    {
                        Tracer.TraceInfo("User {0} is not a member of group {1} so do not apply customizations", username, targetGroupName);
                    }
                }
                else
                {
                    Tracer.TraceInfo("Enumeration Customization: user or group not found");
                }
            }
            catch (Exception e)
            {
                Tracer.TraceInfo("Exception in user or group lookup: {0}", e);
            }

            return customisationApplies;
        }

        // fixup logic for resource
        // if returns true, preserve resource in output else discard
        private static bool FixupResourceForCallCenter(resourceType r)
        {
            // for any app in path CallCenter...
            //  Add Auto (Mandatory) keyword and change path to root
            //  Also remove any app in the BYO path.
            bool resourceRemoved = false;
            string path = (r.path ?? string.Empty).ToLower();
            if (path == "\\callcenter\\")
            {
                Tracer.TraceInfo("{0} is a callcenter app...", r.title);
                r.path = "\\";     // raise path to top level

                // We want to make sure these resources are immediately available to the users.
                // This is a cheat - it doesn't really subscribe the app, but the Receivers don't know that...
                r.mandatorySpecified = true;
                r.mandatory = true;
                r.subscriptionstatus = "subscribed";
                Tracer.TraceInfo("Have modified resource, now...");
                TraceResource(r);
            }
            else if (path == "\\byo\\")
            {
                Tracer.TraceInfo("Removing {0} as a BYO app, not applicable to CallCenter group.", r.title);
                resourceRemoved = true;
            }
            else
            {
                Tracer.TraceInfo("Leaving {0} unchanged", r.title);
            }

            return !resourceRemoved;
        }

        // Note, these helper methods have been supplied to make the customisation process more 
        // approachable. They're not terribly sophisticated and not optimal from a performance point of view.
        private static void TraceResource(resourceType r)
        {
            Tracer.TraceInfo("Resource: {0} ID: {1} Published By {2}", r.title, r.id, r.publishername);
            if (r.subscriptionstatus != null)
            {
                Tracer.TraceInfo("Subscribed: {0}", r.subscriptionstatus);
            }

            if (r.mandatorySpecified && r.mandatory)
            {
                Tracer.TraceInfo("Mandatory Resource");
            }

            if (r.featuredSpecified && r.featured)
            {
                Tracer.TraceInfo("Featured Resource");
            }

            string keywords = " No Keywords";
            if (r.keywords != null)
            {
                keywords = "Keywords " + r.keywords.Aggregate("++ ", (current, k) => current + (k + " "));
            }

            Tracer.TraceInfo(keywords);

            string properties = " No Properties set";
            if (r.properties != null)
            {
                properties = "Properties: ";
                foreach (propertyType p in r.properties)
                {
                    properties += string.Format("({0} = {1})", p.propertyId, string.Join(";", p.value));
                }
            }

            Tracer.TraceInfo(properties);

            string pathMsg = r.path == null ? "No Path" : "Path: " + r.path;
            Tracer.TraceInfo(pathMsg);
        }
    }
}
