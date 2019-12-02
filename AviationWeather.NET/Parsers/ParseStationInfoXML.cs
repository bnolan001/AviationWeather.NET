using BNolan.AviationWx.NET.Models.DTOs;
using BNolan.AviationWx.NET.Models.Enums;
using BNolan.AviationWx.NET.Models.XML.Station;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BNolan.AviationWx.NET.Parsers
{
    public class ParseStationInfoXML : IParser<StationInfoDto>
    {
        private CultureInfo _cultureInfo = CultureInfo.GetCultureInfo(ParserConstants.StringCulture);

        #region Public

        public List<StationInfoDto> Parse(string data, IList<string> icaos)
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
        private List<StationInfoDto> ConvertToDTO(response xmlObjs,
            IList<string> icaos)
        {
            var dtos = new List<StationInfoDto>();
            StationInfoDto station = null;
            if (xmlObjs.data?.Station != null)
            {
                foreach (var stationXML in xmlObjs.data.Station)
                {
                    station = dtos.Where(o => o.ICAO == stationXML.station_id).FirstOrDefault();
                    if (station == null)
                    {
                        station = new StationInfoDto();
                        ParseIdentifier(station, stationXML);
                        ParseGeographicData(station, stationXML);
                        ParseSiteName(station, stationXML);
                        ParseWMOIdentifier(station, stationXML);
                        ParseSiteType(station, stationXML);
                        dtos.Add(station);
                    }
                }
            }

            return dtos;
        }

        /// <summary>
        /// Transfers the ICAO
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseIdentifier(StationInfoDto dto, responseDataStation xml)
        {
            dto.ICAO = xml.station_id;
        }

        /// <summary>
        /// Transfers the WMO Identifier
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseSiteName(StationInfoDto dto, responseDataStation xml)
        {
            dto.Name = xml.site;
        }

        /// <summary>
        /// Transfers the ICAO
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseWMOIdentifier(StationInfoDto dto, responseDataStation xml)
        {
            dto.WMOID = xml.wmo_id;
        }

        /// <summary>
        /// Transfers the ICAO
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseSiteType(StationInfoDto dto, responseDataStation xml)
        {
            if (xml.site_type == null)
            {
                return;
            }

            if (xml.site_type.METAR != null)
            {
                dto.SiteType.Add(SiteType.METAR);
            }

            if (xml.site_type.NEXRAD != null)
            {
                dto.SiteType.Add(SiteType.NEXRAD);
            }

            if (xml.site_type.rawinsonde != null)
            {
                dto.SiteType.Add(SiteType.Rawinsonde);
            }

            if (xml.site_type.SYNOPS != null)
            {
                dto.SiteType.Add(SiteType.SYNOPS);
            }

            if (xml.site_type.TAF != null)
            {
                dto.SiteType.Add(SiteType.TAF);
            }

            if (xml.site_type.WFO_office != null)
            {
                dto.SiteType.Add(SiteType.WFOOffice);
            }

            if (xml.site_type.wind_profiler != null)
            {
                dto.SiteType.Add(SiteType.WindProfiler);
            }
        }

        /// <summary>
        /// Transfers the Lat/Lon and Elevations
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="xml"></param>
        private void ParseGeographicData(StationInfoDto dto, responseDataStation xml)
        {
            dto.GeographicData = new GeographicDataDto()
            {
                Latitude = xml.latitude,
                Longitude = xml.longitude,
                Elevation = xml.elevation_m
            };
            dto.State = xml.state;
            dto.Country = xml.country;
        }

        #endregion Private

    }
}
