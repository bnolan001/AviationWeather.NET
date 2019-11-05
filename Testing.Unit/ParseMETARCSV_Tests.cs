using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using Testing.Unit.Data;

namespace Testing.Unit
{
    public class ParseMETARCSV_Tests
    {
        /// <summary>
        /// Validate ability to parse multiple observations for the same station
        /// </summary>
        [Test]
        public void Parse_SingleStation_MultipleObs()
        {
            var parser = new ParseMETARCSV();
            var obs = parser.Parse(METARCSV.SINGLE_STATION_METAR_KPHL, new[] { "KDEN" });
            obs.Count.Should().Be(1);
            obs[0].ICAO.Should().Be("KDEN");
            obs[0].GeographicData.Should().NotBeNull();
            obs[0].GeographicData.Elevation_M.Should().Be(1640.0f);
            obs[0].GeographicData.Latitude.Should().Be(39.85f);
            obs[0].GeographicData.Longitude.Should().Be(-104.65f);
            obs[0].METAR.Count.Should().Be(2);
            var metar = obs[0].METAR[0];
            metar.Altimeter_Hg.Should().Be(30.221457f);
            metar.Dewpoint_C.Should().Be(-16.7f);
            metar.FlightCagegory.Should().Be(FlightCategoryType.VFR);
            metar.ObsTime.Should().Be(ParserHelpers.ParseDateTime("2019-10-31T01:53:00Z"));
            metar.ObsType.Should().Be(METARType.METAR);
            metar.Precipitation_In.Should().BeNull();
            metar.QualityControlFlags.Count.Should().Be(1);
            metar.QualityControlFlags.Where(q => q == QualityControlFlagType.AutoStation).FirstOrDefault().Should().NotBeNull();
            metar.Temperature_C.Should().Be(-11.1f);
            metar.Dewpoint_C.Should().Be(-16.7f);
            metar.Wind.Should().NotBeNull();
            metar.Wind.Direction_D.Should().Be(200);
            metar.Wind.Speed_Kt.Should().Be(12);
            metar.Wind.Gust_Kt.Should().BeNull();
            metar.Visibility_SM.Should().Be(10f);
            metar.Altimeter_Hg.Should().Be(30.221457f);
            metar.SeaLevelPressure_Mb.Should().Be(1031.2f);
            metar.SkyCondition.Count().Should().Be(1);
            metar.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.CLR);
            metar.Weather.Should().BeNull();
            metar._3HourObsData.Should().BeNull();
            metar._6HourData.Should().BeNull();
            metar._24HourData.Should().BeNull();
            metar.Precipitation_In.Should().BeNull();

            metar = obs[0].METAR[1];

            metar.SkyCondition.Count.Should().Be(2);
            metar.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.FEW);
            metar.SkyCondition[0].CloudBase_Ft.Should().Be(10000);
            metar.SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.FEW);
            metar.SkyCondition[1].CloudBase_Ft.Should().Be(20000);
        }
    }
}
