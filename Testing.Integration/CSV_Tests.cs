using BNolan.AviationWx.NET;
using BNolan.AviationWx.NET.Models.Enums;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task GetLatestObservation_Observation_Single_Valid()
        {
            var request = await _aviationWeather.GetLatestObservationAsync(new List<string> { "KIAD" });

            var obs = request;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(1);
            obs[0].METAR.Count.Should().Be(1);
            obs[0].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().Be("KIAD");
        }

        [Test]
        public async Task GetLatestObservation_Observation_Single_InValid()
        {
            var request = await _aviationWeather.GetLatestObservationAsync(new List<string> { "999Z" });

            var obs = request;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(1);
            obs[0].METAR.Count.Should().Be(0);
            obs[0].ICAO.Should().Be("999Z");

        }

        #endregion Latest Observation

        #region GetPreviousMETAR
        [Test]
        public async Task GetPreviousMETAR_Observation_Single_Valid()
        {
            var request = await _aviationWeather.GetPreviousObservationsAsync(new List<string>() { "KIAD" }, 4);
            var obs = request;
            obs.Should().NotBeNull();
            obs.Count.Should().Be(1);
            obs[0].METAR.Count.Should().BeGreaterOrEqualTo(4);
            obs[0].METAR[0].RawMETAR.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().NotBeNullOrWhiteSpace();
            obs[0].ICAO.Should().Be("KIAD");
        }

        [Test]
        public async Task GetPreviousMETAR_Observation_Multiple_Valid()
        {
            var icaos = new List<string>() { "KIAD", "KPHL", "OKBK", "SBSN", "KADK", "WALL", "KPWM", "FVRG" };
            var request = await _aviationWeather.GetPreviousObservationsAsync(
                icaos, 4);

            var obs = request;
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
        public async Task GetLatestForecastsAsync_Single_Valid()
        {
            var request = await _aviationWeather.GetLatestForecastsAsync(new List<string>() { "KPHL" });

            var forecasts = request;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().Be(1);
            forecasts[0].TAF.Count.Should().BeGreaterOrEqualTo(1);
            forecasts[0].TAF[0].RawTAF.Should().NotBeNullOrWhiteSpace();
            forecasts[0].ICAO.Should().NotBeNullOrWhiteSpace();
        }


        [Test]
        public async Task GetLatestForecastsAsync_Multiple_Valid()
        {
            var icaos = new List<string>() { "WALL", "ZBAA", "EGLL", "HECA", "KPWM", "SBSN", "KMCO" };
            var request = await _aviationWeather.GetLatestForecastsAsync(icaos);

            var forecasts = request;
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
        public async Task GetForecastsInBox_Valid()
        {
            var request = await _aviationWeather.GetForecastsInBoxAsync(25, -130, 65, -40, 3);
            var forecasts = request;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().NotBe(0);
        }

        #endregion GetForecastsInBox

        #region GetForecastsInRadial

        [Test]
        public async Task GetForecastsInRadial_Valid()
        {
            var request = await _aviationWeather.GetForecastsInRadialAsync(25, 65, 50, 3);

            var forecasts = request;
            forecasts.Should().NotBeNull();
            forecasts.Count.Should().NotBe(0);
        }

        #endregion GetForecastsInRadial

        #endregion TAF

        #region Station Info

        [Test]
        public async Task GetStationInformation_Single_Valid()
        {
            var request = await _aviationWeather.GetStationInfoByICAOAsync(new List<string>() { "KLAX" });

            var stations = request;
            stations.Should().NotBeNullOrEmpty();
            stations.Count.Should().Be(1);
            stations[0].ICAO.Should().Be("KLAX");
            stations[0].WMOID.Should().Be(72295);
            stations[0].State.Should().Be("CA");
            stations[0].Country.Should().Be("US");
            stations[0].Name.Should().Be("Los Angeles Intl");
            stations[0].GeographicData.Should().NotBeNull();
            stations[0].GeographicData.Elevation.Should().Be(30.0f);
            stations[0].GeographicData.Latitude.Should().Be(33.9382f);
            stations[0].GeographicData.Longitude.Should().Be(-118.387f);
            stations[0].SiteType.Should().Contain(SiteType.METAR);
            stations[0].SiteType.Should().Contain(SiteType.TAF);
        }


        [Test]
        public async Task GetStationInformation_Single_InValid()
        {
            var request = await _aviationWeather.GetStationInfoByICAOAsync(new List<string>() { "9999" });

            var stations = request;
            stations.Should().BeEmpty();

        }

        [Test]
        public async Task GetStationInformation_Multiple_Valid()
        {
            var request = await _aviationWeather.GetStationInfoByICAOAsync(new List<string>() { "SLSA", "YPXM" });

            var stations = request;
            stations.Should().NotBeEmpty();

            stations[0].ICAO.Should().Be("SLSA");
            stations[1].ICAO.Should().Be("YPXM");
        }

        [Test]
        public async Task GetStationInfoByCountry_Valid()
        {
            var request = await _aviationWeather.GetStationInfoByCountryAsync(new List<string>() { "US" });

            var stations = request;
            stations.Should().NotBeEmpty();

            stations.Count.Should().BeGreaterThan(500);
        }

        [Test]
        public async Task GetStationInfoByCountry_InValid()
        {
            var request = await _aviationWeather.GetStationInfoByCountryAsync(new List<string>() { "99" });

            var stations = request;
            stations.Should().BeEmpty();
        }

        [Test]
        public async Task GetStationInfoByStateOrProvince_Valid()
        {
            var request = await _aviationWeather.GetStationInfoByStateOrProvinceAsync(new List<string>() { "PA" });

            var stations = request;
            stations.Should().NotBeEmpty();

            stations.Count.Should().BeGreaterThan(10);
        }

        [Test]
        public async Task GetStationInfoByStateOrProvince_InValid()
        {
            var request = await _aviationWeather.GetStationInfoByStateOrProvinceAsync(new List<string>() { "99" });

            var stations = request;
            stations.Should().BeEmpty();
        }


        [Test]
        public async Task GetStationsNear_Valid()
        {
            var request = await _aviationWeather.GetStationsNearAsync(39.83, -104.65, 20);

            var stations = request;
            stations.Should().NotBeEmpty();
            stations.Count.Should().BeGreaterOrEqualTo(2);
        }

        [Test]
        public async Task GetStationsInBox_Valid()
        {
            var request = await _aviationWeather.GetStationsInBoxAsync(25, -130, 65, -40);

            var stations = request;
            stations.Should().NotBeEmpty();
            stations.Count.Should().BeGreaterOrEqualTo(2);
        }

        #endregion Station Info
    }
}
