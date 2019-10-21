using AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationWx.NET.Models.DTOs
{
    public class TAFLineDto
    {
        public DateTime ForecastTimeStart { get; set; }

        public DateTime ForecastTimeEnd { get; set; }

        public ForecastType ForecastType { get; set; }

        public DateTime TimeBecoming { get; set; }

        public int? Probability { get; set; }

        public WindDto Wind { get; set; }

        public WindShearDto WindShear { get; set; }

        public float? Visibility_SM { get; set; }

        public float? Altimeter_Hg { get; set; }

        public int? VerticalVisibility_Ft { get; set; }

        public string Weather { get; set; }

        public string NotDecoded { get; set; }

        public List<IcingDto> IcingHazards { get; set; }

        public List<TurbulenceDto> TurbulenceHazards { get; set; }

        public List<SkyConditionDto> SkyCondition { get; set; }

        public float? SurfaceTemperature_C { get; set; }

        public TemperatureRangeDto TemperatureRange { get; set; }

        public TAFLineDto()
        {
            IcingHazards = new List<IcingDto>();
            TurbulenceHazards = new List<TurbulenceDto>();
            SkyCondition = new List<SkyConditionDto>();
        }
    }
}
