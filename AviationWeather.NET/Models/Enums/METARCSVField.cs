using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class METARCSVField
    {
        public static METARCSVField raw_text { get; } = new METARCSVField("raw_text", 1);
        public static METARCSVField station_id { get; } = new METARCSVField("station_id", raw_text.Value + 1);
        public static METARCSVField observation_time { get; } = new METARCSVField("observation_time", station_id.Value + 1);
        public static METARCSVField latitude { get; } = new METARCSVField("latitude", observation_time.Value + 1);
        public static METARCSVField longitude { get; } = new METARCSVField("longitude", latitude.Value + 1);
        public static METARCSVField temp_c { get; } = new METARCSVField("temp_c", longitude.Value + 1);
        public static METARCSVField dewpoint_c { get; } = new METARCSVField("dewpoint_c", temp_c.Value + 1);
        public static METARCSVField wind_dir_degrees { get; } = new METARCSVField("wind_dir_degrees", dewpoint_c.Value + 1);
        public static METARCSVField wind_speed_kt { get; } = new METARCSVField("wind_speed_kt", wind_dir_degrees.Value + 1);
        public static METARCSVField wind_gust_kt { get; } = new METARCSVField("wind_gust_kt", wind_speed_kt.Value + 1);
        public static METARCSVField visibility_statute_mi { get; } = new METARCSVField("visibility_statute_mi", wind_gust_kt.Value + 1);
        public static METARCSVField altim_in_hg { get; } = new METARCSVField("altim_in_hg", visibility_statute_mi.Value + 1);
        public static METARCSVField sea_level_pressure_mb { get; } = new METARCSVField("sea_level_pressure_mb", altim_in_hg.Value + 1);
        public static METARCSVField corrected { get; } = new METARCSVField("corrected", sea_level_pressure_mb.Value + 1);
        public static METARCSVField auto { get; } = new METARCSVField("auto", corrected.Value + 1);
        public static METARCSVField auto_station { get; } = new METARCSVField("auto_station", auto.Value + 1);
        public static METARCSVField maintenance_indicator_on { get; } = new METARCSVField("maintenance_indicator_on", auto_station.Value + 1);
        public static METARCSVField no_signal { get; } = new METARCSVField("no_signal", maintenance_indicator_on.Value + 1);
        public static METARCSVField lightning_sensor_off { get; } = new METARCSVField("lightning_sensor_off", no_signal.Value + 1);
        public static METARCSVField freezing_rain_sensor_off { get; } = new METARCSVField("freezing_rain_sensor_off", lightning_sensor_off.Value + 1);
        public static METARCSVField present_weather_sensor_off { get; } = new METARCSVField("present_weather_sensor_off", freezing_rain_sensor_off.Value + 1);
        public static METARCSVField wx_string { get; } = new METARCSVField("wx_string", present_weather_sensor_off.Value + 1);
        public static METARCSVField sky_cover { get; } = new METARCSVField("sky_cover", wx_string.Value + 1); // Multiple instances in the output
        public static METARCSVField cloud_base_ft_agl { get; } = new METARCSVField("cloud_base_ft_agl", sky_cover.Value + 1); // Multiple instances in the output
        public static METARCSVField flight_category { get; } = new METARCSVField("flight_category", cloud_base_ft_agl.Value + 1);
        public static METARCSVField three_hr_pressure_tendency_mb { get; } = new METARCSVField("three_hr_pressure_tendency_mb", flight_category.Value + 1);
        public static METARCSVField maxT_c { get; } = new METARCSVField("maxT_c", three_hr_pressure_tendency_mb.Value + 1);
        public static METARCSVField minT_c { get; } = new METARCSVField("minT_c", maxT_c.Value + 1);
        public static METARCSVField maxT24hr_c { get; } = new METARCSVField("maxT24hr_c", minT_c.Value + 1);
        public static METARCSVField minT24hr_c { get; } = new METARCSVField("minT24hr_c", maxT24hr_c.Value + 1);
        public static METARCSVField precip_in { get; } = new METARCSVField("precip_in", minT24hr_c.Value + 1);
        public static METARCSVField pcp3hr_in { get; } = new METARCSVField("pcp3hr_in", precip_in.Value + 1);
        public static METARCSVField pcp6hr_in { get; } = new METARCSVField("pcp6hr_in", pcp3hr_in.Value + 1);
        public static METARCSVField pcp24hr_in { get; } = new METARCSVField("pcp24hr_in", pcp6hr_in.Value + 1);
        public static METARCSVField snow_in { get; } = new METARCSVField("snow_in", pcp24hr_in.Value + 1);
        public static METARCSVField vert_vis_ft { get; } = new METARCSVField("vert_vis_ft", snow_in.Value + 1);
        public static METARCSVField metar_type { get; } = new METARCSVField("metar_type", vert_vis_ft.Value + 1);
        public static METARCSVField elevation_m { get; } = new METARCSVField("elevation_m", metar_type.Value + 1);

        public static METARCSVField Unknown { get; } = new METARCSVField("UNKNOWN", elevation_m.Value + 1);

        public string Name { get; private set; }

        public int Value { get; private set; }

        private METARCSVField(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static List<METARCSVField> List()
        {
            return new List<METARCSVField>() { raw_text, station_id, observation_time, latitude, 
                longitude, temp_c, dewpoint_c, wind_dir_degrees, wind_speed_kt, wind_gust_kt, 
                visibility_statute_mi, altim_in_hg, sea_level_pressure_mb, corrected, auto, 
                auto_station, maintenance_indicator_on, no_signal, lightning_sensor_off, 
                freezing_rain_sensor_off, present_weather_sensor_off, wx_string, sky_cover, 
                cloud_base_ft_agl, flight_category, three_hr_pressure_tendency_mb, maxT_c, minT_c, 
                maxT24hr_c, minT24hr_c, precip_in, pcp3hr_in, pcp6hr_in, pcp24hr_in, snow_in, 
                vert_vis_ft, metar_type, elevation_m };
        }

        public static METARCSVField ByValue(int value)
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

        public static METARCSVField ByName(string name)
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
