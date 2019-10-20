using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    public class METARType
    {
        public static readonly METARType METAR = new METARType("METAR", 1, "METAR");
        public static readonly METARType SPECI = new METARType("SPECI", 2, "Special");

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

        public static METARType GetByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} must have a value.");
            }

            return List().Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public static METARType GetByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must have a value greater than 0.");
            }

            return List().Where(s => s.Value == value).FirstOrDefault();
        }
    }
}
