using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class ChangeIndicatorType
    {
        public static readonly ChangeIndicatorType TEMPO = new ChangeIndicatorType("TEMPO", 1, "Temporary");

        public static readonly ChangeIndicatorType BECMG = new ChangeIndicatorType("BECMG", TEMPO.Value + 1, "Becoming");

        public static readonly ChangeIndicatorType FM = new ChangeIndicatorType("FM", BECMG.Value + 1, "From");

        public static readonly ChangeIndicatorType PROB = new ChangeIndicatorType("PROB", FM.Value + 1, "Probability");

        public static readonly ChangeIndicatorType Unknown = new ChangeIndicatorType("Unknown", PROB.Value + 1, "Unknown");

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
                throw new ArgumentNullException($"'{nameof(name)} 'must have a value.");
            }

            var field = List().Where(m => String.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }

        public static ChangeIndicatorType GetByValue(int value)
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
