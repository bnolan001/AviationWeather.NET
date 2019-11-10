using BNolan.AviationWx.NET.Connectors;
using BNolan.AviationWx.NET.Models.Constants;
using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace BNolan.AviationWx.NET.Accessors
{
    public class TAFAccessor
    {
        private readonly IConnector _connector;
        private readonly ParserType _parserType;
        private readonly IFormatProvider _formatProvider = new CultureInfo(ParserConstants.StringCulture);

        /// <summary>
        /// Configure the class to use the default parser type and connector
        /// </summary>
        public TAFAccessor()
        {
            _parserType = ParserType.XML;
            _connector = new Http();
        }

        /// <summary>
        /// Configure the class to use the defined parser and default connector
        /// </summary>
        /// <param name="parser"></param>
        public TAFAccessor(ParserType parser)
            : this()
        {
            _parserType = parser;
        }

        /// <summary>
        /// Configure the class to request data via the included connector
        /// and request data in the format associated with the parser
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="connector"></param>
        public TAFAccessor(ParserType parser, IConnector connector)
        {
            _parserType = parser;
            _connector = connector;
        }

        /// <summary>
        /// Retrieves the most recent TAFs for the list of ICAOs
        /// </summary>
        /// <param name="icaos"></param>
        public async Task<List<ForecastDto>> GetLatestForecastsAsync(IList<string> icaos,
            int hoursBeforeNow = 4)
        {
            var stations = String.Join("%20", icaos);
            var url = URLConstants.BaseURL + URLConstants.BasePath +
                URLConstants.LatestTAF.Replace("{format}", _parserType.Name)
                .Replace("{icaos}", stations)
                .Replace("{hours}", hoursBeforeNow.ToString(_formatProvider));
            var response = await _connector.GetAsync(url);
            return ConvertToDTO(response, icaos);
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
        public async Task<List<ForecastDto>> GetForecastsInBox(int maxLongitude, 
            int minLongitude, 
            int maxLatitude, 
            int minLatitude,
            int hoursBeforeNow = 4)
        {
            var url = URLConstants.BaseURL + URLConstants.BasePath +
                URLConstants.PreviousHoursTAFsInBox.Replace("{format}", _parserType.Name)
                .Replace("{hours}", hoursBeforeNow.ToString(_formatProvider))
                .Replace("{minLat}", minLatitude.ToString(_formatProvider))
                .Replace("{minLon}", minLongitude.ToString(_formatProvider))
                .Replace("{maxLat}", maxLatitude.ToString(_formatProvider))
                .Replace("{maxLon}", maxLongitude.ToString(_formatProvider));

            var response = await _connector.GetAsync(url);
            return ConvertToDTO(response, new List<string>());
        }

        /// <summary>
        /// Retrieves all TAFs disseminated over the last number of hours
        /// within the radious 
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="radial"></param>
        /// <param name="hoursBeforeNow"></param>
        /// <returns></returns>
        public async Task<List<ForecastDto>> GetForecastsInRadial(int longitude,
            int latitude,
            int radial,
            int hoursBeforeNow = 4)
        {
            var url = URLConstants.BaseURL + URLConstants.BasePath +
                URLConstants.PreviousHoursTAFsInRadial.Replace("{format}", _parserType.Name)
                .Replace("{hours}", hoursBeforeNow.ToString(_formatProvider))
                .Replace("{latitude}", latitude.ToString(_formatProvider))
                .Replace("{radial}", radial.ToString(_formatProvider))
                .Replace("{longitude}", longitude.ToString(_formatProvider));

            var response = await _connector.GetAsync(url);
            return ConvertToDTO(response, new List<string>());
        }

        /// <summary>
        /// Converts the pre-formatted string into the one or more forecasts 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="icaos"></param>
        /// <returns></returns>
        private List<ForecastDto> ConvertToDTO(string data,
            IList<string> icaos)
        {
            IParser<ForecastDto> parser = null;
            if (_parserType == ParserType.XML)
            {
                parser = new ParseTAFXML();
            }

            return parser.Parse(data, icaos);
        }
    }
}
