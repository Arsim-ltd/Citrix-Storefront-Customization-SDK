﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.17929.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
[System.Xml.Serialization.XmlRootAttribute("resource", Namespace="http://citrix.com/delivery-services/2-0/resources", IsNullable=false)]
public partial class resourceType {
    
    private string idField;
    
    private urlElementType linkField;
    
    private string titleField;
    
    private string summaryField;
    
    private string pathField;
    
    private string contentlocationField;
    
    private string resourcetypeField;
    
    private string[] clienttypesField;
    
    private radeType radeField;
    
    private string[] keywordsField;
    
    private propertyType[] propertiesField;
    
    private imageType[] imagesField;
    
    private fileTypeType[] playsfiletypesField;
    
    private bool enabledField;
    
    private bool enabledFieldSpecified;
    
    private urlElementType launchicaField;
    
    private urlElementType launchradeField;
    
    private urlElementType imageField;
    
    private urlElementType iconField;
    
    private urlElementType machinepoweroffField;
    
    private bool featuredField;
    
    private bool featuredFieldSpecified;
    
    private bool workflowenabledField;
    
    private bool workflowenabledFieldSpecified;
    
    private bool workflowwithoutclientinteractionField;
    
    private bool workflowwithoutclientinteractionFieldSpecified;
    
    private string imagehashField;
    
    private urlElementType accessonetimeticketField;
    
    private urlElementType followmedataaccessField;
    
    private desktopInfoType desktopinfoField;
    
    private urlElementType assigndesktopField;
    
    private bool aggregatedresourceField;
    
    private bool aggregatedresourceFieldSpecified;
    
    private string publisherresourceidField;
    
    private string publishernameField;
    
    private bool mandatoryField;
    
    private bool mandatoryFieldSpecified;
    
    private urlElementType subscriptionactionsField;
    
    private string subscriptionstatusField;
    
    private string subscriptionidField;
    
    private propertyType1[] subscriptiondataField;
    
    private string subscriptionquestionurlField;
    
    private string subscriptionreasontextField;
    
    private string subscriptionresponsereasonField;
    
