using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    public class SkyConditionType
    {
        public static SkyConditionType SKC = new SkyConditionType("SKC", 0, "Sky Clear");
        public static SkyConditionType FEW = new SkyConditionType("FEW", 1, "Few");
        public static SkyConditionType SCT = new SkyConditionType("SCT", 2, "Scattered");
        public static SkyConditionType BKN = new SkyConditionType("BKN", 3, "Broken");
        public static SkyConditionType OVC = new SkyConditionType("OVC", 4, "Overcast");
        public static SkyConditionType CAVOK = new SkyConditionType("CAVOK", 5, "CAVOK");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private SkyConditionType(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public List<SkyConditionType> GetAll()
        {
            return new List<SkyConditionType> { SKC, FEW, SCT, BKN, OVC };
        }

        public SkyConditionType GetByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} must have a value.");
            }

            return GetAll().Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public SkyConditionType GetByValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(value)} must have a value greater than -1.");
            }

            return GetAll().Where(s => s.Value == value).FirstOrDefault();
        }
    }
}
