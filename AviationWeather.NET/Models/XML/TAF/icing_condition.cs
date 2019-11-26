using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BNolan.AviationWx.NET.Models.XML.TAF
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class icing_condition
    {

        private string icing_intensityField;

        private int icing_min_alt_ft_aglField;

        private bool icing_min_alt_ft_aglFieldSpecified;

        private int icing_max_alt_ft_aglField;

        private bool icing_max_alt_ft_aglFieldSpecified;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string icing_intensity
        {
            get
            {
                return this.icing_intensityField;
            }
            set
            {
                this.icing_intensityField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int icing_min_alt_ft_agl
        {
            get
            {
                return this.icing_min_alt_ft_aglField;
            }
            set
            {
                this.icing_min_alt_ft_aglField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool icing_min_alt_ft_aglSpecified
        {
            get
            {
                return this.icing_min_alt_ft_aglFieldSpecified;
            }
            set
            {
                this.icing_min_alt_ft_aglFieldSpecified = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int icing_max_alt_ft_agl
        {
            get
            {
                return this.icing_max_alt_ft_aglField;
            }
            set
            {
                this.icing_max_alt_ft_aglField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool icing_max_alt_ft_aglSpecified
        {
            get
            {
                return this.icing_max_alt_ft_aglFieldSpecified;
            }
            set
            {
                this.icing_max_alt_ft_aglFieldSpecified = value;
            }
        }
    }
}
