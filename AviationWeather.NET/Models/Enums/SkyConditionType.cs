using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class SkyConditionType
    {
        public static SkyConditionType SKC = new SkyConditionType("SKC", 0, "Sky Clear");

        public static SkyConditionType CLR = new SkyConditionType("CLR", SKC.Value + 1, "Clear");

        public static SkyConditionType FEW = new SkyConditionType("FEW", CLR.Value + 1, "Few");

        public static SkyConditionType SCT = new SkyConditionType("SCT", FEW.Value + 1, "Scattered");

        public static SkyConditionType BKN = new SkyConditionType("BKN", SCT.Value + 1, "Broken");

        public static SkyConditionType OVC = new SkyConditionType("OVC", BKN.Value + 1, "Overcast");

        public static SkyConditionType CAVOK = new SkyConditionType("CAVOK", OVC.Value + 1, "Ceiling and Visibility OK");

        public static SkyConditionType Unknown { get; } = new SkyConditionType("UNKNOWN", CAVOK.Value + 1, "Unknown");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private SkyConditionType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<SkyConditionType> List()
        {
            return new List<SkyConditionType> { SKC, FEW, SCT, BKN, OVC, CLR, CAVOK, Unknown };
        }

        public static SkyConditionType ByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"'{nameof(name)} 'must have a value.");
            }

            var field = List().Where(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }

        public static SkyConditionType ByValue(int value)
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
    }
}
