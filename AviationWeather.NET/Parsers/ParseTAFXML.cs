using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Models.XML.TAF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BNolan.AviationWx.NET.Parsers
{
    public class ParseTAFXML : IParser<ForecastDto>
    {
        public List<ForecastDto> Parse(string data, IList<string> icaos)
        {
            var serializer = new XmlSerializer(typeof(response));
            response responseObj = null;
            using (var streamReader = new StringReader(data))
            {
                responseObj = serializer.Deserialize(streamReader) as response;
            }

            var dtos = ConvertToDTO(responseObj, icaos);
            var missingDTOs = ParserHelpers.GetMissingStations(dtos, icaos);
            dtos.AddRange(missingDTOs);
            return dtos;
        }
        
        private List<ForecastDto> ConvertToDTO(response xmlObjs,
            IList<string> icaos)
        {
            var dtos = new List<ForecastDto>();
            ForecastDto forecast = null;
            if (xmlObjs.data?.TAF != null)
            {
                foreach (var tafXML in xmlObjs.data.TAF)
                {
                    forecast = dtos.Where(o => o.ICAO == tafXML.station_id).FirstOrDefault();
                    if (forecast == null)
                    {
                        forecast = new ForecastDto();
                        ParseIdentifier(forecast, tafXML);
                        ParseGeographicData(forecast, tafXML);
                        dtos.Add(forecast);
                    }

                    var tafDTO = new TAFDto();
                    ParseTAFData(tafDTO, tafXML);
                    ParseForecastData(tafDTO, tafXML.forecast);
                    forecast.TAF.Add(tafDTO);
                }
            }

            return dtos;
        }

        /// <summary>
        /// Transfers the ICAO
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseIdentifier(ForecastDto dto, TAF xml)
        {
            dto.ICAO = xml.station_id;
        }

        /// <summary>
        /// Transfers the Lat/Lon and Elevations
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseGeographicData(ForecastDto dto, TAF xml)
        {
            dto.GeographicData = new GeographicDataDto()
            {
                Latitude = xml.latitude,
                Longitude = xml.longitude,
                Elevation = xml.elevation_m
            };
        }

        private void ParseTAFData(TAFDto dto, TAF xml)
        {
            dto.RawTAF = xml.raw_text;
            dto.IssuedTime = ParserHelpers.ParseDateTime(xml.issue_time);
            dto.Remarks = xml.remarks;
            dto.ValidTimeEnd = ParserHelpers.ParseDateTime(xml.valid_time_to);
            dto.ValidTimeStart = ParserHelpers.ParseDateTime(xml.valid_time_from);
            dto.BulletinTime = ParserHelpers.ParseDateTime(xml.bulletin_time);

        }

        private void ParseForecastData(TAFDto dto, forecast[] xml)
        {
            var lineNumber = 0;
            foreach (var line in xml)
            {
                var lineDto = new TAFLineDto();
                lineDto.Altimeter = ParserHelpers.GetValue(line.altim_in_hgSpecified, line.altim_in_hg);
                lineDto.ForecastTimeEnd = ParserHelpers.ParseDateTime(line.fcst_time_to);
                lineDto.ForecastTimeStart = ParserHelpers.ParseDateTime(line.fcst_time_from);
                if (line.sky_condition != null)
                {
                    lineDto.SkyCondition.AddRange(line.sky_condition
                        .Select(sc => GetSkyCondition(sc)));
                }

                // First line may not have an change type
                if (lineNumber > 0
                    && !String.IsNullOrWhiteSpace(line.change_indicator))
                {
                    lineDto.ChangeIndicator = ChangeIndicatorType.GetByName(line.change_indicator);
                }
                if (line.icing_condition != null)
                {
                    lineDto.IcingHazards.AddRange(line.icing_condition
                        .Select(ic => GetHazard(ic)));
                }

                if (line.turbulence_condition != null)
                {
                    lineDto.TurbulenceHazards.AddRange(line.turbulence_condition
                        .Select(tb => GetHazard(tb)));
                }

                lineDto.VerticalVisibility = ParserHelpers.GetValue(
                    line.vert_vis_ftSpecified, line.vert_vis_ft);
                lineDto.Visibility = ParserHelpers.GetValue(
                    line.visibility_statute_miSpecified, line.visibility_statute_mi);
                lineDto.Weather = line.wx_string;

                lineDto.Wind = GetWind(line);
                
                lineDto.WindShear = GetWindSheer(line);
                
                dto.TAFLine.Add(lineDto);
                lineNumber++;
            }
        }

        public SkyConditionDto GetSkyCondition(sky_condition xml)
        {
            return new SkyConditionDto()
            {
                CloudBase = xml.cloud_base_ft_agl,
                SkyCondition = SkyConditionType.ByName(xml.sky_cover)
            };
        }

        public WindDto GetWind(forecast xml)
        {
            if ( !xml.wind_dir_degreesSpecified 
                && !xml.wind_speed_ktSpecified)
            {
                return null;
            }

            return new WindDto()
            {
                Gust = ParserHelpers.GetValue(xml.wind_gust_ktSpecified, xml.wind_gust_kt),
                Speed = ParserHelpers.GetValue(xml.wind_speed_ktSpecified, xml.wind_speed_kt),
                Direction = ParserHelpers.GetValue(xml.wind_dir_degreesSpecified, xml.wind_dir_degrees)
            };
        }

        public WindShearDto GetWindSheer(forecast xml)
        {
            if (!xml.wind_shear_hgt_ft_aglSpecified 
                && !xml.wind_shear_dir_degreesSpecified 
                && !xml.wind_shear_speed_ktSpecified)
            {
                return null;
            }

            return new WindShearDto()
            {
                Direction = ParserHelpers.GetValue(xml.wind_shear_dir_degreesSpecified, xml.wind_shear_dir_degrees),
                Height = ParserHelpers.GetValue(xml.wind_shear_hgt_ft_aglSpecified, xml.wind_shear_hgt_ft_agl),
                Speed = ParserHelpers.GetValue(xml.wind_shear_speed_ktSpecified, xml.wind_shear_speed_kt)
            };
        }

        public HazardDto GetHazard(icing_condition xml)
        {
            return new HazardDto()
            {
                Intensity = xml.icing_intensity,
                MaxAltitude = xml.icing_max_alt_ft_agl,
                MinAltitude = xml.icing_min_alt_ft_agl
            };
        }

        public HazardDto GetHazard(turbulence_condition xml)
        {
            return new HazardDto()
            {
                Intensity = xml.turbulence_intensity,
                MaxAltitude = xml.turbulence_max_alt_ft_agl,
                MinAltitude = xml.turbulence_min_alt_ft_agl
            };
        }
    }
}
