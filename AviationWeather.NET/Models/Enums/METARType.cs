using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class METARType
    {
        public static readonly METARType METAR = new METARType("METAR", 1, "METAR");

        public static readonly METARType SPECI = new METARType("SPECI", METAR.Value + 1, "Special");

        public static readonly METARType Unknown = new METARType("Unknown", SPECI.Value + 1, "Unknnown");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private METARType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<METARType> List()
        {
            return new List<METARType> { METAR, SPECI };
        }

        public static METARType ByName(string name)
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

        public static METARType ByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"'{nameof(value)} 'must have a value greater than 0.");
            }

            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }
    }
}
