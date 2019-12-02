using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Models.XML.METAR;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BNolan.AviationWx.NET.Parsers
{
    public class ParseMETARXML : IParser<ObservationDto>
    {
        private CultureInfo _cultureInfo = CultureInfo.GetCultureInfo(ParserConstants.StringCulture);

        #region Public

        public List<ObservationDto> Parse(string data, IList<string> icaos)
        {
            var serializer = new XmlSerializer(typeof(response));
            response responseObj = null;
            using (var streamReader = new StringReader(data))
            {
                responseObj = serializer.Deserialize(streamReader) as response;
            }

            return ConvertToDTO(responseObj, icaos);
        }

        #endregion Public 

        #region Private 

        private List<ObservationDto> ConvertToDTO(response xmlObjs,
            IList<string> icaos)
        {
            var dtos = new List<ObservationDto>();
            ObservationDto obs = null;
            if (xmlObjs.data?.METAR != null)
            {
                foreach (var metarXML in xmlObjs.data.METAR)
                {
                    obs = dtos.Where(o => o.ICAO == metarXML.station_id).FirstOrDefault();
                    if (obs == null)
                    {
                        obs = new ObservationDto();
                        ParseIdentifier(obs, metarXML);
                        ParseGeographicData(obs, metarXML);
                        dtos.Add(obs);
                    }
                    var metarDTO = new METARDto();
                    ParseCurrentWeatherData(metarDTO, metarXML);
                    Parse3HourWeatherData(metarDTO, metarXML);
                    Parse6HourWeatherData(metarDTO, metarXML);
                    Parse24HourWeatherData(metarDTO, metarXML);
                    ParseQualityControlFlags(metarDTO, metarXML);
                    obs.METAR.Add(metarDTO);
                }
            }

            dtos.AddRange(ParserHelpers.GetMissingStations(dtos, icaos));
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
        private void ParseGeographicData(ObservationDto dto, METAR xml)
        {
            dto.GeographicData = new GeographicDataDto()
            {
                Latitude = xml.latitude,
                Longitude = xml.longitude,
                Elevation = xml.elevation_m
            };
        }

        /// <summary>
        /// Trnasfers the core weather observation data
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseCurrentWeatherData(METARDto dto, METAR xml)
        {
            dto.Altimeter = xml.altim_in_hg;
            dto.Dewpoint = xml.dewpoint_c;
            dto.ObsTime = ParserHelpers.ParseDateTime(xml.observation_time);
            dto.Precipitation = ParserHelpers.GetValue(xml.precip_inSpecified, xml.precip_in);
            dto.Snow = ParserHelpers.GetValue(xml.snow_inSpecified, xml.snow_in);
            dto.RawMETAR = xml.raw_text;
            dto.SeaLevelPressure = xml.sea_level_pressure_mb;
            dto.SkyCondition.AddRange(xml.sky_condition.Select(sc => new SkyConditionDto() { SkyCondition = SkyConditionType.ByName(sc.sky_cover), CloudBase = sc.cloud_base_ft_agl }));
            dto.Temperature = xml.temp_c;
            dto.VerticalVisibility = ParserHelpers.GetValue(xml.vert_vis_ftSpecified, xml.vert_vis_ft);
            dto.Visibility = xml.visibility_statute_mi;
            dto.Weather = xml.wx_string;
            dto.Wind = new WindDto()
            {
                Direction = xml.wind_dir_degrees,
                Gust = ParserHelpers.GetValue(xml.wind_gust_ktSpecified, xml.wind_gust_kt),
                Speed = xml.wind_speed_kt,
            };
            dto.FlightCagegory = FlightCategoryType.ByName(xml.flight_category);
            dto.ObsType = METARType.ByName(xml.metar_type);
            if (xml.maxT_cSpecified || xml.minT_cSpecified)
            {
                dto.TemperatureRange = new TemperatureRangeDto();
                dto.TemperatureRange.MaxTemperature = ParserHelpers.GetValue(xml.maxT_cSpecified, xml.maxT_c);
                dto.TemperatureRange.MinTemperature = ParserHelpers.GetValue(xml.minT_cSpecified, xml.minT_c);
            }
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
                dto.ThreeHourObsData = new ThreeHourObsData();
                dto.ThreeHourObsData.Precipitation = ParserHelpers.GetValue(xml.pcp3hr_inSpecified, xml.pcp3hr_in);
                dto.ThreeHourObsData.PressureTendency = ParserHelpers.GetValue(xml.three_hr_pressure_tendency_mbSpecified, xml.three_hr_pressure_tendency_mb);
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
                dto.SixHourData = new SixHourObsDataDto()
                {
                    Precipitation = xml.pcp6hr_in
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
                dto.TwentyFourHourData = new TwentyFourHourObsDataDto();
                dto.TwentyFourHourData.Precipitation = ParserHelpers.GetValue(xml.pcp24hr_inSpecified, xml.pcp24hr_in);
                dto.TwentyFourHourData.MaxTemperature = ParserHelpers.GetValue(xml.maxT24hr_cSpecified, xml.maxT24hr_c);
                dto.TwentyFourHourData.MinTemperature = ParserHelpers.GetValue(xml.minT24hr_cSpecified, xml.minT24hr_c);
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
