using BNolan.AviationWx.NET;
using BNolan.AviationWx.NET.Models.Constants;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Testing.Integration
{
    public class CSV_Tests
    {
        AviationWeather _aviationWeather;

        [SetUp]
        public void Setup()
        {
            _aviationWeather = new AviationWeather(ParserType.CSV);
        }

        #region METAR
        #region LatestObservation
        [Test]
        public void GetLatestObservation_Observation_Single_Valid()
        {
            var request = _aviationWeather.GetLatestObservationAsync("KIAD");
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.METAR.Count.Should().Be(1);
            obs.METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs.ICAO.Should().Be("KIAD");
        }

        [Test]
        public void GetLatestObservation_Observation_Single_InValid()
        {
            var request = _aviationWeather.GetLatestObservationAsync("999Z");
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.METAR.Count.Should().Be(0);
            obs.ICAO.Should().Be("999Z");

        }

        #endregion Latest Observation

        #region GetPreviousMETAR
        [Test]
        public void GetPreviousMETAR_Observation_Single_Valid()
        {
            var request = _aviationWeather.GetPreviousObservationsAsync(new List<string>() { "KIAD" }, 4);
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(1);
            obs[0].METAR.Count.Should().BeGreaterOrEqualTo(4);
            obs[0].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().Be("KIAD");
        }

        [Test]
        public void GetPreviousMETAR_Observation_Multiple_Valid()
        {
            var request = _aviationWeather.GetPreviousObservationsAsync(new List<string>() { "KIAD", "KPHL" }, 4);
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(2);
            obs[0].METAR.Count.Should().BeGreaterOrEqualTo(4);
            obs[0].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().NotBeNullOrWhiteSpace();

            obs[1].METAR.Count.Should().BeGreaterOrEqualTo(4);
            obs[1].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[1].ICAO.Should().NotBeNullOrWhiteSpace();
        }

        #endregion GetPreviousMETAR

        #endregion METAR
    }
}
