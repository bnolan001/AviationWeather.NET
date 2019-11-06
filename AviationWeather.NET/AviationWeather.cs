using BNolan.AviationWx.NET.Accessors;
using BNolan.AviationWx.NET.Connectors;
using BNolan.AviationWx.NET.Models.Constants;
using BNolan.AviationWx.NET.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BNolan.AviationWx.NET
{
    public class AviationWeather
    {
        private readonly IConnector _connector;
        private readonly ParserType _parserType;
        private METARAccessor _metarAccessor;
        private TAFAccessor _tafAccessor;

        /// <summary>
        /// Constructor utilizing the default HTTP connector
        /// </summary>
        /// <param name="parser"></param>
        public AviationWeather(ParserType parser)
        {
            _parserType = parser;
            _connector = new Http();
            _metarAccessor = new METARAccessor(_parserType, _connector);
            _tafAccessor = new TAFAccessor(_parserType, _connector);
        }

        /// <summary>
        /// Constructor utilizing the client defined connector
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="connector"></param>
        public AviationWeather(ParserType parser, IConnector connector)
        {
            _parserType = parser;
            _connector = connector;
            _metarAccessor = new METARAccessor(_parserType, _connector);
            _tafAccessor = new TAFAccessor(_parserType, _connector);
        }

        #region Observations
        /// <summary>
        /// Retrieves the most recent observation associated with the ICAO
        /// </summary>
        /// <param name="icao"></param>
        /// <returns></returns>
        public async Task<ObservationDto> GetLatestObservationAsync(string icao)
        {
            if (String.IsNullOrWhiteSpace(icao))
            {
                throw new ArgumentException($"{nameof(icao)} cannot be null or empty.");
            }
            return await _metarAccessor.GetLatestObservationAsync(icao);
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
            return await _metarAccessor.GetPreviousHoursObservationss(icaos, numHours);
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
            return await _tafAccessor.GetLatestForecastsAsync(icaos);
        }

        #endregion Forecasts
    }
}
