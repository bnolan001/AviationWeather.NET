using BNolan.AviationWx.NET.Models.Enums;
using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Models.DTOs
{
    public class StationInfoDto
    {
        private List<SiteType> _sType;

        public string Name { get; set; }

        public string ICAO { get; set; }

        public int? WMOID { get; set; }

        public GeographicDataDto GeographicData { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public List<SiteType> SiteType { get => _sType; }

        public StationInfoDto()
        {
            _sType = new List<SiteType>();
        }
    }
}
