using System;
using System.Collections.Generic;

namespace AviationWx.NET.Models.DTOs
{
    public class TAFDto
    {
        public string RawTAF { get; set; }

        public DateTimeOffset IssuedTime { get; set; }

        public DateTimeOffset BulletinTime { get; set; }

        public DateTimeOffset ValidTimeStart { get; set; }

        public DateTimeOffset ValidTimeEnd { get; set; }

        public string Remarks { get; set; }

        public List<TAFLineDto> TAFLine { get; set; }

        public TAFDto()
        {
            TAFLine = new List<TAFLineDto>();
        }
    }
}
