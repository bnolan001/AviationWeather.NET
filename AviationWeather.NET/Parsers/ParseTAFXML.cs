using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.XML.AWTAF;
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
                foreach (var taf in xmlObjs.data.TAF)
                {
                    forecast = dtos.Where(o => o.ICAO == taf.station_id).FirstOrDefault();
                    if (forecast == null)
                    {
                        hashSet.Remove(taf.station_id.ToUpper());
                        forecast = new ForecastDto()
                        {
                            ICAO = taf.station_id
                        };
                        dtos.Add(forecast);
                    }

                    forecast.TAF.Add(new TAFDto()
                    {
                        RawTAF = taf.raw_text
                    });
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
    }
}
