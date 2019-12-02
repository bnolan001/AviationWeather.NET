using System;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class TemperatureRangeDto
    {
        /// <summary>
        /// Maximum temperature in degrees Celcius.
        /// </summary>
        public float? MaxTemperature { get; set; }

        /// <summary>
        /// Minimum temperature in degrees Celcius.
        /// </summary>
        public float? MinTemperature { get; set; }
    }
}
