using BNolan.AviationWx.NET.Models.Enums.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class IcingIntensity: IHazardIntensity
    {
        public static readonly IcingIntensity TraceOrNone = new IcingIntensity("Trace or None", 0, "WMO none, USAF light");

        public static readonly IcingIntensity LightIcing = new IcingIntensity("Light icing", TraceOrNone.Value + 1, "Light mixed");

        public static readonly IcingIntensity LightIcingInCloud = new IcingIntensity("Light icing in cloud", LightIcing.Value + 1, "Light rime");

        public static readonly IcingIntensity LightIcingInPrecipitation = new IcingIntensity("Light icing in precipitation", LightIcingInCloud.Value + 1, "Light clear");

        public static readonly IcingIntensity ModerateIcing = new IcingIntensity("Moderate icing", LightIcingInPrecipitation.Value + 1, "Moderate");

        public static readonly IcingIntensity ModerateIcingInCloud = new IcingIntensity("Moderate icing in cloud", ModerateIcing.Value + 1, "Moderate rime");

        public static readonly IcingIntensity ModerateIcingInPrecipitation = new IcingIntensity("Moderate icing in precipitation", ModerateIcingInCloud.Value + 1, "Moderate clear");

        public static readonly IcingIntensity SevereIcing = new IcingIntensity("Severe icing", ModerateIcingInPrecipitation.Value + 1, "Severe mixed");

        public static readonly IcingIntensity SevereIcingInCloud = new IcingIntensity("Severe icing in cloud", SevereIcing.Value + 1, "Severe rime");

        public static readonly IcingIntensity SevereIcingInPrecipitation = new IcingIntensity("Severe icing in precipitation", SevereIcingInCloud.Value + 1, "Severe clear");

        public static readonly IcingIntensity Unknown = new IcingIntensity("Unknown", 99, "Unknown reported intensity");

        public string Name { get; private set; }

        public int Value { get; private set; }

        public string Description { get; private set; }

        private IcingIntensity(string name, int value, string description)
        {
            Name = name;
            Value = value;
            Description = description;
        }

        public static List<IcingIntensity> List()
        {
            return new List<IcingIntensity> { TraceOrNone, LightIcing, LightIcingInCloud, LightIcingInPrecipitation, ModerateIcing, 
                ModerateIcingInCloud, ModerateIcingInPrecipitation, SevereIcing, SevereIcingInCloud, SevereIcingInPrecipitation };
        }

        public static IcingIntensity ByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"'{nameof(name)} 'must have a value.");
            }

            var fields = List();
            var field = fields.Where(m => String.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }

        public static IcingIntensity ByValue(int value)
        {
            var fields = List();
            var field = fields.Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }
    }
}
