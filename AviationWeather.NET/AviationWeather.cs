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

        public AviationWeather(ParserType parser)
        {
            _parserType = parser;
            _connector = new Http();
            _metarAccessor = new METARAccessor(_parserType, _connector);
            _tafAccessor = new TAFAccessor(_parserType, _connector);
        }

        public AviationWeather(ParserType parser, IConnector connector)
        {
            _parserType = parser;
            _connector = connector;
            _metarAccessor = new METARAccessor(_parserType);
            _tafAccessor = new TAFAccessor(_parserType);
        }

        #region Observations

        public async Task<ObservationDto> GetLatestObservationAsync(string icao)
        {
            if (String.IsNullOrWhiteSpace(icao))
            {
                throw new ArgumentException($"{nameof(icao)} cannot be null or empty.");
            }
            return await _metarAccessor.GetLatestObservationAsync(icao);
        }

        public async Task<List<ObservationDto>> GetPreviousObservations(IList<string> icaos,
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
