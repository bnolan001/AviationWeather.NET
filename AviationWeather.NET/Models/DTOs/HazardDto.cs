using BNolan.AviationWx.NET.Models.Enums.Interfaces;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class HazardDto
    {
        /// <summary>
        /// Intensity of the reported hazard
        /// </summary>
        public IHazardIntensity Intensity { get; set; }

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
