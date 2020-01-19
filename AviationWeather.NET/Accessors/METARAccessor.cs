using BNolan.AviationWx.NET.Connectors;
using BNolan.AviationWx.NET.Models.Constants;
using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BNolan.AviationWx.NET.Accessors
{
    public class METARAccessor
    {
        /*
         * ConfigureAwait(false) is being utilized on Async calls based on the write-up from Microsoft
         * in https://devblogs.microsoft.com/dotnet/configureawait-faq/ 
         */
        private readonly IConnector _connector;
        private readonly ParserType _parserType;
        private readonly IFormatProvider _formatProvider = new CultureInfo(ParserConstants.StringCulture);

        /// <summary>
        /// Configure the class to use the default parser type and connector
        /// </summary>
        public METARAccessor()
        {
            _parserType = ParserType.XML;
            _connector = new HttpConnector();
        }

        /// <summary>
        /// Configure the class to use the defined parser and default connector
        /// </summary>
        /// <param name="parser"></param>
        public METARAccessor(ParserType parser)
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
        public METARAccessor(ParserType parser, IConnector connector)
            : this(parser)
        {
            _connector = connector;
        }

        /// <summary>
        /// Retrieves the most recent observation reported for the ICAO
        /// </summary>
        /// <param name="icaos"></param>
        public async Task<List<ObservationDto>> GetLatestObservationAsync(IList<string> icaos)
        {
            var requests = new List<Task<string>>();
            // The get latest call doesn't accept multiple ICAOs in a single request
            // so mechanically request each obs
            foreach (var icao in icaos)
            {
                var url = URLConstants.BaseURL + URLConstants.BasePath +
                    URLConstants.LatestMETAR.Replace("{format}", _parserType.Name)
                    .Replace("{icao}", icao);
                requests.Add(_connector.GetAsync(url));
            }
            var results = await Task.WhenAll(requests.ToArray()).ConfigureAwait(false);
            var obsDTOs = new List<ObservationDto>();
            for(var idx = 0; idx < icaos.Count; idx++)
            {
                obsDTOs.Add(ConvertToDTO(results[idx], new List<string> { icaos[idx] }).First());
            }
            
            return obsDTOs;
        }

        /// <summary>
        /// Get all observations reported over last number of hours for the given ICAOs
        /// </summary>
        /// <param name="icaos"></param>
        /// <param name="numHours"></param>
        /// <returns></returns>
        public async Task<List<ObservationDto>> GetPreviousHoursObservationsAsync(IList<string> icaos, int numHours)
        {
            var stations = String.Join("%20", icaos);
            var url = URLConstants.BaseURL + URLConstants.BasePath +
               URLConstants.PreviousHoursMETARs.Replace("{format}", _parserType.Name)
               .Replace("{icaos}", stations)
               .Replace("{hours}", numHours.ToString(_formatProvider));
            var response = await _connector.GetAsync(url).ConfigureAwait(false);

            return ConvertToDTO(response, icaos);
        }

        /// <summary>
        /// Converts the pre-formatted string into the one or more Observation
        /// objects
        /// </summary>
        /// <param name="data"></param>
        /// <param name="icaos"></param>
        /// <returns></returns>
        private List<ObservationDto> ConvertToDTO(string data,
            IList<string> icaos)
        {
            IParser<ObservationDto> parser;
            if (_parserType == ParserType.XML)
            {
                parser = new ParseMETARXML();
            }
            else
            {
                parser = new ParseMETARCSV();
            }

            return parser.Parse(data, icaos);
        }

    }
}
