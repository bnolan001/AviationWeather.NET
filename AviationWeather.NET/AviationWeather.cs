﻿using BNolan.AviationWx.NET.Accessors;
using BNolan.AviationWx.NET.Connectors;
using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Validators;

namespace BNolan.AviationWx.NET
{
    public class AviationWeather
    {
        /*
         * ConfigureAwait(false) is being utilized on Async calls based on the write-up from Microsoft
         * in https://devblogs.microsoft.com/dotnet/configureawait-faq/ 
         */
        private readonly IConnector _connector;
        private readonly ParserType _parserType;
        private readonly METARAccessor _metarAccessor;
        private readonly TAFAccessor _tafAccessor;
        private readonly StationDataAccessor _stationDataAccessor;

        /// <summary>
        /// Constructor utilizing the default HTTP connector
        /// </summary>
        /// <param name="parser">Which data format should be retrieved</param>
        public AviationWeather(ParserType parser)
        {
            _parserType = parser;
            _connector = new HttpConnector();
            _metarAccessor = new METARAccessor(_parserType, _connector);
            _tafAccessor = new TAFAccessor(_parserType, _connector);
            _stationDataAccessor = new StationDataAccessor(_parserType, _connector);
        }

        /// <summary>
        /// Constructor utilizing the client defined connector
        /// </summary>
        /// <param name="parser">Which data format should be retrieved</param>
        /// <param name="connector">Connection class used to retrieve the data</param>
        public AviationWeather(ParserType parser, IConnector connector)
        {
            _parserType = parser;
            _connector = connector;
            _metarAccessor = new METARAccessor(_parserType, _connector);
            _tafAccessor = new TAFAccessor(_parserType, _connector);
            _stationDataAccessor = new StationDataAccessor(_parserType, _connector);
        }

        #region Observations
        /// <summary>
        /// Retrieves the most recent observation associated with the ICAO
        /// </summary>
        /// <param name="icaos"></param>
        /// <returns></returns>
        public async Task<List<ObservationDto>> GetLatestObservationAsync(IList<string> icaos)
        {
            if (icaos == null
                || icaos.Count == 0)
            {
                throw new ArgumentException($"{nameof(icaos)} cannot be null or empty.");
            }
            return await _metarAccessor.GetLatestObservationAsync(icaos)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all observations associated with the ICAOs for the previous number of hours
        /// </summary>
        /// <param name="icaos"></param>
        /// <param name="numHours"></param>
        /// <returns></returns>
        public async Task<List<ObservationDto>> GetPreviousObservationsAsync(IList<string> icaos,
            int numHours)
        {
            if (icaos == null
                || icaos.Count == 0)
            {
                throw new ArgumentException($"{nameof(icaos)} cannot be null or empty.");
            }

            if (numHours < 1)
            {
                throw new ArgumentException($"{nameof(numHours)} must be greater than 0.");
            }
            return await _metarAccessor.GetPreviousObservationsAsync(icaos, numHours)
                .ConfigureAwait(false);
        }

        #endregion Observations

        #region Forecasts

        /// <summary>
        /// Retrieves the latest TAF associated with the ICAOs
        /// </summary>
        /// <param name="icaos"></param>
        /// <returns></returns>
        public async Task<List<ForecastDto>> GetLatestForecastsAsync(IList<string> icaos)
        {
            if (icaos == null
                || icaos.Count == 0)
            {
                throw new ArgumentException($"{nameof(icaos)} cannot be null or empty.");
            }
            return await _tafAccessor.GetLatestForecastsAsync(icaos)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all TAFs disseminated over the last number of hours
        /// within the box defined by the Latitude and Longitude coordinates
        /// </summary>
        /// <param name="maxLongitude"></param>
        /// <param name="minLongitude"></param>
        /// <param name="maxLatitude"></param>
        /// <param name="minLatitude"></param>
        /// <param name="hoursBeforeNow"></param>
        /// <returns></returns>
        public async Task<List<ForecastDto>> GetForecastsInBoxAsync(int maxLongitude,
            int minLongitude,
            int maxLatitude,
            int minLatitude,
            int hoursBeforeNow = 4)
        {
            GeographicValidator.ValidateLatitude(minLatitude);
            GeographicValidator.ValidateLatitude(maxLatitude);
            GeographicValidator.ValidateLongitude(minLongitude);
            GeographicValidator.ValidateLongitude(maxLongitude);

            return await _tafAccessor.GetForecastsInBoxAsync(maxLongitude, minLongitude,
                maxLatitude, minLatitude, hoursBeforeNow).ConfigureAwait(false);

        }

        /// <summary>
        /// Retrieves all TAFs disseminated over the last number of hours
        /// within the box defined by the Latitude and Longitude coordinates
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radial"></param>
        /// <param name="hoursBeforeNow"></param>
        /// <returns></returns>
        public async Task<List<ForecastDto>> GetForecastsInRadialAsync(int longitude,
            int latitude,
            int radial,
            int hoursBeforeNow = 4)
        {
            if (radial <= 0)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(radial)}' must be greater than 0 but less than 500");
            }
            GeographicValidator.ValidateLatitude(latitude);
            GeographicValidator.ValidateLongitude(longitude);

            return await _tafAccessor.GetForecastsInRadialAsync(longitude, latitude,
                radial, hoursBeforeNow).ConfigureAwait(false);

        }
        #endregion Forecasts

