using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using Testing.Unit.Data;

namespace Testing.Unit
{
    public class ParseStationInfoXML_Tests
    {
        [Test]
        public void Parse_MultipleStations()
        {
            var parser = new ParseStationInfoXML();
            var stations = parser.Parse(StationInfoXML.MULTIPLE_STATION_KIAD_ORBB_ZBAA, new[] { "KIAD", "ORBB", "ZBAA" });
            stations.Count.Should().Be(3);
            stations[0].ICAO.Should().Be("KIAD");
            stations[1].ICAO.Should().Be("ORBB");
            stations[2].ICAO.Should().Be("ZBAA");

            var station = stations[0];
            station.Country.Should().Be("US");
            station.State.Should().Be("VA");
            station.WMOID.Should().Be(72403);
            station.Name.Should().Be("WASH DC/DULLES");
            station.SiteType.Count.Should().Be(3);
            station.SiteType.Should().Contain(SiteType.METAR);
            station.SiteType.Should().Contain(SiteType.TAF);
            station.SiteType.Should().Contain(SiteType.Rawinsonde);
            station.GeographicData.Latitude.Should().Be(38.93f);
            station.GeographicData.Longitude.Should().Be(-77.45f);
            station.GeographicData.Elevation.Should().Be(93.0f);
        }
    }
}
