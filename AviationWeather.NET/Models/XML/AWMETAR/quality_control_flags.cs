using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AviationWx.NET.Models.XML.AWMETAR
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class quality_control_flags
    {

        private string correctedField;

        private string autoField;

        private string auto_stationField;

        private string maintenance_indicator_onField;

        private string no_signalField;

        private string lightning_sensor_offField;

        private string freezing_rain_sensor_offField;

        private string present_weather_sensor_offField;

        /// <remarks/>
        public string corrected
        {
            get
            {
                return this.correctedField;
            }
            set
            {
                this.correctedField = value;
            }
        }

        /// <remarks/>
        public string auto
        {
            get
            {
                return this.autoField;
            }
            set
            {
                this.autoField = value;
            }
        }

        /// <remarks/>
        public string auto_station
        {
            get
            {
                return this.auto_stationField;
            }
            set
            {
                this.auto_stationField = value;
            }
        }

        /// <remarks/>
        public string maintenance_indicator_on
        {
            get
            {
                return this.maintenance_indicator_onField;
            }
            set
            {
                this.maintenance_indicator_onField = value;
            }
        }

        /// <remarks/>
        public string no_signal
        {
            get
            {
                return this.no_signalField;
            }
            set
            {
                this.no_signalField = value;
            }
        }

        /// <remarks/>
        public string lightning_sensor_off
        {
            get
            {
                return this.lightning_sensor_offField;
            }
            set
            {
                this.lightning_sensor_offField = value;
            }
        }

        /// <remarks/>
        public string freezing_rain_sensor_off
        {
            get
            {
                return this.freezing_rain_sensor_offField;
            }
            set
            {
                this.freezing_rain_sensor_offField = value;
            }
        }

        /// <remarks/>
        public string present_weather_sensor_off
        {
            get
            {
                return this.present_weather_sensor_offField;
            }
            set
            {
                this.present_weather_sensor_offField = value;
            }
        }
    }
}
