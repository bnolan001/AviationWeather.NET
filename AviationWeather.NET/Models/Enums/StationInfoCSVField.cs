using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class StationInfoCSVField
    {
        public static StationInfoCSVField station_id = new StationInfoCSVField("station_id", 1);

        public static StationInfoCSVField wmo_id = new StationInfoCSVField("wmo_id", station_id.Value + 1);

        public static StationInfoCSVField latitude = new StationInfoCSVField("latitude", wmo_id.Value + 1);

        public static StationInfoCSVField longitude = new StationInfoCSVField("longitude", latitude.Value + 1);

        public static StationInfoCSVField elevation_m = new StationInfoCSVField("elevation_m", longitude.Value + 1);

        public static StationInfoCSVField site = new StationInfoCSVField("site", elevation_m.Value + 1);

        public static StationInfoCSVField state = new StationInfoCSVField("state", site.Value + 1);

        public static StationInfoCSVField country = new StationInfoCSVField("country", state.Value + 1);

        public static StationInfoCSVField site_type = new StationInfoCSVField("site_type", country.Value + 1);

        public static StationInfoCSVField Unknown = new StationInfoCSVField("unknown", site_type.Value + 1);

        public string Name { get; set; }

        public int Value { get; set; }

        public StationInfoCSVField(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static List<StationInfoCSVField> List()
        {
            return new List<StationInfoCSVField>() { station_id, wmo_id, latitude, longitude, elevation_m, site, state, country, site_type };
        }

        public static StationInfoCSVField ByValue(int value)
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

        public static StationInfoCSVField ByName(string name)
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
    }
}
