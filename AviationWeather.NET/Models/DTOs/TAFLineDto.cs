using AviationWx.NET.Models.Enums;
using AviationWx.NET.Parsers;
using System;
using System.Collections.Generic;

namespace AviationWx.NET.Models.DTOs
{
    public class TAFLineDto
    {
        public DateTimeOffset ForecastTimeStart { get; set; }

        public DateTimeOffset ForecastTimeEnd { get; set; }

        public ChangeIndicatorType ForecastType { get; set; }

        public DateTimeOffset TimeBecoming { get; set; }

        public int? Probability { get; set; }

        public WindDto Wind { get; set; }

        public WindShearDto WindShear { get; set; }

        public Nullable<float> Visibility_SM { get; set; }

        public Nullable<float> Altimeter_Hg { get; set; }

        public int? VerticalVisibility_Ft { get; set; }

        public string Weather { get; set; }

        public string NotDecoded { get; set; }

        public List<IcingDto> IcingHazards { get; set; }

        public List<TurbulenceDto> TurbulenceHazards { get; set; }

        public List<SkyConditionDto> SkyCondition { get; set; }

        public Nullable<float> SurfaceTemperature_C { get; set; }

        public TemperatureRangeDto TemperatureRange { get; set; }

        public TAFLineDto()
        {
            IcingHazards = new List<IcingDto>();
            TurbulenceHazards = new List<TurbulenceDto>();
            SkyCondition = new List<SkyConditionDto>();
            ForecastTimeStart = ParserConstants.DefaultDateTime;
        }
    }
}
