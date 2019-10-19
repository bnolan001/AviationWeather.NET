using AviationWx.NET.Parsers;
using FluentAssertions;
using NUnit.Framework;
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
            obs[0].METAR.Count.Should().Be(2);
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