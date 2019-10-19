﻿using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.Enums;
using AviationWx.NET.Models.XML.AWMETAR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AviationWx.NET.Parsers
{
    public class ParseMETARXML : IParser<ObservationDto>
    {
        #region Public

        public List<ObservationDto> Parse(string data, IList<string> icaos)
        {
            var serializer = new XmlSerializer(typeof(response));
            response responseObj = null;
            using (var streamReader = new StringReader(data))
            {
                responseObj = (response)serializer.Deserialize(streamReader);
            }

            return ConvertToDTO(responseObj, icaos);
        }

        #endregion Public 

        #region Private 

        private List<ObservationDto> ConvertToDTO(response xmlObjs,
            IList<string> icaos)
        {
            var hashSet = new HashSet<string>();
            icaos.All(a => hashSet.Add(a.ToUpper()));

            var dtos = new List<ObservationDto>();
            ObservationDto obs = null;
            if (xmlObjs.data?.METAR != null)
            {
                foreach (var metarXML in xmlObjs.data.METAR)
                {
                    obs = dtos.Where(o => o.ICAO == metarXML.station_id).FirstOrDefault();
                    if (obs == null)
                    {
                        hashSet.Remove(metarXML.station_id.ToUpper());
                        obs = new ObservationDto();
                        dtos.Add(obs);
                    }
                    var metarDTO = new METARDto();
                    ParseIdentifier(obs, metarXML);
                    ParseGeographicData(metarDTO, metarXML);
                    ParseCurrentWeatherData(metarDTO, metarXML);
                    Parse3HourWeatherData(metarDTO, metarXML);
                    Parse6HourWeatherData(metarDTO, metarXML);
                    Parse24HourWeatherData(metarDTO, metarXML);
                    ParseQualityControlFlags(metarDTO, metarXML);
                    obs.METAR.Add(metarDTO);
                }
            }
            foreach(var icao in hashSet)
            {
                dtos.Add(new ObservationDto()
                {
                    ICAO = icao
                });
            }

            return dtos;
        }

        /// <summary>
        /// Transfers the ICAO
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseIdentifier(ObservationDto dto, METAR xml)
        {
            dto.ICAO = xml.station_id;
        }

        /// <summary>
        /// Transfers the Lat/Lon and Elevations
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseGeographicData(METARDto dto, METAR xml)
        {
            dto.GeographicData = new GeographicData()
            {
                Latitude = xml.latitude,
                Longitude = xml.longitude,
                Elevation_M = xml.elevation_m
            };
        }

        /// <summary>
        /// Trnasfers the core weather observation data
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseCurrentWeatherData(METARDto dto, METAR xml)
        {
            dto.Altimeter_Hg = xml.altim_in_hg;
            dto.Dewpoint_C = xml.dewpoint_c;
            dto.ObsTime = DateTime.Parse(xml.observation_time);
            dto.Precipitation_In = xml.precip_in;
            dto.RawMETAR = xml.raw_text;
            dto.SeaLevelPressure_Mb = xml.sea_level_pressure_mb;
            dto.SkyCondition = xml.sky_condition.Select(sc => new SkyConditionDto() { SkyCondition = SkyConditionType.GetByName(sc.sky_cover), CloudBaseFt = sc.cloud_base_ft_agl }).ToList();
            dto.Temperature_C = xml.temp_c;
            dto.VerticalVisibility_Ft = xml.vert_vis_ft;
            dto.Visibility_SM = xml.visibility_statute_mi;
            dto.Weather = xml.wx_string;
            dto.WindDirection_D = xml.wind_dir_degrees;
            dto.WindGust_Kt = xml.wind_gust_kt;
            dto.WindSpeed_Kt = xml.wind_speed_kt;
        }

        /// <summary>
        /// Transfer 3-Hourly data
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void Parse3HourWeatherData(METARDto dto, METAR xml)
        {
            if (xml.pcp3hr_inSpecified || xml.three_hr_pressure_tendency_mbSpecified)
            {
                dto._3HourObsData = new _3HourObsData();
                if (xml.pcp3hr_inSpecified)
                {
                    dto._3HourObsData.Precipitation_In = xml.pcp3hr_in;
                }
                if (xml.pcp3hr_inSpecified)
                {
                    dto._3HourObsData.PressureTendency_Mb = xml.three_hr_pressure_tendency_mb;
                }
            }
        }

        /// <summary>
        /// Transfers 6-hourly data
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void Parse6HourWeatherData(METARDto dto, METAR xml)
        {
            if (xml.pcp6hr_inSpecified)
            {
                dto._6HourData = new _6HourObsDataDto()
                {
                    Precipitation_In = xml.pcp6hr_in
                };
            }
        }

        /// <summary>
        /// Transfers 24-hourly data
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void Parse24HourWeatherData(METARDto dto, METAR xml)
        {
            if (xml.pcp24hr_inSpecified 
                || xml.maxT24hr_cSpecified 
                || xml.minT24hr_cSpecified)
            {
                dto._24HourData = new _24HourObsDataDto();

                if (xml.pcp24hr_inSpecified)
                {
                    dto._24HourData.Precipitation_In = xml.pcp24hr_in;
                }

                if (xml.maxT24hr_cSpecified)
                {
                    dto._24HourData.MaxTemperature_C = xml.maxT24hr_c;
                }

                if (xml.minT24hr_cSpecified)
                {
                    dto._24HourData.MinTemperature_C = xml.minT24hr_c;
                }
            }
        }

        private void ParseQualityControlFlags(METARDto dto, METAR xml)
        {
            if (xml.quality_control_flags.auto != null
                && bool.Parse(xml.quality_control_flags.auto))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.Auto);
            }

            if (xml.quality_control_flags.auto_station != null 
                && bool.Parse(xml.quality_control_flags.auto_station))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.AutoStation);
            }

            if (xml.quality_control_flags.corrected != null
                && bool.Parse(xml.quality_control_flags.corrected))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.Corrected);
            }

            if (xml.quality_control_flags.freezing_rain_sensor_off != null
                && bool.Parse(xml.quality_control_flags.freezing_rain_sensor_off))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.FreezingRainSensorOff);
            }

            if (xml.quality_control_flags.lightning_sensor_off != null
                && bool.Parse(xml.quality_control_flags.lightning_sensor_off))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.LightningSensorOff);
            }

            if (xml.quality_control_flags.maintenance_indicator_on != null 
                && bool.Parse(xml.quality_control_flags.maintenance_indicator_on))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.MaintenanceIndicator);
            }

            if (xml.quality_control_flags.no_signal != null
                && bool.Parse(xml.quality_control_flags.no_signal))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.NoSignal);
            }

            if (xml.quality_control_flags.present_weather_sensor_off != null
                && bool.Parse(xml.quality_control_flags.present_weather_sensor_off))
            {
                dto.QualityControlFlags.Add(QualityControlFlagType.PresentWeatherSensorOff);
            }
        }

        #endregion Private
    }
}
