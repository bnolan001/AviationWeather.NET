using BNolan.AviationWx.NET.Models.Enums.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class TurbulenceIntensity : IHazardIntensity
    {
        public static readonly TurbulenceIntensity None = new TurbulenceIntensity("None", 0);

        public static readonly TurbulenceIntensity Light = new TurbulenceIntensity("Light turbulence", None.Value + 1);

        public static readonly TurbulenceIntensity LightOccasionalModerate = new TurbulenceIntensity("Light occasional moderate turbulence in clear air", Light.Value + 1);

        public static readonly TurbulenceIntensity ModerateInClearAir = new TurbulenceIntensity("Moderate turbulence in clear air", LightOccasionalModerate.Value + 1);

        public static readonly TurbulenceIntensity LightOccasionalModerateInCloud = new TurbulenceIntensity("Light occasional moderate in cloud", ModerateInClearAir.Value + 1);

        public static readonly TurbulenceIntensity ModerateInCloud = new TurbulenceIntensity("Moderate turbulence in cloud", LightOccasionalModerateInCloud.Value + 1);

        public static readonly TurbulenceIntensity LightOccasionalSevereInClearAir = new TurbulenceIntensity("Light occasional severe turbulence in clear air", ModerateInCloud.Value + 1);

        public static readonly TurbulenceIntensity SevereInClearAir = new TurbulenceIntensity("Severe turbulence in clear air", LightOccasionalSevereInClearAir.Value + 1);

        public static readonly TurbulenceIntensity LightOccasionalSevereInCloud = new TurbulenceIntensity("Light occasional severe turbulence in cloud", SevereInClearAir.Value + 1);

        public static readonly TurbulenceIntensity SevereInCloud = new TurbulenceIntensity("Severe turbulence in cloud", LightOccasionalSevereInCloud.Value + 1);

        public static readonly TurbulenceIntensity Unknown = new TurbulenceIntensity("Unknown", 99);

        public string Name { get; private set; }

        public int Value { get; private set; }

        private TurbulenceIntensity(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static List<TurbulenceIntensity> List()
        {
            return new List<TurbulenceIntensity> { None, Light, LightOccasionalModerate, ModerateInClearAir, LightOccasionalModerateInCloud,
                ModerateInCloud, LightOccasionalSevereInCloud, SevereInClearAir, LightOccasionalSevereInCloud, SevereInCloud };
        }

        public static TurbulenceIntensity ByName(string name)
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

        public static TurbulenceIntensity ByValue(int value)
        {
            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }
    }
}
