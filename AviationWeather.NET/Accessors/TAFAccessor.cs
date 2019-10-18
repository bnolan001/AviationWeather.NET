using AviationWx.NET.Connectors;
using AviationWx.NET.Models.Constants;
using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviationWx.NET.Accessors
{
    public class TAFAccessor
    {
        private readonly IConnector _connector;
        private readonly ParserType _parserType;

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
                .Replace("{hours}", hoursBeforeNow.ToString());
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
