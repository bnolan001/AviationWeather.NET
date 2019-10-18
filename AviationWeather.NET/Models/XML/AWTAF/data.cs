using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AviationWx.NET.Models.XML.AWTAF
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class data
    {

        private TAF[] tAFField;

        private int num_resultsField;

        private bool num_resultsFieldSpecified;

        /// <remarks/>
        [XmlElementAttribute("TAF")]
        public TAF[] TAF
        {
            get
            {
                return this.tAFField;
            }
            set
            {
                this.tAFField = value;
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
