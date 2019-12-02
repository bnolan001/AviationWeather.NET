using System;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class ThreeHourObsData
    {
        /// <summary>
        /// Three hour pressure tendancy.  Measurement in millibars.
        /// </summary>
        public float? PressureTendency { get; set; }

        /// <summary>
        /// Total precipitation recorded over the previous three hours.  Measurement
        /// is in inches.
        /// </summary>
        public float? Precipitation { get; set; }

    }
}
