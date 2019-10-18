using AviationWx.NET;
using AviationWx.NET.Models.Constants;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests.Integration
{
    public class XML_Tests
    {
        public AviationWeather _aviationWeather;

        [SetUp]
        public void Setup()
        {
            _aviationWeather = new AviationWeather(ParserType.XML);
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
            var request = _aviationWeather.GetPreviousObservations(new List<string>() { "KIAD" }, 4);
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
            var request = _aviationWeather.GetPreviousObservations(new List<string>() { "KIAD", "KPHL" }, 4);
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

        #region TAF

        #region GetLatestForecasts

        [Test]
        public void GetLatestForecastsAsync_Single_Valid()
        {
            var request = _aviationWeather.GetLatestForecastsAsync(new List<string>() { "KPHL" });
            request.Wait();
            var taf = request.Result;
            taf.Should().NotBeNull();
            taf.Count.Should().Be(1);
            taf[0].TAF.Count.Should().BeGreaterOrEqualTo(1);
            taf[0].TAF[0].RawTAF.Should().NotBeNullOrWhiteSpace();
            taf[0].ICAO.Should().NotBeNullOrWhiteSpace();
        }

        #endregion GetlatestForecasts

        #endregion TAF
    }
}