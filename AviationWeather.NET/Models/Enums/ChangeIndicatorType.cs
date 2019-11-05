using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class ChangeIndicatorType
    {
        public static readonly ChangeIndicatorType TEMPO = new ChangeIndicatorType("TEMPO", 1, "Temporary");
        public static readonly ChangeIndicatorType BECMG = new ChangeIndicatorType("BECMG", 2, "Becoming");
        public static readonly ChangeIndicatorType FM = new ChangeIndicatorType("FM", 2, "From");
        public static readonly ChangeIndicatorType PROB = new ChangeIndicatorType("PROB", 2, "Probability");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private ChangeIndicatorType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<ChangeIndicatorType> List()
        {
            return new List<ChangeIndicatorType> { TEMPO, BECMG, FM, PROB };
        }

        public static ChangeIndicatorType GetByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} must have a value.");
            }

            return List().Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public static ChangeIndicatorType GetByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must have a value greater than 0.");
            }

            return List().Where(s => s.Value == value).FirstOrDefault();
        }
    }
}
