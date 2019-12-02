using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Parsers
{
    public class ParseMETARCSV : IParser<ObservationDto>
    {

        public List<ObservationDto> Parse(string data, IList<string> icaos)
        {
            if (String.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException($"'{nameof(data)}' cannot be null or empty.");
            }

            if (icaos == null 
                || icaos.Count == 0)
            {
                throw new ArgumentException($"'{nameof(icaos)}' cannot be null or empty.");
            }

            var obsDto = new List<ObservationDto>();
            var foundHeader = false;
            var fieldOrder = new List<METARCSVField>();

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
                    && line.Contains(METARCSVField.raw_text.Name))
                {
                    fieldOrder = GetFieldOrder(line);
                    if (fieldOrder.Count > 0)
                    {
                        foundHeader = true;
                    }
                }
                else if (foundHeader)
                {
                    var stationObs = GetObservation(line, fieldOrder);
                    var existingStation = obsDto.Where(o => String.Equals(o.ICAO, stationObs.ICAO,
                        StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (existingStation == null)
                    {
                        obsDto.Add(stationObs);
                    }
                    else
                    {
                        existingStation.METAR.Add(stationObs.METAR.FirstOrDefault());
                    }
                }
            }

            obsDto.AddRange(ParserHelpers.GetMissingStations(obsDto, icaos));

            return obsDto;
        }

        /// <summary>
        /// Builds a list with the order of the fields found based on the 
        /// match between the METARCSVField values and the comma-separated
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private List<METARCSVField> GetFieldOrder(string line)
        {

            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"'{nameof(line)}' cannot be null or empty.");
            }

            var fields = line.Split(ParserConstants.CSVSplitCharacter);
            return fields.Select(f => METARCSVField.ByName(f.Trim())).ToList();
        }

        private ObservationDto GetObservation(string line, List<METARCSVField> fieldOrder)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"'{nameof(line)}' cannot be null or empty.");
            }

            if (fieldOrder == null
                || fieldOrder.Count == 0)
            {
                throw new ArgumentException($"'{nameof(line)}' cannot be null or empty");
            }

            var dto = new ObservationDto()
            {
                GeographicData = new GeographicDataDto(),
                METAR = new List<METARDto>()
                {
                    new METARDto()
                    {
                        ThreeHourObsData = new ThreeHourObsData(),
                        SixHourData = new SixHourObsDataDto(),
                        TwentyFourHourData = new TwentyFourHourObsDataDto(),
                        TemperatureRange = new TemperatureRangeDto(),
                        Wind = new WindDto()
                    }
                }
            };
            var obs = dto.METAR[0];
            var fields = line.Split(ParserConstants.CSVSplitCharacter);
            for (var idx = 0; idx < fieldOrder.Count && idx < fields.Count(); idx++)
            {
                // Skip all unknown and empty fields
                if (fieldOrder[idx] == METARCSVField.Unknown
                    || String.IsNullOrWhiteSpace(fields[idx]))
                {
                    continue;
                }

                var fieldVal = fields[idx].Trim();

                if (fieldOrder[idx] == METARCSVField.altim_in_hg)
                {
                    obs.Altimeter = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.auto)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.Auto);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.auto_station)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.AutoStation);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.cloud_base_ft_agl)
                {
                    obs.SkyCondition[obs.SkyCondition.Count() - 1].CloudBase = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.sky_cover)
                {
                    obs.SkyCondition.Add(new SkyConditionDto()
                    {
                        SkyCondition = SkyConditionType.ByName(fieldVal)
                    });
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.dewpoint_c)
                {
                    obs.Dewpoint = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.elevation_m)
                {
                    dto.GeographicData.Elevation = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.flight_category)
                {
                    obs.FlightCagegory = FlightCategoryType.ByName(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.freezing_rain_sensor_off)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.FreezingRainSensorOff);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.latitude)
                {
                    dto.GeographicData.Latitude = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.longitude)
                {
                    dto.GeographicData.Longitude = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.lightning_sensor_off)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.LightningSensorOff);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.maintenance_indicator_on)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.MaintenanceIndicator);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.maxT24hr_c)
                {
                    obs.TwentyFourHourData.MaxTemperature = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.maxT_c)
                {
                    obs.TemperatureRange.MaxTemperature = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.metar_type)
                {
                    obs.ObsType = METARType.ByName(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.minT24hr_c)
                {
                    obs.TwentyFourHourData.MinTemperature = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.minT_c)
                {
                    obs.TemperatureRange.MinTemperature = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.no_signal)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.NoSignal);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.observation_time)
                {
                    obs.ObsTime = ParserHelpers.ParseDateTime(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.pcp24hr_in)
                {
                    obs.TwentyFourHourData.Precipitation = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.pcp3hr_in)
                {
                    obs.ThreeHourObsData.Precipitation = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.pcp6hr_in)
                {
                    obs.SixHourData.Precipitation = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.precip_in)
                {
                    obs.Precipitation = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.present_weather_sensor_off)
                {
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.PresentWeatherSensorOff);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.raw_text)
                {
                    obs.RawMETAR = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.sea_level_pressure_mb)
                {
                    obs.SeaLevelPressure = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.snow_in)
                {
                    obs.Snow = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.station_id)
                {
                    dto.ICAO = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.temp_c)
                {
                    obs.Temperature = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.three_hr_pressure_tendency_mb)
                {
                    obs.ThreeHourObsData.PressureTendency = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.vert_vis_ft)
                {
                    obs.VerticalVisibility = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.visibility_statute_mi)
                {
                    obs.Visibility = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wind_dir_degrees)
                {
                    obs.Wind.Direction = int.Parse(fieldVal);                    
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wind_gust_kt)
                {
                    obs.Wind.Gust = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wind_speed_kt)
                {
                    obs.Wind.Speed = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wx_string)
                {
                    obs.Weather = fieldVal;
                    continue;
                }
            }

            ResetFieldsToNull(obs);

            return dto;
        }

        /// <summary>
        /// Checks to see if the value passed in is set to true.  If it is not
        /// set to a boolean or is set to false then it will return false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsFlagEnabled(string value)
        {
            return !String.IsNullOrWhiteSpace(value)
                && bool.Parse(value);
        }

        #region Reset Fields

        /// <summary>
        /// Because not all properties will have values in each observation
        /// reset those fields that are objects which have no values
        /// </summary>
        /// <param name="dto"></param>
        private void ResetFieldsToNull(METARDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException($"'{nameof(dto)}' cannot be null.");
            }

            ResetWindDataIfNullValues(dto);

            ResetTemperatureRangeIfNullValues(dto);

            Reset3HourDataIfNullValues(dto);

            Reset6HourDataIfNullValues(dto);

            Reset24HourDataIfNullValues(dto);
        }

        private void ResetWindDataIfNullValues(METARDto dto)
        {
            if (dto.Wind.Direction == null
                && dto.Wind.Speed == null
                && dto.Wind.Gust == null)
            {
                dto.Wind = null;
            }
        }

        private void ResetTemperatureRangeIfNullValues(METARDto dto)
        {
            if (dto.TemperatureRange.MaxTemperature == null
                && dto.TemperatureRange.MinTemperature == null)
            {
                dto.TemperatureRange = null;
            }
        }

        private void Reset3HourDataIfNullValues(METARDto dto)
        {
            if (dto.ThreeHourObsData.Precipitation == null
                && dto.ThreeHourObsData.PressureTendency == null)
            {
                dto.ThreeHourObsData = null;
            }
        }

        private void Reset6HourDataIfNullValues(METARDto dto)
        {
            if (dto.SixHourData.Precipitation == null)
            {
                dto.SixHourData = null;
            }
        }

        private void Reset24HourDataIfNullValues(METARDto dto)
        {
            if (dto.TwentyFourHourData.MaxTemperature == null
                && dto.TwentyFourHourData.MinTemperature == null
                && dto.TwentyFourHourData.Precipitation == null)
            {
                dto.TwentyFourHourData = null;
            }
        }

        #endregion Reset Fields

    }
}
