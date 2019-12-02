using BNolan.AviationWx.NET.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BNolan.AviationWx.NET.Parsers
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
        public static float? GetValue(bool isPresent, float value)
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

        public static DateTimeOffset ParseDateTime(string dateTimeString)
        {
            var dateTimeOffset = ParserConstants.DefaultDateTime;
            CultureInfo enUS = new CultureInfo("en-US");
            if (String.IsNullOrEmpty(dateTimeString)
                || !DateTimeOffset.TryParseExact(dateTimeString, ParserConstants.DateTimeFormat, enUS,
                DateTimeStyles.AssumeUniversal, out dateTimeOffset)){
                dateTimeOffset = ParserConstants.DefaultDateTime;
            }

            return dateTimeOffset;
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
