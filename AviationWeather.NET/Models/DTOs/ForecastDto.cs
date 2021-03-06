﻿using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class ForecastDto
    {
        public string ICAO { get; set; }

        public List<TAFDto> TAF { get; set; }

        public GeographicDataDto GeographicData { get; set; }

        public ForecastDto()
        {
            TAF = new List<TAFDto>();
        }
    }
}
