using AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;

namespace AviationWx.NET.Models.DTOs
{
    public class METARDto
    {

        public DateTime ObsTime { get; set; }

        public string RawMETAR { get; set; }

        public float Temperature_C { get; set; }

        public float Dewpoint_C { get; set; }

        public int WindDirection_D { get; set; }

        public int WindSpeed_Kt { get; set; }

        public int? WindGust_Kt { get; set; }

        public float Visibility_SM { get; set; }

        public float Altimeter_Hg { get; set; }

        public float SeaLevelPressure_Mb { get; set; }

        public List<SkyConditionDto> SkyCondition { get; set; }

        public FlightCategoryType FlightCagegory { get; set; }

        public Nullable<float> Precipitation_In { get; set; }

        public string Weather { get; set; }

        public GeographicData GeographicData { get; set; }

        public int? VerticalVisibility_Ft { get; set; }

        public _3HourObsData _3HourObsData { get; set; }

        public _6HourObsDataDto _6HourData { get; set; }

        public _24HourObsDataDto _24HourData { get; set; }
        
        public List<QualityControlFlagType> QualityControlFlags { get; set; }

        public METARDto()
        {
            SkyCondition = new List<SkyConditionDto>();
            QualityControlFlags = new List<QualityControlFlagType>();
        }
    }
}
