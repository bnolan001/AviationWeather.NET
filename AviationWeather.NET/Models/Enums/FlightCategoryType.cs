using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    /// <summary>
    /// REF: https://aviationweather.gov/metar/help?page=plot#fltcat
    /// </summary>
    public class FlightCategoryType
    {
        public static readonly FlightCategoryType VFR = new FlightCategoryType("VFR", 1, "Visual Flight Rules");

        public static readonly FlightCategoryType MVFR = new FlightCategoryType("MVFR", VFR.Value + 1, "Marginal Visual Flight Rules");

        public static readonly FlightCategoryType IFR = new FlightCategoryType("IFR", MVFR.Value + 1, "Instrument Flight Rules");

        public static readonly FlightCategoryType LIFR = new FlightCategoryType("LIFR", IFR.Value + 1, "Low Instrument Flight Rules");

        public static readonly FlightCategoryType Unknown = new FlightCategoryType("Unknown", LIFR.Value + 1, "Unknown");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private FlightCategoryType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<FlightCategoryType> List()
        {
            return new List<FlightCategoryType> { VFR, MVFR, IFR, LIFR };
        }

        public static FlightCategoryType ByName(string name)
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

        public static FlightCategoryType ByValue(int value)
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
