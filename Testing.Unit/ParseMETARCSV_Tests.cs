using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

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
            var obs = parser.Parse(Resource.KDEN_METAR_CSV, new[] { "KDEN" });
            obs.Count.Should().Be(1);
            obs[0].ICAO.Should().Be("KDEN");
            obs[0].GeographicData.Should().NotBeNull();
            obs[0].GeographicData.Elevation.Should().Be(1640.0f);
            obs[0].GeographicData.Latitude.Should().Be(39.85f);
            obs[0].GeographicData.Longitude.Should().Be(-104.65f);
            obs[0].METAR.Count.Should().Be(2);
            var metar = obs[0].METAR[0];
            metar.Altimeter.Should().Be(30.221457f);
            metar.Dewpoint.Should().Be(-16.7f);
            metar.FlightCagegory.Should().Be(FlightCategoryType.VFR);
            metar.ObsTime.Should().Be(ParserHelpers.ParseDateTime("2019-10-31T01:53:00Z"));
            metar.ObsType.Should().Be(METARType.METAR);
            metar.Precipitation.Should().BeNull();
            metar.QualityControlFlags.Count.Should().Be(1);
            metar.QualityControlFlags.Where(q => q == QualityControlFlagType.AutoStation).FirstOrDefault().Should().NotBeNull();
            metar.Temperature.Should().Be(-11.1f);
            metar.Dewpoint.Should().Be(-16.7f);
            metar.Wind.Should().NotBeNull();
            metar.Wind.Direction.Should().Be(200);
            metar.Wind.Speed.Should().Be(12);
            metar.Wind.Gust.Should().BeNull();
            metar.Visibility.Should().Be(10f);
            metar.Altimeter.Should().Be(30.221457f);
            metar.SeaLevelPressure.Should().Be(1031.2f);
            metar.SkyCondition.Count().Should().Be(1);
            metar.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.CLR);
            metar.Weather.Should().BeNull();
            metar.ThreeHourObsData.Should().BeNull();
            metar.SixHourData.Should().BeNull();
            metar.TwentyFourHourData.Should().BeNull();
            metar.Precipitation.Should().BeNull();

            metar = obs[0].METAR[1];

            metar.SkyCondition.Count.Should().Be(2);
            metar.SkyCondition[0].SkyCondition.Should().Be(SkyConditionType.FEW);
            metar.SkyCondition[0].CloudBase.Should().Be(10000);
            metar.SkyCondition[1].SkyCondition.Should().Be(SkyConditionType.FEW);
            metar.SkyCondition[1].CloudBase.Should().Be(20000);
        }
    }
}
