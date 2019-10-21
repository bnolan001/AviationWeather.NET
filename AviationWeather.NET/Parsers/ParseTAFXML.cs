using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.Enums;
using AviationWx.NET.Models.XML.AWTAF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AviationWx.NET.Parsers
{
    public class ParseTAFXML : IParser<ForecastDto>
    {
        public List<ForecastDto> Parse(string data, IList<string> icaos)
        {
            var serializer = new XmlSerializer(typeof(response));
            response responseObj = null;
            using (var streamReader = new StringReader(data))
            {
                responseObj = (response)serializer.Deserialize(streamReader);
            }

            return ConvertToDTO(responseObj, icaos);
        }

        private List<ForecastDto> ConvertToDTO(response xmlObjs,
            IList<string> icaos)
        {
            var hashSet = new HashSet<string>();
            icaos.All(a => hashSet.Add(a.ToUpper()));

            var dtos = new List<ForecastDto>();
            ForecastDto forecast = null;
            if (xmlObjs.data?.TAF != null)
            {
                foreach (var tafXML in xmlObjs.data.TAF)
                {
                    forecast = dtos.Where(o => o.ICAO == tafXML.station_id).FirstOrDefault();
                    if (forecast == null)
                    {
                        hashSet.Remove(tafXML.station_id.ToUpper());
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
            foreach (var icao in hashSet)
            {
                dtos.Add(new ForecastDto()
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
                Elevation_M = xml.elevation_m
            };
        }

        private void ParseTAFData(TAFDto dto, TAF xml)
        {
            dto.RawTAF = xml.raw_text;
            dto.IssuedTime = DateTime.Parse(xml.issue_time);
            dto.Remarks = xml.remarks;
            dto.ValidTimeEnd = DateTime.Parse(xml.valid_time_to);
            dto.ValidTimeStart = DateTime.Parse(xml.valid_time_from);
            dto.BulletinTime = DateTime.Parse(xml.bulletin_time);

        }

        private void ParseForecastData(TAFDto dto, forecast[] xml)
        {
            foreach (var line in xml)
            {
                var lineDto = new TAFLineDto();
                lineDto.Altimeter_Hg = ParserHelpers.GetValue(line.altim_in_hgSpecified, line.altim_in_hg);
                lineDto.ForecastTimeEnd = DateTime.Parse(line.fcst_time_to);
                lineDto.ForecastTimeStart = DateTime.Parse(line.fcst_time_from);
                lineDto.ForecastType = ForecastType.GetByName(line.change_indicator);
                lineDto.IcingHazards = line.icing_condition.Select(ic => new IcingDto() { Intensity = ic.icing_intensity, MaxAltitude_Ft = ic.icing_max_alt_ft_agl, MinAltitude_Ft = ic.icing_min_alt_ft_agl }).ToList();
                lineDto.TurbulenceHazards = line.turbulence_condition.Select(ic => new TurbulenceDto() { Intensity = ic.turbulence_intensity, MaxAltitude_Ft = ic.turbulence_max_alt_ft_agl, MinAltitude_Ft = ic.turbulence_min_alt_ft_agl }).ToList();
                lineDto.VerticalVisibility_Ft = ParserHelpers.GetValue(line.vert_vis_ftSpecified, line.vert_vis_ft);
                lineDto.Visibility_SM = ParserHelpers.GetValue(line.visibility_statute_miSpecified, line.visibility_statute_mi);
                lineDto.Weather = line.wx_string;
                if (line.wind_gust_ktSpecified || line.wind_dir_degreesSpecified || line.wind_speed_ktSpecified)
                {
                    lineDto.Wind = new WindDto()
                    {
                        WindGust_Kt = ParserHelpers.GetValue(line.wind_gust_ktSpecified, line.wind_gust_kt),
                        WindSpeed_Kt = ParserHelpers.GetValue(line.wind_speed_ktSpecified, line.wind_speed_kt),
                        WindDirection_D = ParserHelpers.GetValue(line.wind_dir_degreesSpecified, line.wind_dir_degrees)
                    };
                }

                if (line.wind_shear_hgt_ft_aglSpecified || line.wind_shear_dir_degreesSpecified || line.wind_shear_speed_ktSpecified)
                {
                    lineDto.WindShear = new WindShearDto()
                    {
                        WindShearDirection_D = ParserHelpers.GetValue(line.wind_shear_dir_degreesSpecified, line.wind_shear_dir_degrees),
                        WindShearHeight_Ft = ParserHelpers.GetValue(line.wind_shear_hgt_ft_aglSpecified, line.wind_shear_hgt_ft_agl),
                        WindShearSpeed_Kt = ParserHelpers.GetValue(line.wind_shear_speed_ktSpecified, line.wind_shear_speed_kt)
                    };
                }

                dto.Forecast.Add(lineDto);
            }
        }
    }
}
