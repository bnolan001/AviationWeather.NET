using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
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
            forecasts[0].GeographicData.Elevation.Should().Be(4);
            var taf = forecasts[0].TAF[0];
            taf.RawTAF.Should().Be("PHNL 032126Z 0321/0424 20010KT P6SM VCSH SCT025 BKN060 FM040500 35003KT P6SM VCSH SCT025 BKN060 FM042000 18008KT P6SM SCT025 SCT060");
            taf.IssuedTime.Should().Be(ParserHelpers.ParseDateTime("2019-11-03T21:26:00Z"));
            taf.BulletinTime.Should().Be(ParserHelpers.ParseDateTime("2019-11-03T21:26:00Z"));
            taf.ValidTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-11-03T21:00:00Z"));
            taf.ValidTimeEnd.Should().Be(ParserHelpers.ParseDateTime("2019-11-05T00:00:00Z"));
            taf.Remarks.Should().Be("AMD");
            var tafLine = taf.TAFLine[0];
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-11-03T21:00:00Z"));
            tafLine.ForecastTimeEnd.Should().Be(ParserHelpers.ParseDateTime("2019-11-04T05:00:00Z"));
            tafLine.Wind.Direction.Should().Be(200);
            tafLine.Wind.Speed.Should().Be(10);
            tafLine.Wind.Gust.Should().BeNull();
            tafLine.Visibility.Should().Be(6.21f);
            tafLine.Weather.Should().Be("VCSH");
            tafLine.SkyCondition.Count().Should().Be(2);
            tafLine.SkyCondition[0].CloudBase.Should().Be(2500);
            tafLine.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.SCT);
            tafLine.SkyCondition[1].CloudBase.Should().Be(6000);
            tafLine.SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.BKN);
            tafLine = taf.TAFLine[1];
            tafLine.ChangeIndicator.Should().Be(ChangeIndicatorType.FM);
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-11-04T05:00:00Z"));
            tafLine.ForecastTimeEnd.Should().Be(ParserHelpers.ParseDateTime("2019-11-04T20:00:00Z"));

            forecasts[1].ICAO.Should().Be("KSEA");
            forecasts[1].TAF.Count().Should().Be(10);
            taf = forecasts[1].TAF[0];
            taf.RawTAF.Should().Be("KSEA 032101Z 0321/0424 35006KT P6SM SCT200 FM040200 VRB03KT P6SM SCT200 FM041000 VRB03KT P6SM SCT004 BKN010 FM041900 36005KT P6SM SCT010 SCT200");
            forecasts[1].GeographicData.Latitude.Should().Be(47.45f);
            forecasts[1].GeographicData.Longitude.Should().Be(-122.32f);
            forecasts[1].GeographicData.Elevation.Should().Be(136);

            tafLine = taf.TAFLine[1];
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-11-04T02:00:00Z"));
            tafLine.ChangeIndicator.Should().Be(ChangeIndicatorType.FM);

            forecasts[2].ICAO.Should().Be("KDEN");
            forecasts[2].TAF.Count().Should().Be(12);
            taf = forecasts[2].TAF[11];
            taf.RawTAF.Should().Be("KDEN 021731Z 0218/0324 10005KT P6SM FEW150 FM022100 14007KT P6SM FEW150 SCT220 FM030100 19010KT P6SM SCT150 BKN220");
            forecasts[2].GeographicData.Latitude.Should().Be(39.85f);
            forecasts[2].GeographicData.Longitude.Should().Be(-104.65f);
            forecasts[2].GeographicData.Elevation.Should().Be(1640);
        }
    }
}
