using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    public class ForecastType
    {
        public static readonly ForecastType TEMPO = new ForecastType("TEMPO", 1, "Temporary");
        public static readonly ForecastType BECMG = new ForecastType("BECMG", 2, "Becoming");
        public static readonly ForecastType FM = new ForecastType("FM", 2, "From");
        public static readonly ForecastType PROB = new ForecastType("PROB", 2, "Probability");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private ForecastType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<ForecastType> List()
        {
            return new List<ForecastType> { TEMPO, BECMG, FM, PROB };
        }

        public static ForecastType GetByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} must have a value.");
            }

            return List().Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public static ForecastType GetByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must have a value greater than 0.");
            }

            return List().Where(s => s.Value == value).FirstOrDefault();
        }
    }
}
