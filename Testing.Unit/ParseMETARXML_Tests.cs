using AviationWx.NET.Models.Enums;
using AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using Testing.Unit.Data;

namespace Testing.Unit
{
    public class ParseMETARXML_Tests
    {
        /// <summary>
        /// Validate ability to parse multiple observations for the same station
        /// </summary>
        [Test]
        public void Parse_SingleStation_MultipleObs()
        {
            var parser = new ParseMETARXML();
            var obs = parser.Parse(METARXML.SINGLE_STATION_METAR_KIAD, new[] { "KIAD" });
            obs.Count.Should().Be(1);
            obs[0].ICAO.Should().Be("KIAD");
            var metars = obs[0].METAR;
            metars.Count.Should().Be(2);
            metars[0].Altimeter_Hg.Should().Be(30.008858f);
            metars[0].Dewpoint_C.Should().Be(5.6f);
            metars[0].FlightCagegory.Should().Be(FlightCategoryType.VFR);
            metars[0].GeographicData.Should().NotBeNull();
            metars[0].GeographicData.Latitude.Should().Be(38.93f);
            metars[0].GeographicData.Longitude.Should().Be(-77.45f);
            metars[0].GeographicData.Elevation_M.Should().Be(93.0f);
            metars[0].ObsTime.Should().Be(DateTime.Parse("2019-10-19T22:52:00Z"));
            metars[0].Precipitation_In.Should().BeNull();
            metars[0].QualityControlFlags.Should().NotBeEmpty();
            metars[0].QualityControlFlags[0].Should().Be(QualityControlFlagType.AutoStation);
            metars[0].RawMETAR.Should().Be("KIAD 192252Z 15003KT 10SM FEW120 SCT180 BKN230 BKN250 14/06 A3001 RMK AO2 SLP164 T01440056");
            metars[0].SeaLevelPressure_Mb.Should().Be(1016.4f);
            metars[0].SkyCondition.Should().NotBeEmpty();
            metars[0].SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.FEW);
            metars[0].SkyCondition[0].CloudBaseFt.Should().Be(12000);
            metars[0].SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.SCT);
            metars[0].SkyCondition[1].CloudBaseFt.Should().Be(18000);
            metars[0].SkyCondition[2].SkyCondition.Should().Be(SkyConditionType.BKN);
            metars[0].SkyCondition[2].CloudBaseFt.Should().Be(23000);
            metars[0].SkyCondition[3].SkyCondition.Should().Be(SkyConditionType.BKN);
            metars[0].SkyCondition[3].CloudBaseFt.Should().Be(25000);
            metars[0].Temperature_C.Should().Be(14.4f);
            metars[0].VerticalVisibility_Ft.Should().BeNull();
            metars[0].Visibility_SM.Should().Be(10.0f);
            metars[0].Weather.Should().BeNull();
            metars[0].WindDirection_D.Should().Be(150);
            metars[0].WindGust_Kt.Should().BeNull();
            metars[0].WindSpeed_Kt.Should().Be(3);
            metars[0]._24HourData.Should().BeNull();
            metars[0]._3HourObsData.Should().BeNull();
            metars[0]._6HourData.Should().BeNull();
        }

        /// <summary>
        /// Validate ability to return empty METAR when station not found
        /// </summary>
        [Test]
        public void Parse_SingleStation_NoObs()
        {
            var parser = new ParseMETARXML();
            var obs = parser.Parse(METARXML.SINGLE_STATION_METAR_KIAD, new[] { "NOOB" });
            obs.Count.Should().Be(2);
            obs.Where(o => o.ICAO == "NOOB").First().METAR.Count.Should().Be(0);
        }
    }
}