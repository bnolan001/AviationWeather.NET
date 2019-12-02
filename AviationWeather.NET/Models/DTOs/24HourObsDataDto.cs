using System;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class TwentyFourHourObsDataDto : TemperatureRangeDto
    {
        /// <summary>
        /// Total precipitation recorded over the previous 24 hours.  Measurement
        /// is in inches.
        /// </summary>
        public float? Precipitation { get; set; }
    }
}
