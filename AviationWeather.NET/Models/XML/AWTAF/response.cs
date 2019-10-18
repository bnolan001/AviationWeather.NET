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
    public partial class response
    {

        private int request_indexField;

        private data_source data_sourceField;

        private request requestField;

        private errors errorsField;

        private warnings warningsField;

        private int time_taken_msField;

        private data dataField;

        private string versionField;

        public response()
        {
            this.versionField = "1.2";
        }

        /// <remarks/>
        public int request_index
        {
            get
            {
                return this.request_indexField;
            }
            set
            {
                this.request_indexField = value;
            }
        }

        /// <remarks/>
        public data_source data_source
        {
            get
            {
                return this.data_sourceField;
            }
            set
            {
                this.data_sourceField = value;
            }
        }

        /// <remarks/>
        public request request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        public errors errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }

        /// <remarks/>
        public warnings warnings
        {
            get
            {
                return this.warningsField;
            }
            set
            {
                this.warningsField = value;
            }
        }

        /// <remarks/>
        public int time_taken_ms
        {
            get
            {
                return this.time_taken_msField;
            }
            set
            {
                this.time_taken_msField = value;
            }
        }

        /// <remarks/>
        public data data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        [DefaultValueAttribute("1.2")]
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }
}
