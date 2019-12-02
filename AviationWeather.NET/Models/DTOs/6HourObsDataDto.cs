namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class SixHourObsDataDto
    {
        /// <summary>
        /// Total precipitation recorded over the previous six hours.  Measurement
        /// is in inches.
        /// </summary>
        public float? Precipitation { get; set; }
    }
}
