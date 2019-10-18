using AviationWx.NET.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationWx.NET.Models.DTOs
{
    public class ObservationDto
    {
        public string ICAO { get; set; }

        public List<METARDto> METAR { get; set; }

        public ObservationDto()
        {
            METAR = new List<METARDto>();
        }
    }
}
