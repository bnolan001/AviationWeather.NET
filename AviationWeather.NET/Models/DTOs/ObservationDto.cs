using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class ObservationDto
    {
        public string ICAO { get; set; }

        public List<METARDto> METAR { get; set; }

        public GeographicDataDto GeographicData { get; set; }

        public ObservationDto()
        {
            METAR = new List<METARDto>();
        }
    }
}
