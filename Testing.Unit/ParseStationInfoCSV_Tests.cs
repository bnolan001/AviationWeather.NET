using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using Testing.Unit.Data;

namespace Testing.Unit
{
    public class ParseStationInfoCSV_Tests
    {

        [Test]
        public void Parse_MultipleStations()
        {
            var parser = new ParseStationInfoCSV();
            var stations = parser.Parse(StationInfoCSV.MULTIPLE_STATION_INFO_KDEN_KSEA_PHNL, new[] { "KDEN", "KSEA", "PHNL" });
            stations.Count.Should().Be(3);
            stations[0].ICAO.Should().Be("KDEN");
            stations[1].ICAO.Should().Be("KSEA");
            stations[2].ICAO.Should().Be("PHNL");

            var station = stations[0];
            station.Country.Should().Be("US");
            station.State.Should().Be("CO");
            station.WMOID.Should().Be(72565);
            station.Name.Should().Be("DENVER(DIA)");
            station.SiteType.Count.Should().Be(2);
            station.SiteType.Should().Contain(SiteType.METAR);
            station.SiteType.Should().Contain(SiteType.TAF);
            station.GeographicData.Latitude.Should().Be(39.85f);
            station.GeographicData.Longitude.Should().Be(-104.65f);
            station.GeographicData.Elevation.Should().Be(1640.0f);
        }
    }
}
