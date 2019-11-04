using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviationWx.NET.Parsers
{
    public class ParseTAFCSV : IParser<ForecastDto>
    {
        public List<ForecastDto> Parse(string data, IList<string> icaos)
        {
            if (String.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException($"'{nameof(data)}' cannot be null or empty.");
            }

            var tafDto = new List<ForecastDto>();
            var foundHeader = false;
            var fieldOrder = new List<TAFCSVField>();

            var splitData = data.Split(new char[] { '\n' });

            // Expect the format of the file to be the following
            // Top few lines are status/error details on the request
            // Header line with all of the columns defined
            // Each line after is an individual observation for any of the ICAOs in the list in chronological order
            // with the most recent observation first
            foreach (var line in splitData)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (!foundHeader
                    && line.Contains(TAFCSVField.raw_text.Name))
                {
                    fieldOrder = GetFieldOrder(line);
                    if (fieldOrder.Count > 0)
                    {
                        foundHeader = true;
                    }
                }
                else if (foundHeader)
                {
                    var stationFcst = GetForecast(line, fieldOrder);
                    var existingStation = tafDto.Where(o => String.Equals(o.ICAO, stationFcst.ICAO,
                        StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (existingStation == null)
                    {
                        tafDto.Add(stationFcst);
                    }
                    else
                    {
                        existingStation.TAF.Add(stationFcst.TAF.FirstOrDefault());
                    }
                }
            }

            tafDto.AddRange(ParserHelpers.GetMissingStations(tafDto, icaos));

            return tafDto;
        }

        /// <summary>
        /// Builds a list with the order of the fields found based on the 
        /// match between the METARCSVField values and the comma-separated
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public List<TAFCSVField> GetFieldOrder(string line)
        {

            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"'{nameof(line)}' cannot be null or empty.");
            }

            var fields = line.Split(ParserConstants.CSVSplitCharacter);
            return fields.Select(f => TAFCSVField.ByName(f.Trim())).ToList();
        }


        public ForecastDto GetForecast(string line, List<TAFCSVField> fieldOrder)
        {
            var dto = new ForecastDto()
            {
                GeographicData = new GeographicDataDto(),
                TAF = new List<TAFDto>()
                {
                    new TAFDto()
                }
            };

            var taf = dto.TAF[0];
            TAFLineDto tafLine = new TAFLineDto();
            var fields = line.Split(ParserConstants.CSVSplitCharacter);
            for (var idx = 0; idx < fieldOrder.Count && idx < fields.Count(); idx++)
            {
                if (fieldOrder[idx] == TAFCSVField.fcst_time_from
                    && String.IsNullOrWhiteSpace(fields[idx]))
                {
                    // We've read all fields associated with this forecast so bail out early
                    break;
                }

                // Skip all unknown and empty fields
                if (fieldOrder[idx] == TAFCSVField.unknown
                    || String.IsNullOrWhiteSpace(fields[idx]))
                {
                    continue;
                }

                var fieldVal = fields[idx].Trim();

                if (fieldOrder[idx] == TAFCSVField.raw_text)
                {
                    taf.RawTAF = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.altim_in_hg)
                {
                    tafLine.Altimeter_Hg = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.bulletin_time)
                {
                    taf.BulletinTime = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.change_indicator)
                {
                    tafLine.ForecastType = ChangeIndicatorType.GetByName(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.cloud_base_ft_agl)
                {
                    tafLine.SkyCondition[tafLine.SkyCondition.Count() - 1].CloudBase_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.sky_cover)
                {
                    tafLine.SkyCondition.Add(new SkyConditionDto()
                    {
                        SkyCondition = SkyConditionType.GetByName(fieldVal)
                    });
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.fcst_time_from)
                {
                    // This should be made safe, we are assuming all new DateTime objects
                    // have the same date
                    if (tafLine.ForecastTimeStart > new DateTime())
                    {
                        taf.TAFLine.Add(tafLine);
                        tafLine = new TAFLineDto();
                    }
                    tafLine.ForecastTimeStart = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.fcst_time_to)
                {
                    tafLine.ForecastTimeEnd = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.icing_intensity)
                {
                    tafLine.IcingHazards.Add(new IcingDto()
                    {
                        Intensity = fieldVal
                    });
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.icing_max_alt_ft_agl)
                {
                    tafLine.IcingHazards[tafLine.IcingHazards.Count() - 1].MaxAltitude_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.icing_min_alt_ft_agl)
                {
                    tafLine.IcingHazards[tafLine.IcingHazards.Count() - 1].MinAltitude_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.issue_time)
                {
                    taf.IssuedTime = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.max_or_min_temp_c)
                {
                    var tempC = float.Parse(fieldVal);
                    if (tafLine.TemperatureRange == null)
                    {
                        tafLine.TemperatureRange = new TemperatureRangeDto()
                        {
                            MaxTemperature_C = tempC
                        };
                    }
                    else
                    {
                        if (tempC > tafLine.TemperatureRange.MaxTemperature_C)
                        {
                            tafLine.TemperatureRange.MinTemperature_C = tafLine.TemperatureRange.MaxTemperature_C;
                            tafLine.TemperatureRange.MaxTemperature_C = tempC;
                        }
                        else
                        {
                            tafLine.TemperatureRange.MinTemperature_C = tempC;
                        }
                    }
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.not_decoded)
                {
                    tafLine.NotDecoded = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.probability)
                {
                    tafLine.Probability = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.remarks)
                {
                    taf.Remarks = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.sfc_temp_c)
                {
                    tafLine.SurfaceTemperature_C = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.station_id)
                {
                    dto.ICAO = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.time_becoming)
                {
                    tafLine.TimeBecoming = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.turbulence_intensity)
                {
                    tafLine.TurbulenceHazards.Add(new TurbulenceDto()
                    {
                        Intensity = fieldVal
                    });
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.turbulence_max_alt_ft_agl)
                {
                    tafLine.TurbulenceHazards[tafLine.TurbulenceHazards.Count() - 1].MaxAltitude_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.turbulence_min_alt_ft_agl)
                {
                    tafLine.TurbulenceHazards[tafLine.TurbulenceHazards.Count() - 1].MinAltitude_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.valid_time)
                {
                    ///TODO: Temperature valid time, need to determine how this should be handled
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.valid_time_from)
                {
                    taf.ValidTimeStart = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.valid_time_to)
                {
                    taf.ValidTimeEnd = DateTime.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.vert_vis_ft)
                {
                    tafLine.VerticalVisibility_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.visibility_statute_mi)
                {
                    tafLine.Visibility_SM = float.Parse(fieldVal);
                    continue;
                }

                if (fieldOrder[idx] == TAFCSVField.elevation_m)
                {
                    dto.GeographicData.Elevation_M = float.Parse(fieldVal);
                    continue;
                }

                if (fieldOrder[idx] == TAFCSVField.latitude)
                {
                    dto.GeographicData.Latitude = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.longitude)
                {
                    dto.GeographicData.Longitude = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wind_dir_degrees)
                {
                    tafLine.Wind = new WindDto()
                    {
                        Direction_D = int.Parse(fieldVal)
                    };
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wind_gust_kt)
                {
                    tafLine.Wind.Gust_Kt = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wind_speed_kt)
                {
                    tafLine.Wind.Speed_Kt = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wx_string)
                {
                    tafLine.Weather = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wind_shear_hgt_ft_agl)
                {
                    tafLine.WindShear = new WindShearDto()
                    {
                        Height_Ft = int.Parse(fieldVal)
                    };
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wind_shear_dir_degrees)
                {
                    tafLine.WindShear.Direction_D = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == TAFCSVField.wind_shear_speed_kt)
                {
                    tafLine.WindShear.Speed_Kt = int.Parse(fieldVal);
                    continue;
                }
            }

            // Add the most recently parsed line if it has valid data
            if (tafLine.ForecastTimeStart > new DateTime())
            {
                dto.TAF[0].TAFLine.Add(tafLine);
            }

            return dto;
        }
    }
}
