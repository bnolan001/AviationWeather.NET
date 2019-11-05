using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BNolan.AviationWx.NET.Models.XML.AWMETAR
{
    [GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [SerializableAttribute()]
    [DebuggerStepThroughAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class METAR
    {

        private string raw_textField;

        private string station_idField;

        private string observation_timeField;

        private float latitudeField;

        private bool latitudeFieldSpecified;

        private float longitudeField;

        private bool longitudeFieldSpecified;

        private float temp_cField;

        private bool temp_cFieldSpecified;

        private float dewpoint_cField;

        private bool dewpoint_cFieldSpecified;

        private int wind_dir_degreesField;

        private bool wind_dir_degreesFieldSpecified;

        private int wind_speed_ktField;

        private bool wind_speed_ktFieldSpecified;

        private int wind_gust_ktField;

        private bool wind_gust_ktFieldSpecified;

        private float visibility_statute_miField;

        private bool visibility_statute_miFieldSpecified;

        private float altim_in_hgField;

        private bool altim_in_hgFieldSpecified;

        private float sea_level_pressure_mbField;

        private bool sea_level_pressure_mbFieldSpecified;

        private quality_control_flags quality_control_flagsField;

        private string wx_stringField;

        private sky_condition[] sky_conditionField;

        private string flight_categoryField;

        private float three_hr_pressure_tendency_mbField;

        private bool three_hr_pressure_tendency_mbFieldSpecified;

        private float maxT_cField;

        private bool maxT_cFieldSpecified;

        private float minT_cField;

        private bool minT_cFieldSpecified;

        private float maxT24hr_cField;

        private bool maxT24hr_cFieldSpecified;

        private float minT24hr_cField;

        private bool minT24hr_cFieldSpecified;

        private float precip_inField;

        private bool precip_inFieldSpecified;

        private float pcp3hr_inField;

        private bool pcp3hr_inFieldSpecified;

        private float pcp6hr_inField;

        private bool pcp6hr_inFieldSpecified;

        private float pcp24hr_inField;

        private bool pcp24hr_inFieldSpecified;

        private float snow_inField;

        private bool snow_inFieldSpecified;

        private int vert_vis_ftField;

        private bool vert_vis_ftFieldSpecified;

        private string metar_typeField;

        private float elevation_mField;

        private bool elevation_mFieldSpecified;

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
        public string observation_time
        {
            get
            {
                return this.observation_timeField;
            }
            set
            {
                this.observation_timeField = value;
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
        public float temp_c
        {
            get
            {
                return this.temp_cField;
            }
            set
            {
                this.temp_cField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool temp_cSpecified
        {
            get
            {
                return this.temp_cFieldSpecified;
            }
            set
            {
                this.temp_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float dewpoint_c
        {
            get
            {
                return this.dewpoint_cField;
            }
            set
            {
                this.dewpoint_cField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool dewpoint_cSpecified
        {
            get
            {
                return this.dewpoint_cFieldSpecified;
            }
            set
            {
                this.dewpoint_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int wind_dir_degrees
        {
            get
            {
                return this.wind_dir_degreesField;
            }
            set
            {
                this.wind_dir_degreesField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool wind_dir_degreesSpecified
        {
            get
            {
                return this.wind_dir_degreesFieldSpecified;
            }
            set
            {
                this.wind_dir_degreesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int wind_speed_kt
        {
            get
            {
                return this.wind_speed_ktField;
            }
            set
            {
                this.wind_speed_ktField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool wind_speed_ktSpecified
        {
            get
            {
                return this.wind_speed_ktFieldSpecified;
            }
            set
            {
                this.wind_speed_ktFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int wind_gust_kt
        {
            get
            {
                return this.wind_gust_ktField;
            }
            set
            {
                this.wind_gust_ktField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool wind_gust_ktSpecified
        {
            get
            {
                return this.wind_gust_ktFieldSpecified;
            }
            set
            {
                this.wind_gust_ktFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float visibility_statute_mi
        {
            get
            {
                return this.visibility_statute_miField;
            }
            set
            {
                this.visibility_statute_miField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool visibility_statute_miSpecified
        {
            get
            {
                return this.visibility_statute_miFieldSpecified;
            }
            set
            {
                this.visibility_statute_miFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float altim_in_hg
        {
            get
            {
                return this.altim_in_hgField;
            }
            set
            {
                this.altim_in_hgField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool altim_in_hgSpecified
        {
            get
            {
                return this.altim_in_hgFieldSpecified;
            }
            set
            {
                this.altim_in_hgFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float sea_level_pressure_mb
        {
            get
            {
                return this.sea_level_pressure_mbField;
            }
            set
            {
                this.sea_level_pressure_mbField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool sea_level_pressure_mbSpecified
        {
            get
            {
                return this.sea_level_pressure_mbFieldSpecified;
            }
            set
            {
                this.sea_level_pressure_mbFieldSpecified = value;
            }
        }

        /// <remarks/>
        public quality_control_flags quality_control_flags
        {
            get
            {
                return this.quality_control_flagsField;
            }
            set
            {
                this.quality_control_flagsField = value;
            }
        }

        /// <remarks/>
        public string wx_string
        {
            get
            {
                return this.wx_stringField;
            }
            set
            {
                this.wx_stringField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("sky_condition")]
        public sky_condition[] sky_condition
        {
            get
            {
                return this.sky_conditionField;
            }
            set
            {
                this.sky_conditionField = value;
            }
        }

        /// <remarks/>
        public string flight_category
        {
            get
            {
                return this.flight_categoryField;
            }
            set
            {
                this.flight_categoryField = value;
            }
        }

        /// <remarks/>
        public float three_hr_pressure_tendency_mb
        {
            get
            {
                return this.three_hr_pressure_tendency_mbField;
            }
            set
            {
                this.three_hr_pressure_tendency_mbField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool three_hr_pressure_tendency_mbSpecified
        {
            get
            {
                return this.three_hr_pressure_tendency_mbFieldSpecified;
            }
            set
            {
                this.three_hr_pressure_tendency_mbFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float maxT_c
        {
            get
            {
                return this.maxT_cField;
            }
            set
            {
                this.maxT_cField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool maxT_cSpecified
        {
            get
            {
                return this.maxT_cFieldSpecified;
            }
            set
            {
                this.maxT_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float minT_c
        {
            get
            {
                return this.minT_cField;
            }
            set
            {
                this.minT_cField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool minT_cSpecified
        {
            get
            {
                return this.minT_cFieldSpecified;
            }
            set
            {
                this.minT_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float maxT24hr_c
        {
            get
            {
                return this.maxT24hr_cField;
            }
            set
            {
                this.maxT24hr_cField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool maxT24hr_cSpecified
        {
            get
            {
                return this.maxT24hr_cFieldSpecified;
            }
            set
            {
                this.maxT24hr_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float minT24hr_c
        {
            get
            {
                return this.minT24hr_cField;
            }
            set
            {
                this.minT24hr_cField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool minT24hr_cSpecified
        {
            get
            {
                return this.minT24hr_cFieldSpecified;
            }
            set
            {
                this.minT24hr_cFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float precip_in
        {
            get
            {
                return this.precip_inField;
            }
            set
            {
                this.precip_inField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool precip_inSpecified
        {
            get
            {
                return this.precip_inFieldSpecified;
            }
            set
            {
                this.precip_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float pcp3hr_in
        {
            get
            {
                return this.pcp3hr_inField;
            }
            set
            {
                this.pcp3hr_inField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool pcp3hr_inSpecified
        {
            get
            {
                return this.pcp3hr_inFieldSpecified;
            }
            set
            {
                this.pcp3hr_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float pcp6hr_in
        {
            get
            {
                return this.pcp6hr_inField;
            }
            set
            {
                this.pcp6hr_inField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool pcp6hr_inSpecified
        {
            get
            {
                return this.pcp6hr_inFieldSpecified;
            }
            set
            {
                this.pcp6hr_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float pcp24hr_in
        {
            get
            {
                return this.pcp24hr_inField;
            }
            set
            {
                this.pcp24hr_inField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool pcp24hr_inSpecified
        {
            get
            {
                return this.pcp24hr_inFieldSpecified;
            }
            set
            {
                this.pcp24hr_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public float snow_in
        {
            get
            {
                return this.snow_inField;
            }
            set
            {
                this.snow_inField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool snow_inSpecified
        {
            get
            {
                return this.snow_inFieldSpecified;
            }
            set
            {
                this.snow_inFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int vert_vis_ft
        {
            get
            {
                return this.vert_vis_ftField;
            }
            set
            {
                this.vert_vis_ftField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool vert_vis_ftSpecified
        {
            get
            {
                return this.vert_vis_ftFieldSpecified;
            }
            set
            {
                this.vert_vis_ftFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string metar_type
        {
            get
            {
                return this.metar_typeField;
            }
            set
            {
                this.metar_typeField = value;
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
    }
}
