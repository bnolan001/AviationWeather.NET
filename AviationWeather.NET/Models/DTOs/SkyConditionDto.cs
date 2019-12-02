using BNolan.AviationWx.NET.Models.Enums;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class SkyConditionDto
    {
        public SkyConditionType SkyCondition { get; set; }

        /// <summary>
        /// Minimum height of the cloud layer, measured in feet.
        /// </summary>
        public int CloudBase { get; set; }
    }
}
