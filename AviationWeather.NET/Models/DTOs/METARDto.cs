using BNolan.AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class METARDto
    {
        private List<SkyConditionDto> _skyCondition;
        private List<QualityControlFlagType> _qcFlags;

        public DateTimeOffset ObsTime { get; set; }

        public string RawMETAR { get; set; }

        /// <summary>
        /// Temperature measured in degrees Celcius.
        /// </summary>
        public float? Temperature { get; set; }

        /// <summary>
        /// Dewpoint measured in degrees Celcius.
        /// </summary>
        public float? Dewpoint { get; set; }

        public WindDto Wind { get; set; }

        /// <summary>
        /// Predominant visibility in Statute Miles.
        /// </summary>
        public float? Visibility { get; set; }

        /// <summary>
        /// Altimeter in inches mercury.
        /// </summary>
        public float? Altimeter { get; set; }

        /// <summary>
        /// The atmospheric pressure of the station it if was located at sea level, 
        /// measured in millibars.
        /// </summary>
        public float? SeaLevelPressure { get; set; }

        public List<SkyConditionDto> SkyCondition { get => _skyCondition; }

        public FlightCategoryType FlightCagegory { get; set; }

        /// <summary>
        /// Total precipitation recorded over the previous hour.  Measurement
        /// is in inches.
        /// </summary>
        public float? Precipitation { get; set; }

        /// <summary>
        /// Total snowfall recorded over the previous hour.  Measurement 
        /// is in inches.
        /// </summary>
        public float? Snow { get; set; }

        public string Weather { get; set; }
        
        /// <summary>
        /// Distance visible vertically into an undefined ceiling.  Measurement
        /// is in feet.
        /// </summary>
        public int? VerticalVisibility { get; set; }

        public ThreeHourObsData ThreeHourObsData { get; set; }

        public SixHourObsDataDto SixHourData { get; set; }

        public TwentyFourHourObsDataDto TwentyFourHourData { get; set; }
        
        public List<QualityControlFlagType> QualityControlFlags { get => _qcFlags; }

        public TemperatureRangeDto TemperatureRange { get; set; }

        public METARType ObsType { get; set; }

        public METARDto()
        {
            _skyCondition = new List<SkyConditionDto>();
            _qcFlags = new List<QualityControlFlagType>();
        }
    }
}
