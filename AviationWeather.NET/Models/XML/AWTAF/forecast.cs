using BNolan.AviationWx.NET.Models.DTOs;
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
    public partial class forecast
    {

        private string fcst_time_fromField;

        private string fcst_time_toField;

        private string change_indicatorField;

        private string time_becomingField;

        private int probabilityField;

        private bool probabilityFieldSpecified;

        private short wind_dir_degreesField;

        private bool wind_dir_degreesFieldSpecified;

        private int wind_speed_ktField;

        private bool wind_speed_ktFieldSpecified;

        private int wind_gust_ktField;

        private bool wind_gust_ktFieldSpecified;

        private short wind_shear_hgt_ft_aglField;

        private bool wind_shear_hgt_ft_aglFieldSpecified;

        private short wind_shear_dir_degreesField;

        private bool wind_shear_dir_degreesFieldSpecified;

        private int wind_shear_speed_ktField;

        private bool wind_shear_speed_ktFieldSpecified;

        private float visibility_statute_miField;

        private bool visibility_statute_miFieldSpecified;

        private float altim_in_hgField;

        private bool altim_in_hgFieldSpecified;

        private short vert_vis_ftField;

        private bool vert_vis_ftFieldSpecified;

        private string wx_stringField;

        private string not_decodedField;

        private sky_condition[] sky_conditionField;

        private turbulence_condition[] turbulence_conditionField;

        private icing_condition[] icing_conditionField;

        private temperature[] temperatureField;

        /// <remarks/>
        public string fcst_time_from
        {
            get
            {
                return this.fcst_time_fromField;
            }
            set
            {
                this.fcst_time_fromField = value;
            }
        }

        /// <remarks/>
        public string fcst_time_to
        {
            get
            {
                return this.fcst_time_toField;
            }
            set
            {
                this.fcst_time_toField = value;
            }
        }

        /// <remarks/>
        public string change_indicator
        {
            get
            {
                return this.change_indicatorField;
            }
            set
            {
                this.change_indicatorField = value;
            }
        }

        /// <remarks/>
        public string time_becoming
        {
            get
            {
                return this.time_becomingField;
            }
            set
            {
                this.time_becomingField = value;
            }
        }

        /// <remarks/>
        public int probability
        {
            get
            {
                return this.probabilityField;
            }
            set
            {
                this.probabilityField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool probabilitySpecified
        {
            get
            {
                return this.probabilityFieldSpecified;
            }
            set
            {
                this.probabilityFieldSpecified = value;
            }
        }

        /// <remarks/>
        public short wind_dir_degrees
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

        internal object Select(IcingDto icingDto)
        {
            throw new NotImplementedException();
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
        public short wind_shear_hgt_ft_agl
        {
            get
            {
                return this.wind_shear_hgt_ft_aglField;
            }
            set
            {
                this.wind_shear_hgt_ft_aglField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool wind_shear_hgt_ft_aglSpecified
        {
            get
            {
                return this.wind_shear_hgt_ft_aglFieldSpecified;
            }
            set
            {
                this.wind_shear_hgt_ft_aglFieldSpecified = value;
            }
        }

        /// <remarks/>
        public short wind_shear_dir_degrees
        {
            get
            {
                return this.wind_shear_dir_degreesField;
            }
            set
            {
                this.wind_shear_dir_degreesField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool wind_shear_dir_degreesSpecified
        {
            get
            {
                return this.wind_shear_dir_degreesFieldSpecified;
            }
            set
            {
                this.wind_shear_dir_degreesFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int wind_shear_speed_kt
        {
            get
            {
                return this.wind_shear_speed_ktField;
            }
            set
            {
                this.wind_shear_speed_ktField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool wind_shear_speed_ktSpecified
        {
            get
            {
                return this.wind_shear_speed_ktFieldSpecified;
            }
            set
            {
                this.wind_shear_speed_ktFieldSpecified = value;
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
        public short vert_vis_ft
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
        public string not_decoded
        {
            get
            {
                return this.not_decodedField;
            }
            set
            {
                this.not_decodedField = value;
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
        [XmlElementAttribute("turbulence_condition")]
        public turbulence_condition[] turbulence_condition
        {
            get
            {
                return this.turbulence_conditionField;
            }
            set
            {
                this.turbulence_conditionField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("icing_condition")]
        public icing_condition[] icing_condition
        {
            get
            {
                return this.icing_conditionField;
            }
            set
            {
                this.icing_conditionField = value;
            }
        }

        /// <remarks/>
        [XmlElementAttribute("temperature")]
        public temperature[] temperature
        {
            get
            {
                return this.temperatureField;
            }
            set
            {
                this.temperatureField = value;
            }
        }
    }
}
