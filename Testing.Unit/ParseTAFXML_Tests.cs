using AviationWx.NET.Models.Enums;
using AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Testing.Unit.Data;

namespace Testing.Unit
{
    public class ParseTAFXML_Tests
    {
        /// <summary>
        /// Validate ability to parse multiple observations for the same station
        /// </summary>
        [Test]
        public void Parse_SingleStation_General()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(TAFXML.SINGLE_STATION_NO_ICING_NO_TURBULENCE, new List<string>() { "KPHL" });
            forecasts.Count().Should().Be(1);
            var fcst = forecasts[0];
            fcst.GeographicData.Should().NotBeNull();
            fcst.GeographicData.Elevation_M.Should().Be(18.0f);
            fcst.GeographicData.Latitude.Should().Be(39.87f);
            fcst.GeographicData.Longitude.Should().Be(-75.23f);
            fcst.ICAO.Should().Be("KPHL");
            fcst.TAF.Count.Should().Be(11);
            var taf = fcst.TAF[0];

            taf.RawTAF.Should().Be("KPHL 262320Z 2700/2806 11008KT P6SM SCT040 BKN100 FM270800 10010KT P6SM BKN020 OVC040 FM271000 10012G20KT 5SM -RA BR OVC010 WS020/16040KT FM271300 15014G24KT 3SM +RA BR OVC008 WS020/19045KT FM271700 20010G18KT 5SM -RA BR OVC015 FM271900 24011KT P6SM SCT050");
            taf.IssuedTime.Should().Be(ParserHelpers.GetDateTime("2019-10-26T23:20:00Z"));
            taf.BulletinTime.Should().Be(ParserHelpers.GetDateTime("2019-10-26T23:20:00Z"));
            taf.ValidTimeStart.Should().Be(ParserHelpers.GetDateTime("2019-10-27T00:00:00Z"));
            taf.ValidTimeEnd.Should().Be(ParserHelpers.GetDateTime("2019-10-28T06:00:00Z"));
            taf.TAFLine.Count().Should().Be(6);
            var tafLine = taf.TAFLine[0];
            tafLine.Altimeter_Hg.Should().BeNull();
            tafLine.ForecastTimeEnd.Should().Be(ParserHelpers.GetDateTime("2019-10-27T08:00:00Z"));
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.GetDateTime("2019-10-27T00:00:00Z"));
            tafLine.IcingHazards.Count.Should().Be(0);
            tafLine.NotDecoded.Should().BeNull();
            tafLine.Probability.Should().BeNull();
            tafLine.SkyCondition.Count().Should().Be(2);
            tafLine.SkyCondition[0].CloudBase_Ft.Should().Be(4000);
            tafLine.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.SCT);
            tafLine.SkyCondition[1].CloudBase_Ft.Should().Be(10000);
            tafLine.SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.BKN);
            tafLine.Wind.Should().NotBeNull();
            tafLine.Wind.Direction_D.Should().Be(110);
            tafLine.Wind.Gust_Kt.Should().BeNull();
            tafLine.Wind.Speed_Kt.Should().Be(8);
            tafLine.WindShear.Should().BeNull();
            tafLine.Weather.Should().BeNull();
            tafLine.Visibility_SM.Should().Be(6.21f);

            tafLine = taf.TAFLine[2];
            tafLine.ForecastType.Should().Be(ChangeIndicatorType.FM);
            tafLine.Altimeter_Hg.Should().BeNull();
            tafLine.ForecastTimeEnd.Should().Be(ParserHelpers.GetDateTime("2019-10-27T13:00:00Z"));
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.GetDateTime("2019-10-27T10:00:00Z"));
            tafLine.IcingHazards.Count.Should().Be(0);
            tafLine.NotDecoded.Should().BeNull();
            tafLine.Probability.Should().BeNull();
            tafLine.SkyCondition.Count().Should().Be(1);
            tafLine.SkyCondition[0].CloudBase_Ft.Should().Be(1000);
            tafLine.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.OVC);
            tafLine.Wind.Should().NotBeNull();
            tafLine.Wind.Direction_D.Should().Be(100);
            tafLine.Wind.Gust_Kt.Should().Be(20);
            tafLine.Wind.Speed_Kt.Should().Be(12);
            tafLine.WindShear.Should().NotBeNull();
            tafLine.WindShear.Direction_D.Should().Be(160);
            tafLine.WindShear.Height_Ft.Should().Be(2000);
            tafLine.WindShear.Speed_Kt.Should().Be(40);
            tafLine.Weather.Should().Be("-RA BR");
            tafLine.Visibility_SM.Should().Be(5.0f);


        }

        [Test]
        public void Parse_SingleStation_SecondTAF_AMD()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(TAFXML.SINGLE_STATION_NO_ICING_NO_TURBULENCE, new List<string>() { "KPHL" });
            forecasts[0].TAF[1].Remarks.Should().Be("AMD");
        }

        [Test]
        public void Parse_SingleStation_NoData()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(TAFXML.SINGLE_STATION_NO_ICING_NO_TURBULENCE, new List<string>() { "XXXX" });
            forecasts.Count().Should().Be(2);
            forecasts[1].ICAO.Should().Be("XXXX");
            forecasts[1].TAF.Count().Should().Be(0);
        }
    }
}
