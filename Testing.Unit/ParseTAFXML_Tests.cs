using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


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
            var forecasts = parser.Parse(Resource.KPHL_TAF_XML, new List<string>() { "KPHL" });
            forecasts.Count().Should().Be(1);
            var fcst = forecasts[0];
            fcst.GeographicData.Should().NotBeNull();
            fcst.GeographicData.Elevation.Should().Be(18.0f);
            fcst.GeographicData.Latitude.Should().Be(39.87f);
            fcst.GeographicData.Longitude.Should().Be(-75.23f);
            fcst.ICAO.Should().Be("KPHL");
            fcst.TAF.Count.Should().Be(11);
            var taf = fcst.TAF[0];

            taf.RawTAF.Should().Be("KPHL 262320Z 2700/2806 11008KT P6SM SCT040 BKN100 FM270800 10010KT P6SM BKN020 OVC040 FM271000 10012G20KT 5SM -RA BR OVC010 WS020/16040KT FM271300 15014G24KT 3SM +RA BR OVC008 WS020/19045KT FM271700 20010G18KT 5SM -RA BR OVC015 FM271900 24011KT P6SM SCT050");
            taf.IssuedTime.Should().Be(ParserHelpers.ParseDateTime("2019-10-26T23:20:00Z"));
            taf.BulletinTime.Should().Be(ParserHelpers.ParseDateTime("2019-10-26T23:20:00Z"));
            taf.ValidTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-10-27T00:00:00Z"));
            taf.ValidTimeEnd.Should().Be(ParserHelpers.ParseDateTime("2019-10-28T06:00:00Z"));
            taf.TAFLine.Count().Should().Be(6);
            var tafLine = taf.TAFLine[0];
            tafLine.Altimeter.Should().BeNull();
            tafLine.ForecastTimeEnd.Should().Be(ParserHelpers.ParseDateTime("2019-10-27T08:00:00Z"));
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-10-27T00:00:00Z"));
            tafLine.IcingHazards.Count.Should().Be(0);
            tafLine.NotDecoded.Should().BeNull();
            tafLine.Probability.Should().BeNull();
            tafLine.SkyCondition.Count().Should().Be(2);
            tafLine.SkyCondition[0].CloudBase.Should().Be(4000);
            tafLine.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.SCT);
            tafLine.SkyCondition[1].CloudBase.Should().Be(10000);
            tafLine.SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.BKN);
            tafLine.Wind.Should().NotBeNull();
            tafLine.Wind.Direction.Should().Be(110);
            tafLine.Wind.Gust.Should().BeNull();
            tafLine.Wind.Speed.Should().Be(8);
            tafLine.WindShear.Should().BeNull();
            tafLine.Weather.Should().BeNull();
            tafLine.Visibility.Should().Be(6.21f);

            tafLine = taf.TAFLine[2];
            tafLine.ChangeIndicator.Should().Be(ChangeIndicatorType.FM);
            tafLine.Altimeter.Should().BeNull();
            tafLine.ForecastTimeEnd.Should().Be(ParserHelpers.ParseDateTime("2019-10-27T13:00:00Z"));
            tafLine.ForecastTimeStart.Should().Be(ParserHelpers.ParseDateTime("2019-10-27T10:00:00Z"));
            tafLine.IcingHazards.Count.Should().Be(0);
            tafLine.NotDecoded.Should().BeNull();
            tafLine.Probability.Should().BeNull();
            tafLine.SkyCondition.Count().Should().Be(1);
            tafLine.SkyCondition[0].CloudBase.Should().Be(1000);
            tafLine.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.OVC);
            tafLine.Wind.Should().NotBeNull();
            tafLine.Wind.Direction.Should().Be(100);
            tafLine.Wind.Gust.Should().Be(20);
            tafLine.Wind.Speed.Should().Be(12);
            tafLine.WindShear.Should().NotBeNull();
            tafLine.WindShear.Direction.Should().Be(160);
            tafLine.WindShear.Height.Should().Be(2000);
            tafLine.WindShear.Speed.Should().Be(40);
            tafLine.Weather.Should().Be("-RA BR");
            tafLine.Visibility.Should().Be(5.0f);


        }

        [Test]
        public void Parse_SingleStation_SecondTAF_AMD()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(Resource.KPHL_TAF_XML, new List<string>() { "KPHL" });
            forecasts[0].TAF[1].Remarks.Should().Be("AMD");
        }

        [Test]
        public void Parse_SingleStation_NoData()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(Resource.KPHL_TAF_XML, new List<string>() { "XXXX" });
            forecasts.Count().Should().Be(2);
            forecasts[1].ICAO.Should().Be("XXXX");
            forecasts[1].TAF.Count().Should().Be(0);
        }

        [Test]
        public void Parse_SingleStation_Miliatry()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(Resource.KMUI_TAF_XML, new List<string>() { "KMUI"});
            forecasts.Count().Should().Be(1);
            forecasts[0].ICAO.Should().Be("KMUI");
            forecasts[0].TAF.Count().Should().Be(4);
            var taf = forecasts[0].TAF[0];
            taf.RawTAF.Should().Be("TAF AMD KMUI 042359Z 0423/0601 18012KT 9999 FEW140 QNH3022INS BECMG 0503/0504 VRB06KT 9999 FEW180 510052 QNH3018INS BECMG 0510/0511 VRB06KT 9999 FEW085 QNH3016INS BECMG 0519/0520 27008KT 9999 SCT035 BKN080 620808 QNH3016INS TX14/0519Z TN03/0512Z LAST NO AMDS AFT 0500 NEXT 0511");
            taf.TAFLine.Count().Should().Be(4);
            taf.TAFLine[1].ChangeIndicator.Should().Be(ChangeIndicatorType.BECMG);
            taf.TAFLine[1].TurbulenceHazards.Count().Should().Be(1);
            taf.TAFLine[1].TurbulenceHazards[0].Intensity.Should().Be(TurbulenceIntensity.Light);
            taf.TAFLine[1].TurbulenceHazards[0].MinAltitude.Should().Be(500);
            taf.TAFLine[1].TurbulenceHazards[0].MaxAltitude.Should().Be(2500);

            taf.TAFLine[3].IcingHazards.Count().Should().Be(1);
            taf.TAFLine[3].IcingHazards[0].Intensity.Should().Be(IcingIntensity.LightIcingInCloud);
            taf.TAFLine[3].IcingHazards[0].MinAltitude.Should().Be(8000);
            taf.TAFLine[3].IcingHazards[0].MaxAltitude.Should().Be(16000);
        }

        
        [Test]
        public void ParseTurbulence()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(Resource.PASY_Icing_Turbulence_TAF_XML, new List<string>() { "PASY" });
            forecasts.Count().Should().Be(1);
            forecasts[0].TAF.Should().NotBeNullOrEmpty();
            forecasts[0].TAF[0].TAFLine.Should().NotBeNullOrEmpty();
            var taf = forecasts[0].TAF[0];
            taf.TAFLine[0].TurbulenceHazards.Should().NotBeNullOrEmpty();
            taf.TAFLine[0].TurbulenceHazards[0].MinAltitude.Should().Be(0);
            taf.TAFLine[0].TurbulenceHazards[0].MaxAltitude.Should().Be(3000);
            taf.TAFLine[0].TurbulenceHazards[0].Intensity.Should().Be(TurbulenceIntensity.Light);
        }

        [Test]
        public void ParseIcing()
        {
            var parser = new ParseTAFXML();
            var forecasts = parser.Parse(Resource.PASY_Icing_Turbulence_TAF_XML, new List<string>() { "PASY" });
            forecasts.Count().Should().Be(1);
            forecasts[0].TAF.Should().NotBeNullOrEmpty();
            forecasts[0].TAF[0].TAFLine.Should().NotBeNullOrEmpty();
            var taf = forecasts[0].TAF[0];
            taf.TAFLine[0].IcingHazards.Should().NotBeNullOrEmpty();
            taf.TAFLine[0].IcingHazards[0].MinAltitude.Should().Be(3000);
            taf.TAFLine[0].IcingHazards[0].MaxAltitude.Should().Be(7000);
            taf.TAFLine[0].IcingHazards[0].Intensity.Should().Be(IcingIntensity.LightIcing);
        }
    }
}
