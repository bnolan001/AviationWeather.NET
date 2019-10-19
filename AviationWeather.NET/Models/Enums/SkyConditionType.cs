using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    public class SkyConditionType
    {
        public static SkyConditionType SKC = new SkyConditionType("SKC", 0, "Sky Clear");
        public static SkyConditionType CLR = new SkyConditionType("CLR", 1, "Clear");
        public static SkyConditionType FEW = new SkyConditionType("FEW", 2, "Few");
        public static SkyConditionType SCT = new SkyConditionType("SCT", 3, "Scattered");
        public static SkyConditionType BKN = new SkyConditionType("BKN", 4, "Broken");
        public static SkyConditionType OVC = new SkyConditionType("OVC", 5, "Overcast");
        public static SkyConditionType CAVOK = new SkyConditionType("CAVOK", 6, "Ceiling and Visibility OK");

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
            return new List<SkyConditionType> { SKC, FEW, SCT, BKN, OVC };
        }

        public static SkyConditionType GetByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} must have a value.");
            }

            return List().Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public static SkyConditionType GetByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must have a value greater than -1.");
            }

            return List().Where(s => s.Value == value).FirstOrDefault();
        }
    }
}
