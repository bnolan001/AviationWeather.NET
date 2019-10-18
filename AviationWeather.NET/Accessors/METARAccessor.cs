using AviationWx.NET.Connectors;
using AviationWx.NET.Models.Constants;
using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AviationWx.NET.Accessors
{
    public class METARAccessor
    {
        private readonly IConnector _connector;
        private readonly ParserType _parserType;

        public METARAccessor()
        {
            _parserType = ParserType.XML;
            _connector = new Http();
        }

        public METARAccessor(ParserType parser)
            : this()
        {
            _parserType = parser;
        }

        public METARAccessor(ParserType parser, IConnector connector)
        {
            _parserType = parser;
            _connector = connector;
        }

        /// <summary>
        /// REF: https://aviationweather.gov/adds/dataserver_current/httpparam?dataSource=metars&requestType=retrieve&format=xml&hoursBeforeNow=12&mostRecent=true&stationString=PHNL%20KSEA
        /// </summary>
        /// <param name="icaos"></param>
        public async Task<ObservationDto> GetLatestObservationAsync(string icao)
        {
            var url = URLConstants.BaseURL + URLConstants.BasePath +
                URLConstants.LatestMETAR.Replace("{format}", _parserType.Name)
                .Replace("{icao}", icao);
            var response = await _connector.GetAsync(url);
            return ConvertToDTO(response, new List<string> { icao }).FirstOrDefault();
        }

        public async Task<List<ObservationDto>> GetPreviousHoursObservationss(IList<string> icaos, int numHours)
        {
            var stations = String.Join("%20", icaos);
            var url = URLConstants.BaseURL + URLConstants.BasePath +
               URLConstants.PreviousHoursMETARs.Replace("{format}", _parserType.Name)
               .Replace("{icaos}", stations)
               .Replace("{hours}", numHours.ToString());
            var response = await _connector.GetAsync(url);

            return ConvertToDTO(response, icaos);
        }

        private List<ObservationDto> ConvertToDTO(string data,
            IList<string> icaos)
        {
            IParser<ObservationDto> parser = null;
            if (_parserType == ParserType.XML)
            {
                parser = new ParseMETARXML();
            }

            return parser.Parse(data, icaos);
        }

    }
}
