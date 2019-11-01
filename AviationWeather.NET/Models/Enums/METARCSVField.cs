using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    public class METARCSVField
    {
        public static METARCSVField raw_text { get; } = new METARCSVField("raw_text", 1);
        public static METARCSVField station_id { get; } = new METARCSVField("station_id", 2);
        public static METARCSVField observation_time { get; } = new METARCSVField("observation_time", 3);
        public static METARCSVField latitude { get; } = new METARCSVField("latitude", 4);
        public static METARCSVField longitude { get; } = new METARCSVField("longitude", 5);
        public static METARCSVField temp_c { get; } = new METARCSVField("temp_c", 6);
        public static METARCSVField dewpoint_c { get; } = new METARCSVField("dewpoint_c", 7);
        public static METARCSVField wind_dir_degrees { get; } = new METARCSVField("wind_dir_degrees", 8);
        public static METARCSVField wind_speed_kt { get; } = new METARCSVField("wind_speed_kt", 9);
        public static METARCSVField wind_gust_kt { get; } = new METARCSVField("wind_gust_kt", 10);
        public static METARCSVField visibility_statute_mi { get; } = new METARCSVField("visibility_statute_mi", 11);
        public static METARCSVField altim_in_hg { get; } = new METARCSVField("altim_in_hg", 12);
        public static METARCSVField sea_level_pressure_mb { get; } = new METARCSVField("sea_level_pressure_mb", 13);
        public static METARCSVField corrected { get; } = new METARCSVField("corrected", 14);
        public static METARCSVField auto { get; } = new METARCSVField("auto", 15);
        public static METARCSVField auto_station { get; } = new METARCSVField("auto_station", 16);
        public static METARCSVField maintenance_indicator_on { get; } = new METARCSVField("maintenance_indicator_on", 17);
        public static METARCSVField no_signal { get; } = new METARCSVField("no_signal", 18);
        public static METARCSVField lightning_sensor_off { get; } = new METARCSVField("lightning_sensor_off", 19);
        public static METARCSVField freezing_rain_sensor_off { get; } = new METARCSVField("freezing_rain_sensor_off", 20);
        public static METARCSVField present_weather_sensor_off { get; } = new METARCSVField("present_weather_sensor_off", 21);
        public static METARCSVField wx_string { get; } = new METARCSVField("wx_string", 22);
        public static METARCSVField sky_cover { get; } = new METARCSVField("sky_cover", 23); // Multiple instances in the output
        public static METARCSVField cloud_base_ft_agl { get; } = new METARCSVField("cloud_base_ft_agl", 24); // Multiple instances in the output
        public static METARCSVField flight_category { get; } = new METARCSVField("flight_category", 25);
        public static METARCSVField three_hr_pressure_tendency_mb { get; } = new METARCSVField("three_hr_pressure_tendency_mb", 26);
        public static METARCSVField maxT_c { get; } = new METARCSVField("maxT_c", 27);
        public static METARCSVField minT_c { get; } = new METARCSVField("minT_c", 28);
        public static METARCSVField maxT24hr_c { get; } = new METARCSVField("maxT24hr_c", 29);
        public static METARCSVField minT24hr_c { get; } = new METARCSVField("minT24hr_c", 30);
        public static METARCSVField precip_in { get; } = new METARCSVField("precip_in", 31);
        public static METARCSVField pcp3hr_in { get; } = new METARCSVField("pcp3hr_in", 32);
        public static METARCSVField pcp6hr_in { get; } = new METARCSVField("pcp6hr_in", 33);
        public static METARCSVField pcp24hr_in { get; } = new METARCSVField("pcp24hr_in", 34);
        public static METARCSVField snow_in { get; } = new METARCSVField("snow_in", 35);
        public static METARCSVField vert_vis_ft { get; } = new METARCSVField("vert_vis_ft", 36);
        public static METARCSVField metar_type { get; } = new METARCSVField("metar_type", 37);
        public static METARCSVField elevation_m { get; } = new METARCSVField("elevation_m", 38);

        public static METARCSVField unknown { get; } = new METARCSVField("UNKNOWN", 100);

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
            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = unknown;
            }

            return field;
        }

        public static METARCSVField ByName(string name)
        {
            var field = List().Where(m => String.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = unknown;
            }

            return field;
        }
    }
}
