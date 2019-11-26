namespace BNolan.AviationWx.NET.Models.XML.Station
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class stationsite_type
    {

        private object mETARField;

        private object tAFField;

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
    }
}
