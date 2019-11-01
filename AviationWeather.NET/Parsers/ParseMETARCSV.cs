using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviationWx.NET.Parsers
{
    public class ParseMETARCSV : IParser<ObservationDto>
    {
        private const char SPLIT_CHAR = ',';
        public List<ObservationDto> Parse(string data, IList<string> icaos)
        {
            var csvObs = new List<ObservationDto>();
            var foundHeader = false;
            var fieldOrder = new List<METARCSVField>();

            foreach (var line in data.Split('\r'))
            {
                if (!foundHeader
                    && line.Contains(METARCSVField.raw_text.Name))
                {
                    fieldOrder = GetFieldOrder(line);
                }
                else if (foundHeader)
                {
                    var stationObs = GetObservation(line, fieldOrder);
                    var existingStation = csvObs.Where(o => String.Equals(o.ICAO, stationObs.ICAO, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (existingStation == null)
                    {
                        csvObs.Add(stationObs);
                    }
                    else
                    {
                        existingStation.METAR.Add(stationObs.METAR.FirstOrDefault());
                    }
                }
            }

            return csvObs;
        }

        public List<METARCSVField> GetFieldOrder(string line)
        {

            var fields = line.Split(SPLIT_CHAR);
            return fields.Select(f => METARCSVField.ByName(f.Trim())).ToList();
        }

        private ObservationDto GetObservation(string line, List<METARCSVField> fieldOrder)
        {
            var dto = new ObservationDto()
            {
                GeographicData = new GeographicDataDto(),
                METAR = new List<METARDto>()
                {
                    new METARDto()
                }
            };
            var obs = dto.METAR[0];
            var fields = line.Split(SPLIT_CHAR);
            for(var idx = 0; idx < fieldOrder.Count && idx < fields.Count(); idx++)
            {
                // Skip all unknown and empty fields
                if (fieldOrder[idx] == METARCSVField.unknown
                    || String.IsNullOrWhiteSpace(fields[idx]))
                {
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.altim_in_hg)
                {
                    obs.Altimeter_Hg = float.Parse(fields[idx]);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.auto)
                {
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.auto_station)
                {
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.cloud_base_ft_agl)
                {
                    obs.SkyCondition[obs.SkyCondition.Count() - 1].CloudBaseFt = int.Parse(fields[idx]);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.dewpoint_c)
                {
                    obs.Dewpoint_C = float.Parse(fields[idx]);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.elevation_m)
                {
                    dto.GeographicData.Elevation_M = float.Parse(fields[idx]);
                    continue;
                }
            }

            return dto;
        }
    }
}
