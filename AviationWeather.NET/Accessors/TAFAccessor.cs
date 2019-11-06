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

        public TAFAccessor()
        {
            _parserType = ParserType.XML;
            _connector = new Http();
        }

        public TAFAccessor(ParserType parser)
            : this()
        {
            _parserType = parser;
        }

        public TAFAccessor(ParserType parser, IConnector connector)
        {
            _parserType = parser;
            _connector = connector;
        }

        /// <summary>
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
