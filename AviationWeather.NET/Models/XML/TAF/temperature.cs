using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;


[GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[SerializableAttribute()]
[DebuggerStepThroughAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
[XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class temperature {
    
    private string valid_timeField;
    
    private float sfc_temp_cField;
    
    private bool sfc_temp_cFieldSpecified;
    
    private string max_temp_cField;
    
    private string min_temp_cField;
    
    /// <remarks/>
    public string valid_time {
        get {
            return this.valid_timeField;
        }
        set {
            this.valid_timeField = value;
        }
    }
    
    /// <remarks/>
    public float sfc_temp_c {
        get {
            return this.sfc_temp_cField;
        }
        set {
            this.sfc_temp_cField = value;
        }
    }
    
    /// <remarks/>
    [XmlIgnoreAttribute()]
    public bool sfc_temp_cSpecified {
        get {
            return this.sfc_temp_cFieldSpecified;
        }
        set {
            this.sfc_temp_cFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string max_temp_c {
        get {
            return this.max_temp_cField;
        }
        set {
            this.max_temp_cField = value;
        }
    }
    
    /// <remarks/>
    public string min_temp_c {
        get {
            return this.min_temp_cField;
        }
        set {
            this.min_temp_cField = value;
        }
    }
}
