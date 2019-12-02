namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class WindDto
    {
        /// <summary>
        /// Direction the wind is blowing from, measured in degrees.
        /// </summary>
        public int? Direction { get; set; }

        /// <summary>
        /// Wind speed measured in Knots.
        /// </summary>
        public int? Speed { get; set; }

        /// <summary>
        /// Wind speed gust measured in Knots.
        /// </summary>
        public int? Gust { get; set; }
    }
}
