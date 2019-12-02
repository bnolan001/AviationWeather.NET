namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class HazardDto
    {
        public string Intensity { get; set; }

        /// <summary>
        /// Lowest altitude where icing can be expected.  Measured in feet.
        /// </summary>
        public int MinAltitude { get; set; }

        /// <summary>
        /// Highest altitude where icing can be expected.  Measured in feet.
        /// </summary>
        public int MaxAltitude { get; set; }
    }
}
