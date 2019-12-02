using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using System;
using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class TAFLineDto
    {
        private List<HazardDto> _iHazards;

        private List<HazardDto> _tHazards;

        private List<SkyConditionDto> _sConditions;

        public DateTimeOffset ForecastTimeStart { get; set; }

        public DateTimeOffset ForecastTimeEnd { get; set; }

        public ChangeIndicatorType ChangeIndicator { get; set; }

        public DateTimeOffset TimeBecoming { get; set; }

        public int? Probability { get; set; }

        public WindDto Wind { get; set; }

        public WindShearDto WindShear { get; set; }

        /// <summary>
        /// Predominant visibility in Statute Miles.
        /// </summary>
        public float? Visibility { get; set; }

        /// <summary>
        /// Altimeter in inches mercury.
        /// </summary>
        public float? Altimeter { get; set; }

        /// <summary>
        /// Distance visible vertically into an undefined ceiling.  Measurement
        /// is in feet.
        /// </summary>
        public int? VerticalVisibility { get; set; }

        public string Weather { get; set; }

        public string NotDecoded { get; set; }

        public List<HazardDto> IcingHazards { get => _iHazards; }

        public List<HazardDto> TurbulenceHazards { get => _tHazards; }

        public List<SkyConditionDto> SkyCondition { get => _sConditions;}

        /// <summary>
        /// Temperature in degrees Celcius
        /// </summary>
        public float? Temperature { get; set; }

        public TemperatureRangeDto TemperatureRange { get; set; }

        public TAFLineDto()
        {
            _iHazards = new List<HazardDto>();
            _tHazards = new List<HazardDto>();
            _sConditions = new List<SkyConditionDto>();
            ForecastTimeStart = ParserConstants.DefaultDateTime;
        }
    }
}
