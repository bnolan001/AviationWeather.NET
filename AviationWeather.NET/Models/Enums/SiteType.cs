using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class SiteType
    {
        public static SiteType METAR = new SiteType("METAR", 1);

        public static SiteType Rawinsonde = new SiteType("rawinsonde", METAR.Value + 1);

        public static SiteType TAF = new SiteType("TAF", Rawinsonde.Value + 1);

        public static SiteType NEXRAD = new SiteType("NEXRAD", TAF.Value + 1);

        public static SiteType WindProfiler = new SiteType("wind_profiler", NEXRAD.Value + 1);

        public static SiteType WFOOffice = new SiteType("WFO_Office", WindProfiler.Value + 1);

        public static SiteType SYNOPS = new SiteType("SYNOPS", WFOOffice.Value + 1);

        public static SiteType Unknown { get; } = new SiteType("UNKNOWN", 100);

        public string Name { get; private set; }

        public int Value { get; private set; }

        private SiteType(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static List<SiteType> List()
        {
            return new List<SiteType>() { METAR, Rawinsonde, TAF, NEXRAD, WindProfiler, WFOOffice, SYNOPS };
        }

        public static SiteType ByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"'{nameof(value)} 'must have a value greater than -1.");
            }

            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }

        public static SiteType ByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"'{nameof(name)} 'must have a value.");
            }

            var field = List().Where(m => String.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }
    }
}
