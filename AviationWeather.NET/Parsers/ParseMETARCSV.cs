using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    var existingStation = csvObs.Where(o => String.Equals(o.ICAO, stationObs.ICAO,
                        StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
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
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.Auto);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.auto_station)
                {
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.AutoStation);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.cloud_base_ft_agl)
                {
                    obs.SkyCondition[obs.SkyCondition.Count() - 1].CloudBaseFt = int.Parse(fieldVal);
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
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
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
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.LightningSensorOff);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.maintenance_indicator_on)
                {
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
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
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
                    if (IsFlagEnabled(fieldVal))
                    {
                        obs.QualityControlFlags.Add(QualityControlFlagType.NoSignal);
                    }
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.observation_time)
                {
                    obs.ObsTime = DateTime.Parse(fieldVal);
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
                    /*
                     * TODO: Check if a specific value is in the field to designate the flag is active
                     */
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
                if (fieldOrder[idx] == METARCSVField.sky_cover)
                {
                    var skyCond = new SkyConditionDto();
                    skyCond.SkyCondition = SkyConditionType.GetByName(fieldVal);
                    obs.SkyCondition.Add(skyCond);
                    continue;
                }
                if (fieldOrder[idx] == METARCSVField.snow_in)
                {
                    // Need to add snow parsing
                    //obs._ = (fieldVal);
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
                    obs.Wind = new WindDto()
                    {
                        Direction_D = int.Parse(fieldVal)
                    };
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

            return dto;
        }

        public bool IsFlagEnabled(string value)
        {
            return !String.IsNullOrWhiteSpace(value)
                && bool.Parse(value);
        }
    }
}
