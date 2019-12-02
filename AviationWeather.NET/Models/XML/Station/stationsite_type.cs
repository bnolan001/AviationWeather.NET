namespace BNolan.AviationWx.NET.Models.XML.Station
{
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseDataStationSite_type
    {

        private object mETARField;

        private object tAFField;

        private object rawinsondeField;

        private object nEXRADField;

        private object wind_profilerField;

        private object wFO_officeField;

        private object sYNOPSField;

        /// <remarks/>
        public object METAR
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
        public object TAF
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
        public object rawinsonde
        {
            get
            {
                return this.rawinsondeField;
            }
            set
            {
                this.rawinsondeField = value;
            }
        }

        /// <remarks/>
        public object NEXRAD
        {
            get
            {
                return this.nEXRADField;
            }
            set
            {
                this.nEXRADField = value;
            }
        }

        /// <remarks/>
        public object wind_profiler
        {
            get
            {
                return this.wind_profilerField;
            }
            set
            {
                this.wind_profilerField = value;
            }
        }

        /// <remarks/>
        public object WFO_office
        {
            get
            {
                return this.wFO_officeField;
            }
            set
            {
                this.wFO_officeField = value;
            }
        }

        /// <remarks/>
        public object SYNOPS
        {
            get
            {
                return this.sYNOPSField;
            }
            set
            {
                this.sYNOPSField = value;
            }
        }
    }
}
