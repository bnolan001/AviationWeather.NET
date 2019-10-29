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
            obs[0].GeographicData.Should().NotBeNull();
            obs[0].GeographicData.Latitude.Should().Be(38.93f);
            obs[0].GeographicData.Longitude.Should().Be(-77.45f);
            obs[0].GeographicData.Elevation_M.Should().Be(93.0f);
            var metars = obs[0].METAR;
            metars.Count.Should().Be(2);
            metars[0].Altimeter_Hg.Should().Be(30.008858f);
            metars[0].Dewpoint_C.Should().Be(5.6f);
            metars[0].FlightCagegory.Should().Be(FlightCategoryType.VFR);
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
            metars[0].Wind.Direction_D.Should().Be(150);
            metars[0].Wind.Gust_Kt.Should().BeNull();
            metars[0].Wind.Speed_Kt.Should().Be(3);
            metars[0]._24HourData.Should().BeNull();
            metars[0]._3HourObsData.Should().BeNull();
            metars[0]._6HourData.Should().BeNull();
            metars[0].ObsType.Should().Be(METARType.METAR);
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

        /// <summary>
        /// Validate ability to properly parse SPECI
        /// </summary>
        [Test]
        public void Parse_SingleStation_SpeciObs()
        {
            var parser = new ParseMETARXML();
            var obs = parser.Parse(METARXML.SINGLE_STATION_METAR_SPECI, new[] { "KATL" });
            obs.Count.Should().Be(1);
            obs[0].ICAO.Should().Be("KATL");
            obs[0].GeographicData.Should().NotBeNull();
            obs[0].GeographicData.Latitude.Should().Be(33.63f);
            obs[0].GeographicData.Longitude.Should().Be(-84.45f);
            obs[0].GeographicData.Elevation_M.Should().Be(296.0f);
            // Check regular METAR
            var metars = obs[0].METAR;
            obs[0].METAR.Count.Should().Be(3);

            metars[0].Altimeter_Hg.Should().Be(29.760826f);
            metars[0].Dewpoint_C.Should().Be(10.6f);
            metars[0].FlightCagegory.Should().Be(FlightCategoryType.IFR);
            metars[0].ObsTime.Should().Be(DateTime.Parse("2019-10-19T23:52:00Z"));
            metars[0].Precipitation_In.Should().Be(0.04f);
            metars[0].QualityControlFlags.Should().NotBeEmpty();
            metars[0].QualityControlFlags[0].Should().Be(QualityControlFlagType.AutoStation);
            metars[0].RawMETAR.Should().Be("KATL 192352Z 04017KT 8SM -RA BKN007 OVC012 13/11 A2976 RMK AO2 SLP076 CIG 006V009 P0004 60074 T01280106 10133 20122 56007");
            metars[0].SeaLevelPressure_Mb.Should().Be(1007.6f);
            metars[0].SkyCondition.Should().NotBeEmpty();
            metars[0].SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.BKN);
            metars[0].SkyCondition[0].CloudBaseFt.Should().Be(700);
            metars[0].SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.OVC);
            metars[0].SkyCondition[1].CloudBaseFt.Should().Be(1200);
            metars[0].Temperature_C.Should().Be(12.8f);
            metars[0].VerticalVisibility_Ft.Should().BeNull();
            metars[0].Visibility_SM.Should().Be(8.0f);
            metars[0].Weather.Should().Be("-RA");
            metars[0].Wind.Direction_D.Should().Be(40);
            metars[0].Wind.Gust_Kt.Should().BeNull();
            metars[0].Wind.Speed_Kt.Should().Be(17);
            metars[0]._24HourData.Should().BeNull();
            metars[0].TemperatureRange.Should().NotBeNull();
            metars[0].TemperatureRange.MaxTemperature_C.Should().Be(13.3f);
            metars[0].TemperatureRange.MinTemperature_C.Should().Be(12.2f);
            metars[0]._3HourObsData.Should().NotBeNull();
            metars[0]._3HourObsData.Precipitation_In.Should().BeNull();
            metars[0]._3HourObsData.PressureTendency_Mb.Should().Be(-0.7f);
            metars[0]._6HourData.Should().NotBeNull();
            metars[0]._6HourData.Precipitation_In.Should().Be(0.74f);
            metars[0].ObsType.Should().Be(METARType.METAR);

            // Check SPECI METAR
            metars[2].Altimeter_Hg.Should().Be(29.760826f);
            metars[2].Dewpoint_C.Should().Be(11.1f);
            metars[2].ObsTime.Should().Be(DateTime.Parse("2019-10-19T21:52:00Z"));
            metars[2].Precipitation_In.Should().Be(0.12f);
            metars[2].QualityControlFlags.Should().NotBeEmpty();
            metars[2].QualityControlFlags[0].Should().Be(QualityControlFlagType.AutoStation);
            metars[2].RawMETAR.Should().Be("KATL 192152Z 07018KT 2SM -RA BR BKN007 OVC012 13/11 A2976 RMK AO2 SFC VIS 4 SLP077 CIG 006V009 P0012 T01280111");
            metars[2].SeaLevelPressure_Mb.Should().Be(1007.7f);
            metars[2].SkyCondition.Should().NotBeEmpty();
            metars[2].SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.BKN);
            metars[2].SkyCondition[0].CloudBaseFt.Should().Be(700);
            metars[2].SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.OVC);
            metars[2].SkyCondition[1].CloudBaseFt.Should().Be(1200);
            metars[2].Temperature_C.Should().Be(12.8f);
            metars[2].VerticalVisibility_Ft.Should().BeNull();
            metars[2].Visibility_SM.Should().Be(2.0f);
            metars[2].Weather.Should().Be("-RA BR");
            metars[2].Wind.Direction_D.Should().Be(70);
            metars[2].Wind.Gust_Kt.Should().BeNull();
            metars[2].Wind.Speed_Kt.Should().Be(18);
            metars[2]._24HourData.Should().BeNull();
            metars[2].TemperatureRange.Should().BeNull();
            metars[2]._3HourObsData.Should().BeNull();
            metars[2]._6HourData.Should().BeNull();
            metars[2].ObsType.Should().Be(METARType.SPECI);
        }
    }
}