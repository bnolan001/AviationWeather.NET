using System;
using System.Collections.Generic;

namespace AviationWx.NET.Models.DTOs
{
    public class TAFDto
    {
        public string RawTAF { get; set; }

        public DateTime IssuedTime { get; set; }

        public DateTime BulletinTime { get; set; }

        public DateTime ValidTimeStart { get; set; }

        public DateTime ValidTimeEnd { get; set; }

        public string Remarks { get; set; }

        public List<TAFLineDto> Forecast { get; set; }

        public TAFDto()
        {
            Forecast = new List<TAFLineDto>();
        }
    }
}
