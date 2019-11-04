using AviationWx.NET.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AviationWx.NET.Parsers
{
    public static class ParserHelpers
    {
        private static CultureInfo _cultureInfo = CultureInfo.GetCultureInfo(ParserConstants.StringCulture);

        /// <summary>
        /// If the isPresent flag is true then it gets the float value, otherwise null
        /// </summary>
        /// <param name="isPresent"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Nullable<float> GetValue(bool isPresent, float value)
        {
            if (isPresent)
            {
                return value;
            }

            return null;
        }

        /// <summary>
        /// If the isPresent flag is true then it gets the int value, otherwise null
        /// </summary>
        /// <param name="isPresent"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? GetValue(bool isPresent, int value)
        {
            if (isPresent)
            {
                return value;
            }

            return null;
        }

        public static DateTime GetDateTime(string dateTimeString)
        {
            var dateTime = ParserConstants.DefaultDateTime;

            if (!String.IsNullOrEmpty(dateTimeString)
                || !DateTime.TryParseExact(dateTimeString, ParserConstants.DateTimeFormat, null, DateTimeStyles.AssumeUniversal, out dateTime)){
                dateTime = ParserConstants.DefaultDateTime;
            }

            return dateTime;
        }

        public static List<ObservationDto> GetMissingStations(List<ObservationDto> foundObservations, IList<string> requestedICAOs)
        {
            var foundICAOs = foundObservations.Select(f => f.ICAO.Trim().ToUpper(_cultureInfo)).ToList();
            var missingICAOs = requestedICAOs.Where(r => !foundICAOs.Contains(r.Trim().ToUpper(_cultureInfo))).ToList();
            return missingICAOs.Select(m => new ObservationDto() { ICAO = m }).ToList();
        }
        

        public static List<ForecastDto> GetMissingStations(List<ForecastDto> foundObservations, IList<string> requestedICAOs)
        {
            var foundICAOs = foundObservations.Select(f => f.ICAO.Trim().ToUpper(_cultureInfo)).ToList();
            var missingICAOs = requestedICAOs.Where(r => !foundICAOs.Contains(r.Trim().ToUpper(_cultureInfo))).ToList();
            return missingICAOs.Select(m => new ForecastDto() { ICAO = m }).ToList();

        }
    }
}
