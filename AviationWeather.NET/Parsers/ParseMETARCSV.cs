using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AviationWx.NET.Parsers
{
    public class ParseMETARCSV : IParser<ObservationDto>
    {

        public List<ObservationDto> Parse(string data, IList<string> icaos)
        {
            if (String.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException($"'{nameof(data)}' cannot be null or empty.");
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
        public List<METARCSVField> GetFieldOrder(string line)
        {

            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException($"'{nameof(line)}' cannot be null or empty.");
            }

            var fields = line.Split(ParserConstants.CSVSplitCharacter);
            return fields.Select(f => METARCSVField.ByName(f.Trim())).ToList();
        }

        public ObservationDto GetObservation(string line, List<METARCSVField> fieldOrder)
        {
            var dto = new ObservationDto()
            {
                GeographicData = new GeographicDataDto(),
                METAR = new List<METARDto>()
                {
                    new METARDto()
                    {
                        _3HourObsData = new _3HourObsData(),
                        _6HourData = new _6HourObsDataDto(),
                        _24HourData = new _24HourObsDataDto(),
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
                if (fieldOrder[idx] == METARCSVField.unknown
                    || String.IsNullOrWhiteSpace(fields[idx]))
                {
                    continue;
                }

                var fieldVal = fields[idx].Trim();

                if (fieldOrder[idx] == METARCSVField.altim_in_hg)
                {
                    obs.Altimeter_Hg = float.Parse(fieldVal);
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
                    obs.SkyCondition[obs.SkyCondition.Count() - 1].CloudBase_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.sky_cover)
                {
                    obs.SkyCondition.Add(new SkyConditionDto()
                    {
                        SkyCondition = SkyConditionType.GetByName(fieldVal)
                    });
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.dewpoint_c)
                {
                    obs.Dewpoint_C = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.elevation_m)
                {
                    dto.GeographicData.Elevation_M = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.flight_category)
                {
                    obs.FlightCagegory = FlightCategoryType.GetByName(fieldVal);
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
                    obs._24HourData.MaxTemperature_C = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.maxT_c)
                {
                    obs.TemperatureRange.MaxTemperature_C = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.metar_type)
                {
                    obs.ObsType = METARType.GetByName(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.minT24hr_c)
                {
                    obs._24HourData.MinTemperature_C = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.minT_c)
                {
                    obs.TemperatureRange.MinTemperature_C = float.Parse(fieldVal);
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
                    obs.ObsTime = ParserHelpers.GetDateTime(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.pcp24hr_in)
                {
                    obs._24HourData.Precipitation_In = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.pcp3hr_in)
                {
                    obs._3HourObsData.Precipitation_In = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.pcp6hr_in)
                {
                    obs._6HourData.Precipitation_In = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.precip_in)
                {
                    obs.Precipitation_In = float.Parse(fieldVal);
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
                    obs.SeaLevelPressure_Mb = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.snow_in)
                {
                    obs.Snow_In = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.station_id)
                {
                    dto.ICAO = fieldVal;
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.temp_c)
                {
                    obs.Temperature_C = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.three_hr_pressure_tendency_mb)
                {
                    obs._3HourObsData.PressureTendency_Mb = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.vert_vis_ft)
                {
                    obs.VerticalVisibility_Ft = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.visibility_statute_mi)
                {
                    obs.Visibility_SM = float.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wind_dir_degrees)
                {
                    obs.Wind.Direction_D = int.Parse(fieldVal);                    
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wind_gust_kt)
                {
                    obs.Wind.Gust_Kt = int.Parse(fieldVal);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.wind_speed_kt)
                {
                    obs.Wind.Speed_Kt = int.Parse(fieldVal);
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

        public bool IsFlagEnabled(string value)
        {
            return !String.IsNullOrWhiteSpace(value)
                && bool.Parse(value);
        }
        
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
            if (dto.Wind.Direction_D == null
                && dto.Wind.Speed_Kt == null
                && dto.Wind.Gust_Kt == null)
            {
                dto.Wind = null;
            }
        }

        private void ResetTemperatureRangeIfNullValues(METARDto dto)
        {
            if (dto.TemperatureRange.MaxTemperature_C == null
                && dto.TemperatureRange.MinTemperature_C == null)
            {
                dto.TemperatureRange = null;
            }
        }

        private void Reset3HourDataIfNullValues(METARDto dto)
        {
            if (dto._3HourObsData.Precipitation_In == null
                && dto._3HourObsData.PressureTendency_Mb == null)
            {
                dto._3HourObsData = null;
            }
        }

        private void Reset6HourDataIfNullValues(METARDto dto)
        {
            if (dto._6HourData.Precipitation_In == null)
            {
                dto._6HourData = null;
            }
        }

        private void Reset24HourDataIfNullValues(METARDto dto)
        {
            if (dto._24HourData.MaxTemperature_C == null
                && dto._24HourData.MinTemperature_C == null
                && dto._24HourData.Precipitation_In == null)
            {
                dto._24HourData = null;
            }
        }
    }
}
