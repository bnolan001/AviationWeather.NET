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
    public partial class sky_condition
    {

        private string sky_coverField;

        private int cloud_base_ft_aglField;

        private bool cloud_base_ft_aglFieldSpecified;

        private string cloud_typeField;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string sky_cover
        {
            get
            {
                return this.sky_coverField;
            }
            set
            {
                this.sky_coverField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public int cloud_base_ft_agl
        {
            get
            {
                return this.cloud_base_ft_aglField;
            }
            set
            {
                this.cloud_base_ft_aglField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool cloud_base_ft_aglSpecified
        {
            get
            {
                return this.cloud_base_ft_aglFieldSpecified;
            }
            set
            {
                this.cloud_base_ft_aglFieldSpecified = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string cloud_type
        {
            get
            {
                return this.cloud_typeField;
            }
            set
            {
                this.cloud_typeField = value;
            }
        }
    }
}
