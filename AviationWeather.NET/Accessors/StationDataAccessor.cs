using BNolan.AviationWx.NET.Connectors;
using BNolan.AviationWx.NET.Models.Constants;
using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Parsers;
using BNolan.AviationWx.NET.Validators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BNolan.AviationWx.NET.Accessors
{
    public class StationDataAccessor
    {
        private readonly IConnector _connector;
        private readonly ParserType _parserType;
        private readonly IFormatProvider _formatProvider = new CultureInfo(ParserConstants.StringCulture);

        /// <summary>
        /// Configure the class to use the default parser type and connector
        /// </summary>
        public StationDataAccessor()
        {
            _parserType = ParserType.XML;
            _connector = new Http();
        }

        /// <summary>
        /// Configure the class to use the defined parser and default connector
        /// </summary>
        /// <param name="parser"></param>
        public StationDataAccessor(ParserType parser)
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
        public StationDataAccessor(ParserType parser, IConnector connector)
            : this(parser)
        {
            _connector = connector;
        }

        /// <summary>
        /// Retrieves the Station Information for the supplied ICAOs
        /// </summary>
        /// <param name="icaos"></param>
        public async Task<List<StationInfoDto>> GetStationInformationAsync(IList<string> icaos)
        {
            var formattedICAOs = String.Join("%20", icaos);

            var url = URLConstants.BaseURL + URLConstants.BasePath +
                URLConstants.StationInfo.Replace("{format}", _parserType.Name)
                .Replace("{icao}", formattedICAOs);
            var result = await _connector.GetAsync(url);

            var obsDTOs = ConvertToDTO(result, icaos);

            return obsDTOs;
        }

        /// <summary>
        /// Retrieves Station Information for all of the ICAOs located within the given list
        /// of states and provinces
        /// </summary>
        /// <param name="abbreviations">List of two letter abbreviations for states and provinces</param>
        /// <returns>Empty list if the abbreviation is not recognized</returns>
        public async Task<List<StationInfoDto>> GetStationsByStateOrProvinceAsync(IList<string> abbreviations)
        {
            // API expects states and provices to be prefixed with an AT symbol
            var cleanedAbbrevations = abbreviations.Select(a => $"@{a.Trim().Replace("@", String.Empty)}");
            var stations = String.Join("%20", abbreviations);
            var url = URLConstants.BaseURL + URLConstants.BasePath +
               URLConstants.StationInfo.Replace("{format}", _parserType.Name)
               .Replace("{icao}", stations);
            var response = await _connector.GetAsync(url);

            return ConvertToDTO(response);
        }

        /// <summary>
        /// Retrieves Station Information for all of the ICAOs located within the given list
        /// of countries
        /// </summary>
        /// <param name="abbreviations">List of two letter abbreviations for countries</param>
        /// <returns>Empty list if the abbreviation is not recognized</returns>
        public async Task<List<StationInfoDto>> GetStationsByCountryAsync(IList<string> abbreviations)
        {
            // API expects countries to be prefixed with a TILDA symbol
            var cleanedCodes = abbreviations.Select(a => $"~{a.Trim().Replace("~", String.Empty)}");
            var stations = String.Join("%20", cleanedCodes);
            var url = URLConstants.BaseURL + URLConstants.BasePath +
               URLConstants.StationInfo.Replace("{format}", _parserType.Name)
               .Replace("{icao}", stations);
            var response = await _connector.GetAsync(url);

            return ConvertToDTO(response);
        }

        /// <summary>
        /// Retrieves all stations that are located within the circle defined by the latitude and longitude
        /// for the center and distance defining the radius to search.
        /// </summary>
        /// <param name="latitude">-90.0 to 90.0</param>
        /// <param name="longitude">-180.0 to 180.0</param>
        /// <param name="distance">Statute miles</param>
        /// <returns>Empty list if no stations are found in the area defined</returns>
        public async Task<List<StationInfoDto>> GetStationsNearAsync(double latitude, double longitude, int distance)
        {
            var url = URLConstants.BaseURL + URLConstants.BasePath +
              URLConstants.RadialSearch.Replace("{format}", _parserType.Name)
                .Replace("{latitude}", latitude.ToString())
                .Replace("{longitude}", longitude.ToString())
                .Replace("{distance}", distance.ToString());
            var response = await _connector.GetAsync(url);

            return ConvertToDTO(response);
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
            double minLat = cornerTwoLatitude;
            double minLon = cornerTwoLongitude;
            double maxLat = cornerOneLatitude;
            double maxLon = cornerOneLongitude;
            if (cornerOneLatitude < cornerTwoLatitude)
            {
                minLat = cornerOneLatitude;
                maxLat = cornerTwoLatitude;
            }
            if (cornerOneLongitude < cornerTwoLongitude)
            {
                minLon = cornerOneLongitude;
                maxLon = cornerTwoLongitude;
            }
            var url = URLConstants.BaseURL + URLConstants.BasePath +
              URLConstants.BoxSearch.Replace("{format}", _parserType.Name)
                .Replace("{minLat}", minLat.ToString())
                .Replace("{minLon}", minLon.ToString())
                .Replace("{maxLat}", maxLat.ToString())
                .Replace("{maxLon}", maxLon.ToString());
            var response = await _connector.GetAsync(url);

            return ConvertToDTO(response);
        }

        /// <summary>
        /// Converts the pre-formatted string into the one or more StationInfo objects
        /// objects
        /// </summary>
        /// <param name="data"></param>
        /// <param name="icaos"></param>
        /// <returns></returns>
        private List<StationInfoDto> ConvertToDTO(string data,
            IList<string> icaos = null)
        {
            if (icaos == null)
            {
                icaos = new List<string>();
            }

            IParser<StationInfoDto> parser = null;
            if (_parserType == ParserType.XML)
            {
                parser = new ParseStationInfoXML();
            }
            else
            {
                parser = new ParseStationInfoCSV();
            }

            return parser.Parse(data, icaos);
        }
    }
}
