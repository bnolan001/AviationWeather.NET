using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Models.XML.Station
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseData
    {

        private responseDataStation[] stationField;

        private uint num_resultsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Station")]
        public responseDataStation[] Station
        {
            get
            {
                return this.stationField;
            }
            set
            {
                this.stationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint num_results
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
    }
}









