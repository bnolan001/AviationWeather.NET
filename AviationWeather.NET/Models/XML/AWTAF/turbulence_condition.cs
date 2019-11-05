using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BNolan.AviationWx.NET.Models.XML.AWTAF
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class turbulence_condition
    {

        private string turbulence_intensityField;

        private int turbulence_min_alt_ft_aglField;

        private bool turbulence_min_alt_ft_aglFieldSpecified;

        private int turbulence_max_alt_ft_aglField;

        private bool turbulence_max_alt_ft_aglFieldSpecified;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string turbulence_intensity
        {
            get
            {
                return this.turbulence_intensityField;
            }
            set
            {
                this.turbulence_intensityField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int turbulence_min_alt_ft_agl
        {
            get
            {
                return this.turbulence_min_alt_ft_aglField;
            }
            set
            {
                this.turbulence_min_alt_ft_aglField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool turbulence_min_alt_ft_aglSpecified
        {
            get
            {
                return this.turbulence_min_alt_ft_aglFieldSpecified;
            }
            set
            {
                this.turbulence_min_alt_ft_aglFieldSpecified = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int turbulence_max_alt_ft_agl
        {
            get
            {
                return this.turbulence_max_alt_ft_aglField;
            }
            set
            {
                this.turbulence_max_alt_ft_aglField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool turbulence_max_alt_ft_aglSpecified
        {
            get
            {
                return this.turbulence_max_alt_ft_aglFieldSpecified;
            }
            set
            {
                this.turbulence_max_alt_ft_aglFieldSpecified = value;
            }
        }
    }
}
