namespace BNolan.AviationWx.NET.Models.XML.Station
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class station
    {

        private string station_idField;

        private uint wmo_idField;

        private decimal latitudeField;

        private decimal longitudeField;

        private decimal elevation_mField;

        private string siteField;

        private string stateField;

        private string countryField;

        private stationsite_type site_typeField;

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
        public uint wmo_id
        {
            get
            {
                return this.wmo_idField;
            }
            set
            {
                this.wmo_idField = value;
            }
        }

        /// <remarks/>
        public decimal latitude
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
        public decimal longitude
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
        public decimal elevation_m
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
        public string site
        {
            get
            {
                return this.siteField;
            }
            set
            {
                this.siteField = value;
            }
        }

        /// <remarks/>
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public stationsite_type site_type
        {
            get
            {
                return this.site_typeField;
            }
            set
            {
                this.site_typeField = value;
            }
        }
    }
}
