using BNolan.AviationWx.NET;
using BNolan.AviationWx.NET.Models.Constants;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Testing.Integration
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

        #region TAF

        #region GetLatestForecasts

        [Test]
        public void GetLatestForecastsAsync_Single_Valid()
        {
            var request = _aviationWeather.GetLatestForecastsAsync(new List<string>() { "KPHL" });
            request.Wait();
            var forecasts = request.Result;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().Be(1);
            forecasts[0].TAF.Count.Should().BeGreaterOrEqualTo(1);
            forecasts[0].TAF[0].RawTAF.Should().NotBeNullOrWhiteSpace();
            forecasts[0].ICAO.Should().NotBeNullOrWhiteSpace();
        }


        [Test]
        public void GetLatestForecastsAsync_Multiple_Valid()
        {
            var request = _aviationWeather.GetLatestForecastsAsync(new List<string>() { "WALL", "ZBAA", "EGLL", "HECA" });
            request.Wait();
            var forecasts = request.Result;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().Be(4);
            foreach (var fcst in forecasts)
            {
                fcst.TAF.Count.Should().BeGreaterOrEqualTo(1);
                fcst.TAF[0].RawTAF.Should().NotBeNullOrWhiteSpace();
                fcst.ICAO.Should().NotBeNullOrWhiteSpace();
            }
        }
        #endregion GetlatestForecasts

        #region GetForecastsInBox

        [Test]
        public void GetForecastsInBox_Valid()
        {
            var request = _aviationWeather.GetForecastsInBox(25, -130, 65, -40, 3);
            request.Wait();
            var forecasts = request.Result;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().NotBe(0);
        }

        #endregion GetForecastsInBox

        #region GetForecastsInRadial

        [Test]
        public void GetForecastsInRadial_Valid()
        {
            var request = _aviationWeather.GetForecastsInRadial(25, 65, 50, 3);
            request.Wait();
            var forecasts = request.Result;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().NotBe(0);
        }

        #endregion GetForecastsInRadial

        #endregion TAF
    }
}