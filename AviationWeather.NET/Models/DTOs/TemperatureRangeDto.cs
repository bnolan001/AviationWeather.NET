using System;

namespace AviationWx.NET.Models.DTOs
{
    public class TemperatureRangeDto
    {
        public Nullable<float> MaxTemperature_C { get; set; }

        public Nullable<float> MinTemperature_C { get; set; }
    }
}
