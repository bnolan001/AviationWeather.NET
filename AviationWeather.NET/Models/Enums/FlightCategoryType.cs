using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    /// <summary>
    /// REF: https://aviationweather.gov/metar/help?page=plot#fltcat
    /// </summary>
    public class FlightCategoryType
    {
        public static readonly FlightCategoryType VFR = new FlightCategoryType("VFR", 1, "Visual Flight Rules");
        public static readonly FlightCategoryType MVFR = new FlightCategoryType("MVFR", 2, "Marginal Visual Flight Rules");
        public static readonly FlightCategoryType IFR = new FlightCategoryType("IFR", 3, "Instrument Flight Rules");
        public static readonly FlightCategoryType LIFR = new FlightCategoryType("LIFR", 4, "Low Instrument Flight Rules");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        public FlightCategoryType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public List<FlightCategoryType> List()
        {
            return new List<FlightCategoryType> { VFR, MVFR, IFR, LIFR };
        }

        public FlightCategoryType GetByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} must have a value.");
            }

            return List().Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public FlightCategoryType GetByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must have a value greater than 0.");
            }

            return List().Where(s => s.Value == value).FirstOrDefault();
        }
    }
}
