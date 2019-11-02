using AviationWx.NET.Models.Enums;
using AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            metar.ObsTime.Should().Be(DateTime.Parse("2019-10-31T01:53:00Z"));
            metar.ObsType.Should().Be(METARType.METAR);
            metar.Precipitation_In.Should().BeNull();
            metar.QualityControlFlags.Count.Should().Be(1);
            metar.QualityControlFlags.Where(q => q == QualityControlFlagType.AutoStation).FirstOrDefault().Should().NotBeNull();
        }
    }
}
