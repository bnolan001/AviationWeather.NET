using AviationWx.NET.Models.DTOs;
using AviationWx.NET.Models.XML.AWMETAR;
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
                        obs = new ObservationDto()
                        {
                            ICAO = metar.station_id
                        };
                        dtos.Add(obs);
                    }

                    obs.METAR.Add(new METARDto()
                    {
                        RawMETAR = metar.raw_text
                    });
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
    }
}
