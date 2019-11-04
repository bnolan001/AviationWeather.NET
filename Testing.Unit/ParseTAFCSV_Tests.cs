using AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Testing.Unit.Data;

namespace Testing.Unit
{
    public class ParseTAFCSV_Tests
    {
        [Test]
        public void ParseMultipleStations()
        {
            var parser = new ParseTAFCSV();
            var forecasts = parser.Parse(TAFCSV.MULTIPLE_STATION_PHNL_KSEA_KDEN, new List<string>() { "PHNL", "KSEA", "KDEN" });
            forecasts.Count().Should().Be(3);
            forecasts[0].ICAO.Should().Be("PHNL");
            forecasts[0].TAF.Count().Should().Be(9);
            forecasts[0].GeographicData.Latitude.Should().Be(21.33f);
            forecasts[0].GeographicData.Longitude.Should().Be(-157.92f);
            forecasts[0].GeographicData.Elevation_M.Should().Be(4);
            var taf = forecasts[0].TAF[0];
            taf.RawTAF.Should().Be("PHNL 032126Z 0321/0424 20010KT P6SM VCSH SCT025 BKN060 FM040500 35003KT P6SM VCSH SCT025 BKN060 FM042000 18008KT P6SM SCT025 SCT060");

            forecasts[1].ICAO.Should().Be("KSEA");
            forecasts[1].TAF.Count().Should().Be(10);
            taf = forecasts[1].TAF[0];
            taf.RawTAF.Should().Be("KSEA 032101Z 0321/0424 35006KT P6SM SCT200 FM040200 VRB03KT P6SM SCT200 FM041000 VRB03KT P6SM SCT004 BKN010 FM041900 36005KT P6SM SCT010 SCT200");
            forecasts[1].GeographicData.Latitude.Should().Be(47.45f);
            forecasts[1].GeographicData.Longitude.Should().Be(-122.32f);
            forecasts[1].GeographicData.Elevation_M.Should().Be(136);

            forecasts[2].ICAO.Should().Be("KDEN");
            forecasts[2].TAF.Count().Should().Be(12);
            taf = forecasts[2].TAF[11];
            taf.RawTAF.Should().Be("KDEN 021731Z 0218/0324 10005KT P6SM FEW150 FM022100 14007KT P6SM FEW150 SCT220 FM030100 19010KT P6SM SCT150 BKN220");
            forecasts[2].GeographicData.Latitude.Should().Be(39.85f);
            forecasts[2].GeographicData.Longitude.Should().Be(-104.65f);
            forecasts[2].GeographicData.Elevation_M.Should().Be(1640);
        }
    }
}
