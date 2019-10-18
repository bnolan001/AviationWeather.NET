using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AviationWx.NET.Models.XML.AWMETAR
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class data
    {

        private METAR[] mETARField;

        private int num_resultsField;

        private bool num_resultsFieldSpecified;

        /// <remarks/>
        [XmlElementAttribute("METAR")]
        public METAR[] METAR
        {
            get
            {
                return this.mETARField;
            }
            set
            {
                this.mETARField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int num_results
        {
            get
            {
                return this.num_resultsField;
            }
            set
            {
                this.num_resultsField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool num_resultsSpecified
        {
            get
            {
                return this.num_resultsFieldSpecified;
            }
            set
            {
                this.num_resultsFieldSpecified = value;
            }
        }
    }
}
