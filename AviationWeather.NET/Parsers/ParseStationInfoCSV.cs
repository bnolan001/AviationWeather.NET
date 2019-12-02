using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Parsers
{
    public class ParseStationInfoCSV : IParser<StationInfoDto>
    {
        public List<StationInfoDto> Parse(string data, IList<string> icaos)
        {
            if (String.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException($"'{nameof(data)}' cannot be null or empty.");
            }

            var stationDtos = new List<StationInfoDto>();
            var foundHeader = false;
            var fieldOrder = new List<StationInfoCSVField>();

            var splitData = data.Split(new char[] { '\n' });

            // Expect the format of the file to be the following
            // Top few lines are status/error details on the request
            // Header line with all of the columns defined
            foreach (var line in splitData)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (!foundHeader
                    && line.Contains(StationInfoCSVField.elevation_m.Name))
                {
                    fieldOrder = GetFieldOrder(line);
                    if (fieldOrder.Count > 0)
                    {
                        foundHeader = true;
                    }
                }
                else if (foundHeader)
                {
                    var stationInfo = GetStationInfo(line, fieldOrder);
                    stationDtos.Add(stationInfo);

                }
            }

            return stationDtos;
        }

        /// <summary>
        /// Builds a list with the order of the fields found based on the 
        /// match between the METARCSVField values and the comma-separated
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private List<StationInfoCSVField> GetFieldOrder(string line)
        {

            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"'{nameof(line)}' cannot be null or empty.");
            }

            var fields = line.Split(ParserConstants.CSVSplitCharacter);
            return fields.Select(f => StationInfoCSVField.ByName(f.Trim())).ToList();
        }


        private StationInfoDto GetStationInfo(string line, List<StationInfoCSVField> fieldOrder)
        {
            if (line == null)
            {
                throw new ArgumentNullException($"'{nameof(line)}' cannot be null.");
            }
            if (fieldOrder == null)
            {
                throw new ArgumentNullException($"'{nameof(fieldOrder)}' cannot be null.");
            }

            var dto = new StationInfoDto()
            {
                GeographicData = new GeographicDataDto(),
            };

            var fields = line?.Split(ParserConstants.CSVSplitCharacter);
            for (var idx = 0; idx < fieldOrder.Count && idx < fields.Length; idx++)
            {

                // Skip all unknown and empty fields
                if (fieldOrder[idx] == StationInfoCSVField.Unknown
                    || String.IsNullOrWhiteSpace(fields[idx]))
                {
                    continue;
                }

                var fieldVal = fields[idx].Trim();

                if (fieldOrder[idx] == StationInfoCSVField.country)
                {
                    dto.Country = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.elevation_m)
                {
                    dto.GeographicData.Elevation = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.latitude)
                {
                    dto.GeographicData.Latitude = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.longitude)
                {
                    dto.GeographicData.Longitude = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.site)
                {
                    dto.Name = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.site_type)
                {
                    dto.SiteType.AddRange(fieldVal.Split(' ').Select(SiteType.ByName));
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.state)
                {
                    dto.State = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.station_id)
                {
                    dto.ICAO = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == StationInfoCSVField.wmo_id)
                {
                    dto.WMOID = int.Parse(fieldVal);
                    continue;
                }
            }

            return dto;
        }
    }
}
