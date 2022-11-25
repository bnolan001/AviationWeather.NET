using BNolan.AviationWx.NET;
using BNolan.AviationWx.NET.Models.Constants;
using BNolan.AviationWx.NET.Models.Enums;
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
            var request = _aviationWeather.GetLatestObservationAsync(new List<string> { "KIAD" });
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(1);
            obs[0].METAR.Count.Should().Be(1);
            obs[0].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().Be("KIAD");
        }

        [Test]
        public void GetLatestObservation_Observation_Single_InValid()
        {
            var request = _aviationWeather.GetLatestObservationAsync(new List<string> { "999Z" });
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(1);
            obs[0].METAR.Count.Should().Be(0);
            obs[0].ICAO.Should().Be("999Z");

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
            var icaos = new List<string>() { "KIAD", "KPHL", "OKBK", "SBSN", "KADK", "WALL", "KPWM", "FVRG" };
            var request = _aviationWeather.GetPreviousObservationsAsync(
                icaos, 4);
            request.Wait();
            var obs = request.Result;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(icaos.Count);
            obs[0].METAR.Count.Should().BeGreaterOrEqualTo(1);
            obs[0].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().NotBeNullOrWhiteSpace();

            obs[1].METAR.Count.Should().BeGreaterOrEqualTo(1);
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
            var icaos = new List<string>() { "WALL", "ZBAA", "EGLL", "HECA", "KPWM", "SBSN", "KMCO"};
            var request = _aviationWeather.GetLatestForecastsAsync(icaos);
            request.Wait();
            var forecasts = request.Result;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().Be(icaos.Count);
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
            var request = _aviationWeather.GetForecastsInBoxAsync(25, -130, 65, -40, 3);
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
            var request = _aviationWeather.GetForecastsInRadialAsync(25, 65, 50, 3);
            request.Wait();
            var forecasts = request.Result;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().NotBe(0);
        }

        #endregion GetForecastsInRadial

        #endregion TAF

        #region Station Info

        [Test]
        public void GetStationInformation_Single_Valid()
        {
            var request = _aviationWeather.GetStationInfoByICAOAsync(new List<string>() { "KLAX" });
            request.Wait();
            var stations = request.Result;
            stations.Should().NotBeNullOrEmpty();
            stations.Count.Should().Be(1);
            stations[0].ICAO.Should().Be("KLAX");
            stations[0].WMOID.Should().Be(72295);
            stations[0].State.Should().Be("CA");
            stations[0].Country.Should().Be("US");
            stations[0].Name.Should().Be("LOS ANGELES");
            stations[0].GeographicData.Should().NotBeNull();
            stations[0].GeographicData.Elevation.Should().Be(30.0f);
            stations[0].GeographicData.Latitude.Should().Be(33.93f);
            stations[0].GeographicData.Longitude.Should().Be(-118.38f);
            stations[0].SiteType.Should().Contain(SiteType.METAR);
            stations[0].SiteType.Should().Contain(SiteType.TAF);
        }


        [Test]
        public void GetStationInformation_Single_InValid()
        {
            var request = _aviationWeather.GetStationInfoByICAOAsync(new List<string>() { "9999" });
            request.Wait();
            var stations = request.Result;
            stations.Should().BeEmpty();

        }

        [Test]
        public void GetStationInformation_Multiple_Valid()
        {
            var request = _aviationWeather.GetStationInfoByICAOAsync(new List<string>() { "SLSA", "YPXM" });
            request.Wait();
            var stations = request.Result;
            stations.Should().NotBeEmpty();

            stations[0].ICAO.Should().Be("SLSA");
            stations[1].ICAO.Should().Be("YPXM");
        }

        [Test]
        public void GetStationInfoByCountry_Valid()
        {
            var request = _aviationWeather.GetStationInfoByCountryAsync(new List<string>() { "US" });
            request.Wait();
            var stations = request.Result;
            stations.Should().NotBeEmpty();

            stations.Count.Should().BeGreaterThan(500);
        }

        [Test]
        public void GetStationInfoByCountry_InValid()
        {
            var request = _aviationWeather.GetStationInfoByCountryAsync(new List<string>() { "99" });
            request.Wait();
            var stations = request.Result;
            stations.Should().BeEmpty();
        }

        [Test]
        public void GetStationInfoByStateOrProvince_Valid()
        {
            var request = _aviationWeather.GetStationInfoByStateOrProvinceAsync(new List<string>() { "PA" });
            request.Wait();
            var stations = request.Result;
            stations.Should().NotBeEmpty();

            stations.Count.Should().BeGreaterThan(10);
        }

        [Test]
        public void GetStationInfoByStateOrProvince_InValid()
        {
            var request = _aviationWeather.GetStationInfoByStateOrProvinceAsync(new List<string>() { "99" });
            request.Wait();
            var stations = request.Result;
            stations.Should().BeEmpty();
        }


        [Test]
        public void GetStationsNear_Valid()
        {
            var request = _aviationWeather.GetStationsNearAsync(39.83, -104.65, 20);
            request.Wait();
            var stations = request.Result;
            stations.Should().NotBeEmpty();
            stations.Count.Should().BeGreaterOrEqualTo(2);
        }

        [Test]
        public void GetStationsInBox_Valid()
        {
            var request = _aviationWeather.GetStationsInBoxAsync(25, -130, 65, -40);
            request.Wait();
            var stations = request.Result;
            stations.Should().NotBeEmpty();
            stations.Count.Should().BeGreaterOrEqualTo(2);
        }

        #endregion Station Info
    }
}