    /// <remarks/>
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }
    
    /// <remarks/>
    public string title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
    
    /// <remarks/>
    public string summary {
        get {
            return this.summaryField;
        }
        set {
            this.summaryField = value;
        }
    }
    
    /// <remarks/>
    public string path {
        get {
            return this.pathField;
        }
        set {
            this.pathField = value;
        }
    }
    
    /// <remarks/>
    public string contentlocation {
        get {
            return this.contentlocationField;
        }
        set {
            this.contentlocationField = value;
        }
    }
    
    /// <remarks/>
    public string resourcetype {
        get {
            return this.resourcetypeField;
        }
        set {
            this.resourcetypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("clienttype", IsNullable=false)]
    public string[] clienttypes {
        get {
            return this.clienttypesField;
        }
        set {
            this.clienttypesField = value;
        }
    }
    
    /// <remarks/>
    public radeType rade {
        get {
            return this.radeField;
        }
        set {
            this.radeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("keyword", IsNullable=false)]
    public string[] keywords {
        get {
            return this.keywordsField;
        }
        set {
            this.keywordsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType[] properties {
        get {
            return this.propertiesField;
        }
        set {
            this.propertiesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("image", IsNullable=false)]
    public imageType[] images {
        get {
            return this.imagesField;
        }
        set {
            this.imagesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("filetype", IsNullable=false)]
    public fileTypeType[] playsfiletypes {
        get {
            return this.playsfiletypesField;
        }
        set {
            this.playsfiletypesField = value;
        }
    }
    
    /// <remarks/>
    public bool enabled {
        get {
            return this.enabledField;
        }
        set {
            this.enabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool enabledSpecified {
        get {
            return this.enabledFieldSpecified;
        }
        set {
            this.enabledFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public urlElementType launchica {
        get {
            return this.launchicaField;
        }
        set {
            this.launchicaField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType launchrade {
        get {
            return this.launchradeField;
        }
        set {
            this.launchradeField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType image {
        get {
            return this.imageField;
        }
        set {
            this.imageField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType icon {
        get {
            return this.iconField;
        }
        set {
            this.iconField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType machinepoweroff {
        get {
            return this.machinepoweroffField;
        }
        set {
            this.machinepoweroffField = value;
        }
    }
    
    /// <remarks/>
    public bool featured {
        get {
            return this.featuredField;
        }
        set {
            this.featuredField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool featuredSpecified {
        get {
            return this.featuredFieldSpecified;
        }
        set {
            this.featuredFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool workflowenabled {
        get {
            return this.workflowenabledField;
        }
        set {
            this.workflowenabledField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool workflowenabledSpecified {
        get {
            return this.workflowenabledFieldSpecified;
        }
        set {
            this.workflowenabledFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool workflowwithoutclientinteraction {
        get {
            return this.workflowwithoutclientinteractionField;
        }
        set {
            this.workflowwithoutclientinteractionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool workflowwithoutclientinteractionSpecified {
        get {
            return this.workflowwithoutclientinteractionFieldSpecified;
        }
        set {
            this.workflowwithoutclientinteractionFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string imagehash {
        get {
            return this.imagehashField;
        }
        set {
            this.imagehashField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType accessonetimeticket {
        get {
            return this.accessonetimeticketField;
        }
        set {
            this.accessonetimeticketField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType followmedataaccess {
        get {
            return this.followmedataaccessField;
        }
        set {
            this.followmedataaccessField = value;
        }
    }
    
    /// <remarks/>
    public desktopInfoType desktopinfo {
        get {
            return this.desktopinfoField;
        }
        set {
            this.desktopinfoField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType assigndesktop {
        get {
            return this.assigndesktopField;
        }
        set {
            this.assigndesktopField = value;
        }
    }
    
    /// <remarks/>
    public bool aggregatedresource {
        get {
            return this.aggregatedresourceField;
        }
        set {
            this.aggregatedresourceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool aggregatedresourceSpecified {
        get {
            return this.aggregatedresourceFieldSpecified;
        }
        set {
            this.aggregatedresourceFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string publisherresourceid {
        get {
            return this.publisherresourceidField;
        }
        set {
            this.publisherresourceidField = value;
        }
    }
    
    /// <remarks/>
    public string publishername {
        get {
            return this.publishernameField;
        }
        set {
            this.publishernameField = value;
        }
    }
    
    /// <remarks/>
    public bool mandatory {
        get {
            return this.mandatoryField;
        }
        set {
            this.mandatoryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool mandatorySpecified {
        get {
            return this.mandatoryFieldSpecified;
        }
        set {
            this.mandatoryFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public urlElementType subscriptionactions {
        get {
            return this.subscriptionactionsField;
        }
        set {
            this.subscriptionactionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public string subscriptionstatus {
        get {
            return this.subscriptionstatusField;
        }
        set {
            this.subscriptionstatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public string subscriptionid {
        get {
            return this.subscriptionidField;
        }
        set {
            this.subscriptionidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType1[] subscriptiondata {
        get {
            return this.subscriptiondataField;
        }
        set {
            this.subscriptiondataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public string subscriptionquestionurl {
        get {
            return this.subscriptionquestionurlField;
        }
        set {
            this.subscriptionquestionurlField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public string subscriptionreasontext {
        get {
            return this.subscriptionreasontextField;
        }
        set {
            this.subscriptionreasontextField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public string subscriptionresponsereason {
        get {
            return this.subscriptionresponsereasonField;
        }
        set {
            this.subscriptionresponsereasonField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
[System.Xml.Serialization.XmlRootAttribute("subscriptionactions", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class urlElementType {
    
    private string urlField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string url {
        get {
            return this.urlField;
        }
        set {
            this.urlField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="propertyType", Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
public partial class propertyType1 {
    
    private string[] valueField;
    
    private string keyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("value")]
    public string[] value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public partial class desktopInfoType {
    
    private string hostnameField;
    
    private assignmentTypeType assignmenttypeField;
    
    /// <remarks/>
    public string hostname {
        get {
            return this.hostnameField;
        }
        set {
            this.hostnameField = value;
        }
    }
    
    /// <remarks/>
    public assignmentTypeType assignmenttype {
        get {
            return this.assignmenttypeField;
        }
        set {
            this.assignmenttypeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public enum assignmentTypeType {
    
    /// <remarks/>
    assigned,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("assign-on-first-use")]
    assignonfirstuse,
    
    /// <remarks/>
    shared,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public partial class fileTypeType {
    
    private string nameField;
    
    private string descriptionField;
    
    private string[] fileextensionsField;
    
    private string[] mimetypesField;
    
    private string parametersField;
    
    private bool isdefaultField;
    
    private bool isdefaultFieldSpecified;
    
    /// <remarks/>
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public string description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("fileextension", IsNullable=false)]
    public string[] fileextensions {
        get {
            return this.fileextensionsField;
        }
        set {
            this.fileextensionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("mimetype", IsNullable=false)]
    public string[] mimetypes {
        get {
            return this.mimetypesField;
        }
        set {
            this.mimetypesField = value;
        }
    }
    
    /// <remarks/>
    public string parameters {
        get {
            return this.parametersField;
        }
        set {
            this.parametersField = value;
        }
    }
    
    /// <remarks/>
    public bool isdefault {
        get {
            return this.isdefaultField;
        }
        set {
            this.isdefaultField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool isdefaultSpecified {
        get {
            return this.isdefaultFieldSpecified;
        }
        set {
            this.isdefaultFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public partial class imageType {
    
    private string sizeField;
    
    private string depthField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
    public string size {
        get {
            return this.sizeField;
        }
        set {
            this.sizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
    public string depth {
        get {
            return this.depthField;
        }
        set {
            this.depthField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public partial class propertyType {
    
    private string[] valueField;
    
    private string propertyIdField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("value")]
    public string[] value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string propertyId {
        get {
            return this.propertyIdField;
        }
        set {
            this.propertyIdField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public partial class radeType {
    
    private radeLicenseTypeType licenseTypeField;
    
    private bool licenseTypeFieldSpecified;
    
    private radeOfflineModeType offlineModeField;
    
    private bool offlineModeFieldSpecified;
    
    /// <remarks/>
    public radeLicenseTypeType licenseType {
        get {
            return this.licenseTypeField;
        }
        set {
            this.licenseTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool licenseTypeSpecified {
        get {
            return this.licenseTypeFieldSpecified;
        }
        set {
            this.licenseTypeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public radeOfflineModeType offlineMode {
        get {
            return this.offlineModeField;
        }
        set {
            this.offlineModeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool offlineModeSpecified {
        get {
            return this.offlineModeFieldSpecified;
        }
        set {
            this.offlineModeFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public enum radeLicenseTypeType {
    
    /// <remarks/>
    online,
    
    /// <remarks/>
    offline,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("online-streaming")]
    onlinestreaming,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("offline-streaming")]
    offlinestreaming,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public enum radeOfflineModeType {
    
    /// <remarks/>
    none,
    
    /// <remarks/>
    immediate,
    
    /// <remarks/>
    launch,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://citrix.com/delivery-services/2-0/resources")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources", IsNullable=false)]
public partial class resources {
    
    private resourceType[] resourceField;
    
    private enumerationResultType enumerationField;
    
    private bool enumerationFieldSpecified;
    
    private subscriptionsStatusType subscriptionsstatusField;
    
    private bool subscriptionsstatusFieldSpecified;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("resource")]
    public resourceType[] resource {
        get {
            return this.resourceField;
        }
        set {
            this.resourceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public enumerationResultType enumeration {
        get {
            return this.enumerationField;
        }
        set {
            this.enumerationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool enumerationSpecified {
        get {
            return this.enumerationFieldSpecified;
        }
        set {
            this.enumerationFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
    public subscriptionsStatusType subscriptionsstatus {
        get {
            return this.subscriptionsstatusField;
        }
        set {
            this.subscriptionsstatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool subscriptionsstatusSpecified {
        get {
            return this.subscriptionsstatusFieldSpecified;
        }
        set {
            this.subscriptionsstatusFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/resources")]
public enum enumerationResultType {
    
    /// <remarks/>
    full,
    
    /// <remarks/>
    partial,
    
    /// <remarks/>
    failed,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
public enum subscriptionsStatusType {
    
    /// <remarks/>
    disabled,
    
    /// <remarks/>
    enabled,
    
    /// <remarks/>
    unavailable,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://citrix.com/delivery-services/1-0/sessionstate")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://citrix.com/delivery-services/1-0/sessionstate", IsNullable=false)]
public partial class sessionState {
    
    private sessionType[] sessionsField;
    
    private enumerationResultType1 enumerationField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("session", IsNullable=false)]
    public sessionType[] sessions {
        get {
            return this.sessionsField;
        }
        set {
            this.sessionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public enumerationResultType1 enumeration {
        get {
            return this.enumerationField;
        }
        set {
            this.enumerationField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/1-0/sessionstate")]
public partial class sessionType {
    
    private string servertypeField;
    
    private urlElementType1 launchicaField;
    
    private string initialappField;
    
    private bool initialappresourceaggregatedField;
    
    private string initialappresourceidField;
    
    private string publishernameField;
    
    private string idField;
    
    /// <remarks/>
    public string servertype {
        get {
            return this.servertypeField;
        }
        set {
            this.servertypeField = value;
        }
    }
    
    /// <remarks/>
    public urlElementType1 launchica {
        get {
            return this.launchicaField;
        }
        set {
            this.launchicaField = value;
        }
    }
    
    /// <remarks/>
    public string initialapp {
        get {
            return this.initialappField;
        }
        set {
            this.initialappField = value;
        }
    }
    
    /// <remarks/>
    public bool initialappresourceaggregated {
        get {
            return this.initialappresourceaggregatedField;
        }
        set {
            this.initialappresourceaggregatedField = value;
        }
    }
    
    /// <remarks/>
    public string initialappresourceid {
        get {
            return this.initialappresourceidField;
        }
        set {
            this.initialappresourceidField = value;
        }
    }
    
    /// <remarks/>
    public string publishername {
        get {
            return this.publishernameField;
        }
        set {
            this.publishernameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="urlElementType", Namespace="http://citrix.com/delivery-services/1-0/sessionstate")]
public partial class urlElementType1 {
    
    private string urlField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string url {
        get {
            return this.urlField;
        }
        set {
            this.urlField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="enumerationResultType", Namespace="http://citrix.com/delivery-services/1-0/sessionstate")]
public enum enumerationResultType1 {
    
    /// <remarks/>
    full,
    
    /// <remarks/>
    partial,
    
    /// <remarks/>
    failed,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(TypeName="propertiesType", Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
[System.Xml.Serialization.XmlRootAttribute("data", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class propertiesType1 {
    
    private propertyType1[] propertyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("property")]
    public propertyType1[] property {
        get {
            return this.propertyField;
        }
        set {
            this.propertyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
[System.Xml.Serialization.XmlRootAttribute("subscription", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class subscriptionType {
    
    private string subscriptionidField;
    
    private string resourceidField;
    
    private string statusField;
    
    private propertyType1[] dataField;
    
    /// <remarks/>
    public string subscriptionid {
        get {
            return this.subscriptionidField;
        }
        set {
            this.subscriptionidField = value;
        }
    }
    
    /// <remarks/>
    public string resourceid {
        get {
            return this.resourceidField;
        }
        set {
            this.resourceidField = value;
        }
    }
    
    /// <remarks/>
    public string status {
        get {
            return this.statusField;
        }
        set {
            this.statusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType1[] data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
[System.Xml.Serialization.XmlRootAttribute("subscriptionConflict", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class subscriptionConflictType {
    
    private propertyType1[] dataField;
    
    private string reasonField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType1[] data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string reason {
        get {
            return this.reasonField;
        }
        set {
            this.reasonField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
[System.Xml.Serialization.XmlRootAttribute("subscriptions", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class subscriptionsType {
    
    private subscriptionType[] subscriptionField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("subscription")]
    public subscriptionType[] subscription {
        get {
            return this.subscriptionField;
        }
        set {
            this.subscriptionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
[System.Xml.Serialization.XmlRootAttribute("subscriptionupdatebyid", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class subscriptionUpdateByIdType {
    
    private string subscriptionidField;
    
    private propertyType1[] securitydataField;
    
    private string statusField;
    
    private propertyType1[] dataField;
    
    /// <remarks/>
    public string subscriptionid {
        get {
            return this.subscriptionidField;
        }
        set {
            this.subscriptionidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType1[] securitydata {
        get {
            return this.securitydataField;
        }
        set {
            this.securitydataField = value;
        }
    }
    
    /// <remarks/>
    public string status {
        get {
            return this.statusField;
        }
        set {
            this.statusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType1[] data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
[System.Xml.Serialization.XmlRootAttribute("subscriptionupdate", Namespace="http://citrix.com/delivery-services/2-0/subscriptions", IsNullable=false)]
public partial class subscriptionUpdateType {
    
    private propertyType1[] dataField;
    
    private string clientNameField;
    
    private string clientAddressField;
    
    private updateTypeType updateTypeField;
    
    private updateDataModeType updateDataModeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable=false)]
    public propertyType1[] data {
        get {
            return this.dataField;
        }
        set {
            this.dataField = value;
        }
    }
    
    /// <remarks/>
    public string clientName {
        get {
            return this.clientNameField;
        }
        set {
            this.clientNameField = value;
        }
    }
    
    /// <remarks/>
    public string clientAddress {
        get {
            return this.clientAddressField;
        }
        set {
            this.clientAddressField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public updateTypeType updateType {
        get {
            return this.updateTypeField;
        }
        set {
            this.updateTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public updateDataModeType updateDataMode {
        get {
            return this.updateDataModeField;
        }
        set {
            this.updateDataModeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
public enum updateTypeType {
    
    /// <remarks/>
    subscribe,
    
    /// <remarks/>
    unsubscribe,
    
    /// <remarks/>
    update,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://citrix.com/delivery-services/2-0/subscriptions")]
public enum updateDataModeType {
    
    /// <remarks/>
    merge,
    
    /// <remarks/>
    replace,
}
