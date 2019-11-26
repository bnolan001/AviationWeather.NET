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
    public partial class TAF
    {

        private string raw_textField;

        private string station_idField;

        private string issue_timeField;

        private string bulletin_timeField;

        private string valid_time_fromField;

        private string valid_time_toField;

        private string remarksField;

        private float latitudeField;

        private bool latitudeFieldSpecified;

        private float longitudeField;

        private bool longitudeFieldSpecified;

        private float elevation_mField;

        private bool elevation_mFieldSpecified;

        private forecast[] forecastField;

        /// <remarks/>
        public string raw_text
        {
            get
            {
                return this.raw_textField;
            }
            set
            {
                this.raw_textField = value;
            }
        }

        /// <remarks/>
        public string station_id
        {
            get
            {
                return this.station_idField;
            }
            set
            {
                this.station_idField = value;
            }
        }

        /// <remarks/>
        public string issue_time
        {
            get
            {
                return this.issue_timeField;
            }
            set
            {
                this.issue_timeField = value;
            }
        }

        /// <remarks/>
        public string bulletin_time
        {
            get
            {
                return this.bulletin_timeField;
            }
            set
            {
                this.bulletin_timeField = value;
            }
        }

        /// <remarks/>
        public string valid_time_from
        {
            get
            {
                return this.valid_time_fromField;
            }
            set
            {
                this.valid_time_fromField = value;
            }
        }

        /// <remarks/>
        public string valid_time_to
        {
            get
            {
                return this.valid_time_toField;
            }
            set
            {
                this.valid_time_toField = value;
            }
        }

        /// <remarks/>
        public string remarks
        {
            get
            {
                return this.remarksField;
            }
            set
            {
                this.remarksField = value;
            }
        }

        /// <remarks/>
        public float latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool latitudeSpecified
        {
            get
            {
                return this.latitudeFieldSpecified;
            }
            set
            {
                this.latitudeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool longitudeSpecified
        {
            get
            {
                return this.longitudeFieldSpecified;
            }
            set
            {
                this.longitudeFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float elevation_m
        {
            get
            {
                return this.elevation_mField;
            }
            set
            {
                this.elevation_mField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool elevation_mSpecified
        {
            get
            {
                return this.elevation_mFieldSpecified;
            }
            set
            {
                this.elevation_mFieldSpecified = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("forecast")]
        public forecast[] forecast
        {
            get
            {
                return this.forecastField;
            }
            set
            {
                this.forecastField = value;
            }
        }
    }
}