        #region Station Info

        /// <summary>
        /// Retrieves the station information associated with the ICAOs.  
        /// </summary>
        /// <param name="icaos"></param>
        /// <returns>Empty list if none of the ICAOs are found.</returns>
        public async Task<List<StationInfoDto>> GetStationInfoByICAOAsync(IList<string> icaos)
        {
            if (icaos == null
                || icaos.Count == 0)
            {
                throw new ArgumentException($"{nameof(icaos)} cannot be null or empty.");
            }

            return await _stationDataAccessor.GetStationInformationAsync(icaos)
                .ConfigureAwait(false);
        }

        // <summary>
        /// Retrieves the station information for all ICAOs located in the state or province.  
        /// The abbreviation is expected to be the two letter abbreviation for the state or province.
        /// </summary>
        /// <param name="icaos"></param>
        /// <returns>Empty list if none of the ICAOs are found.</returns>
        public async Task<List<StationInfoDto>> GetStationInfoByStateOrProvinceAsync(IList<string> abbreviations)
        {
            if (abbreviations == null
                || abbreviations.Count == 0)
            {
                throw new ArgumentException($"{nameof(abbreviations)} cannot be null or empty.");
            }

            return await _stationDataAccessor.GetStationsByStateOrProvinceAsync(abbreviations)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves the station information for all ICAOs located in the country.  
        /// The abbreviation is expected to be the two letter abbreviation for the country.
        /// </summary>
        /// <param name="abbreviations">List of two letter abbreviations for countries</param>
        /// <returns>Empty list if the abbreviation is not recognized</returns>
        public async Task<List<StationInfoDto>> GetStationInfoByCountryAsync(IList<string> abbreviations)
        {
            if (abbreviations == null
                || abbreviations.Count == 0)
            {
                throw new ArgumentException($"{nameof(abbreviations)} cannot be null or empty.");
            }

            return await _stationDataAccessor.GetStationsByCountryAsync(abbreviations)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all stations that are located within the circle defined by the latitude and longitude
        /// for the center and distance defining the radius to search.
        /// </summary>
        /// <param name="latitude">-90.0 to 90.0</param>
        /// <param name="longitude">-180.0 to 180.0</param>
        /// <param name="distance">Statute miles</param>
        /// <returns>Empty list if no stations are found in the area defined</returns>
        public async Task<List<StationInfoDto>> GetStationsNearAsync(double latitude, double longitude,
            int distance)
        {
            GeographicValidator.ValidateLatitude(latitude);
            GeographicValidator.ValidateLongitude(longitude);
            if (distance < 1)
            {
                throw new ArgumentException("Distance must be a value greater than 0", nameof(distance));
            }

            return await _stationDataAccessor.GetStationsNearAsync(latitude, longitude, distance)
                .ConfigureAwait(false);
        }



        /// <summary>
        /// Retrieves all stations that are located within the box defined by the two corners
        /// </summary>
        /// <param name="cornerOneLatitude">-90.0 to 90.0</param>
        /// <param name="cornerOneLongitude">-180.0 to 180.0</param>
        /// <param name="cornerTwoLatitude">-90.0 to 90.0</param>
        /// <param name="cornerTwoLongitude">-180.0 to 180.0</param>
        /// <returns>Empty list if no stations are found in the area defined</returns>
        public async Task<List<StationInfoDto>> GetStationsInBoxAsync(double cornerOneLatitude, double cornerOneLongitude,
            double cornerTwoLatitude, double cornerTwoLongitude)
        {
            GeographicValidator.ValidateLatitude(cornerOneLatitude);
            GeographicValidator.ValidateLongitude(cornerOneLongitude);
            GeographicValidator.ValidateLatitude(cornerTwoLatitude);
            GeographicValidator.ValidateLongitude(cornerTwoLongitude);

            return await _stationDataAccessor.GetStationsInBoxAsync(cornerOneLatitude, cornerOneLongitude,
                cornerTwoLatitude, cornerTwoLongitude).ConfigureAwait(false);
        }

        #endregion Station Info
    }
}
