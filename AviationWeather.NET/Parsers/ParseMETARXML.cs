using AviationWx.NET.Models.DTOs;
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

        private List<ObservationDto> ConvertToDTO(response xmlObjs,
            IList<string> icaos)
        {
            var hashSet = new HashSet<string>();
            icaos.All(a => hashSet.Add(a.ToUpper()));

            var dtos = new List<ObservationDto>();
            ObservationDto obs = null;
            if (xmlObjs.data?.METAR != null)
            {
                foreach (var metar in xmlObjs.data.METAR)
                {
                    obs = dtos.Where(o => o.ICAO == metar.station_id).FirstOrDefault();
                    if (obs == null)
                    {
                        hashSet.Remove(metar.station_id.ToUpper());
                        obs = new ObservationDto();
                        dtos.Add(obs);
                    }
                    var metardto = new METARDto();
                    ParseGeographicData(ref metardto, metar);
                    ParseCurrentWeatherData(ref metardto, metar);
                    obs.METAR.Add(metardto);
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

        private void ParseIdentifier(ref ObservationDto dto, METAR metar)
        {
            dto.ICAO = metar.station_id;
        }

        private void ParseGeographicData(ref METARDto dto, METAR metar)
        {
            dto.GeographicData = new GeographicData()
            {
                Latitude = metar.latitude,
                Longitude = metar.longitude,
                Elevation_M = metar.elevation_m
            };
        }

        private void ParseCurrentWeatherData(ref METARDto dto, METAR metar)
        {
            dto.Altimeter_Hg = metar.altim_in_hg;
            dto.Dewpoint_C = metar.dewpoint_c;
            dto.ObsTime = DateTime.Parse(metar.observation_time);
            dto.Precipitation_In = metar.precip_in;
            dto.RawMETAR = metar.raw_text;
            dto.SeaLevelPressure_Mb = metar.sea_level_pressure_mb;
            dto.SkyCondition = metar.sky_condition.Select(sc => new SkyConditionDto() { SkyCondition = SkyConditionType.GetByName(sc.sky_cover), CloudBaseFt = sc.cloud_base_ft_agl }).ToList();
            dto.Temperature_C = metar.temp_c;
            dto.VerticalVisibility_Ft = metar.vert_vis_ft;
            dto.Visibility_SM = metar.visibility_statute_mi;
            dto.Weather = metar.wx_string;
            dto.WindDirection_D = metar.wind_dir_degrees;
            dto.WindGust_Kt = metar.wind_gust_kt;
            dto.WindSpeed_Kt = metar.wind_speed_kt;
        }
    }
}
