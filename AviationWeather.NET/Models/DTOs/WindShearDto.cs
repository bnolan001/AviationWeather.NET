namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class WindShearDto
    {
        /// <summary>
        /// Height of the wind shear, measured in Feet.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Direction the wind is blowing from, measured in degrees.
        /// </summary>
        public int? Direction { get; set; }

        /// <summary>
        /// Wind speed measured in Knots.
        /// </summary>
        public int? Speed { get; set; }
    }
}
