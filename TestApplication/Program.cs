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

using StoreCustomization_Enumeration;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const string xml =
            #region Sample resources enumeration XML response.
 @"<?xml version=""1.0"" encoding=""utf-8""?>
<resources xmlns=""http://citrix.com/delivery-services/2-0/resources""
xmlns:a=""http://citrix.com/delivery-services/2-0/subscriptions""
enumeration=""full"" a:subscriptionsstatus=""enabled"">

<resource><id>Controller.Notepad</id><link><url>http://server/Citrix/Store/resources/v2/url-</url></link><title>Orca MSI Editor</title><summary>Orca MSI Editor</summary><path>\Apps\</path><resourcetype>Citrix.MPS.Application</resourcetype><clienttypes><clienttype>ica30</clienttype><clienttype>rdp</clienttype></clienttypes><rade><licenseType>online</licenseType><offlineMode>none</offlineMode></rade><keywords><keyword>ConfigMgr</keyword></keywords><properties><property propertyId=""prefer""><value>\\Programs\Notepad</value></property></properties><enabled>true</enabled><launchica><url>http://server/Citrix/Store/resources/v2/Q29udHJvbGxlci5PcmNhIE1TSSBFZGl0b3I-/launch/ica</url></launchica><image><url>http://server/Citrix/Store/resources/v2/RkVEQjFCNUFBRjdDRDc1RUZDRUQzQzkyMTI1MTcwMTQ0Mjg1RTU0QQ--/image</url></image><imagehash>RkVEQjFCNUFBRjdDRDc1RUZDRUQzQzkyMTI1MTcwMTQ0Mjg1RTU0QQ--</imagehash><aggregatedresource>false</aggregatedresource><publisherresourceid>Orca MSI Editor</publisherresourceid><publishername>server2</publishername><a:subscriptionactions><url>http://server/Citrix/Store/resources/v2/subscriptions/Q29udHJvbGxlci5PcmNhIE1TSSBFZGl0b3I-</url></a:subscriptionactions></resource>
<resource><id>Controller.Desktop</id><link><url>http://server/Citrix/Store/resources/v2/url-</url></link><title>Desktop</title><summary /><path>\</path><resourcetype>Citrix.MPS.Desktop</resourcetype><clienttypes><clienttype>ica30</clienttype><clienttype>rdp</clienttype></clienttypes><rade><licenseType>online</licenseType><offlineMode>none</offlineMode></rade><keywords><keyword>ConfigMgr_Hide</keyword><keyword>ConfigMgr</keyword></keywords><enabled>true</enabled><launchica><url>http://server/Citrix/Store/resources/v2/Q29udHJvbGxlci5Db25maWdNZ3IgUGFpbnQ-/launch/ica</url></launchica><image><url>http://server/Citrix/Store/resources/v2/NkJFMEVEQ0IzRDhEN0ZFM0NBMjVCMkQyREYwMDE0RjdEOUVBRDI5RA--/image</url></image><imagehash>NkJFMEVEQ0IzRDhEN0ZFM0NBMjVCMkQyREYwMDE0RjdEOUVBRDI5RA--</imagehash><aggregatedresource>false</aggregatedresource><publisherresourceid>ConfigMgr Paint</publisherresourceid><publishername>server2</publishername><a:subscriptionactions><url>http://server/Citrix/Store/resources/v2/subscriptions/Q29udHJvbGxlci5Db25maWdNZ3IgUGFpbnQ-</url></a:subscriptionactions></resource>
<resource><id>Controller.Desktop being treated as app</id><link><url>http://server/Citrix/Store/resources/v2/url-</url></link><title>Desktop being treated as app</title><summary /><path>\</path><resourcetype>Citrix.MPS.Application</resourcetype><clienttypes><clienttype>ica30</clienttype><clienttype>rdp</clienttype></clienttypes><rade><licenseType>online</licenseType><offlineMode>none</offlineMode></rade><keywords><keyword>treatasapp</keyword></keywords><enabled>true</enabled><launchica><url>http://server/Citrix/Store/resources/v2/Q29udHJvbGxlcjIuRGVza3RvcCBiZWluZyB0cmVhdGVkIGFzIGFwcA--/launch/ica</url></launchica><image><url>http://server/Citrix/Store/resources/v2/NDJFODA0QzcyMkQ1REZGNDFGRDRCMUI1MTZFMUVBODQxOEU4QzY0Nw--/image</url></image><imagehash>NDJFODA0QzcyMkQ1REZGNDFGRDRCMUI1MTZFMUVBODQxOEU4QzY0Nw--</imagehash><aggregatedresource>false</aggregatedresource><publisherresourceid>Desktop being treated as app</publisherresourceid><publishername>server2</publishername><a:subscriptionactions><url>http://server/Citrix/Store/resources/v2/subscriptions/Q29udHJvbGxlcjIuRGVza3RvcCBiZWluZyB0cmVhdGVkIGFzIGFwcA--</url></a:subscriptionactions></resource></resources>";
            #endregion

            var enumeration = new EnumerationResultModifier();

            enumeration.Modify(xml, null);
        }
    }
}
