using System;
using System.Collections.Generic;
using System.Linq;

namespace AviationWx.NET.Models.Enums
{
    public class TAFCSVField
    {
        public static TAFCSVField raw_text = new TAFCSVField("raw_text", 1);
        public static TAFCSVField station_id = new TAFCSVField("station_id", 2);
        public static TAFCSVField issue_time = new TAFCSVField("issue_time", 3);
        public static TAFCSVField bulletin_time = new TAFCSVField("bulletin_time", 4);
        public static TAFCSVField valid_time_from = new TAFCSVField("valid_time_from", 5);
        public static TAFCSVField valid_time_to = new TAFCSVField("valid_time_to", 6);
        public static TAFCSVField remarks = new TAFCSVField("remarks", 7);
        public static TAFCSVField latitude = new TAFCSVField("latitude", 8);
        public static TAFCSVField longitude = new TAFCSVField("longitude", 9);
        public static TAFCSVField elevation_m = new TAFCSVField("elevation_m", 10);
        public static TAFCSVField fcst_time_from = new TAFCSVField("fcst_time_from", 11);
        public static TAFCSVField fcst_time_to = new TAFCSVField("fcst_time_to", 12);
        public static TAFCSVField change_indicator = new TAFCSVField("change_indicator", 13);
        public static TAFCSVField time_becoming = new TAFCSVField("time_becoming", 14);
        public static TAFCSVField probability = new TAFCSVField("probability", 15);
        public static TAFCSVField wind_dir_degrees = new TAFCSVField("wind_dir_degrees", 16);
        public static TAFCSVField wind_speed_kt = new TAFCSVField("wind_speed_kt", 17);
        public static TAFCSVField wind_gust_kt = new TAFCSVField("wind_gust_kt", 18);
        public static TAFCSVField wind_shear_hgt_ft_agl = new TAFCSVField("wind_shear_hgt_ft_agl", 19);
        public static TAFCSVField wind_shear_dir_degrees = new TAFCSVField("wind_shear_dir_degrees", 20);
        public static TAFCSVField wind_shear_speed_kt = new TAFCSVField("wind_shear_speed_kt", 21);
        public static TAFCSVField visibility_statute_mi = new TAFCSVField("visibility_statute_mi", 22);
        public static TAFCSVField altim_in_hg = new TAFCSVField("altim_in_hg", 23);
        public static TAFCSVField vert_vis_ft = new TAFCSVField("vert_vis_ft", 24);
        public static TAFCSVField wx_string = new TAFCSVField("wx_string", 25);
        public static TAFCSVField not_decoded = new TAFCSVField("not_decoded", 26);
        public static TAFCSVField sky_cover = new TAFCSVField("sky_cover", 27);
        public static TAFCSVField cloud_base_ft_agl = new TAFCSVField("cloud_base_ft_agl", 28);
        public static TAFCSVField cloud_type = new TAFCSVField("cloud_type", 29);
        public static TAFCSVField turbulence_intensity = new TAFCSVField("turbulence_intensity", 30);
        public static TAFCSVField turbulence_min_alt_ft_agl = new TAFCSVField("turbulence_min_alt_ft_agl", 31);
        public static TAFCSVField turbulence_max_alt_ft_agl = new TAFCSVField("turbulence_max_alt_ft_agl", 32);
        public static TAFCSVField icing_intensity = new TAFCSVField("icing_intensity", 33);
        public static TAFCSVField icing_min_alt_ft_agl = new TAFCSVField("icing_min_alt_ft_agl", 34);
        public static TAFCSVField icing_max_alt_ft_agl = new TAFCSVField("icing_max_alt_ft_agl", 35);
        public static TAFCSVField valid_time = new TAFCSVField("valid_time", 36);
        public static TAFCSVField sfc_temp_c = new TAFCSVField("sfc_temp_c", 37);
        public static TAFCSVField max_or_min_temp_c = new TAFCSVField("max_or_min_temp_c", 38);

        public static TAFCSVField unknown { get; } = new TAFCSVField("UNKNOWN", 100);

        public string Name { get; private set; }

        public int Value { get; private set; }

        private TAFCSVField(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public static List<TAFCSVField> List()
        {
            return new List<TAFCSVField>() { raw_text, station_id, issue_time, bulletin_time, valid_time_from,
                valid_time_to, remarks, latitude, longitude, elevation_m, fcst_time_from, fcst_time_to,
                change_indicator, time_becoming, probability, wind_dir_degrees, wind_speed_kt, wind_gust_kt,
                wind_shear_hgt_ft_agl, wind_shear_dir_degrees, wind_shear_speed_kt, visibility_statute_mi,
                altim_in_hg, vert_vis_ft, wx_string, not_decoded, sky_cover, cloud_base_ft_agl, cloud_type,
                turbulence_intensity, turbulence_min_alt_ft_agl, turbulence_max_alt_ft_agl, icing_intensity,
                icing_min_alt_ft_agl, icing_max_alt_ft_agl, valid_time, sfc_temp_c, max_or_min_temp_c};
        }

        public static TAFCSVField ByValue(int value)
        {
            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = unknown;
            }

            return field;
        }

        public static TAFCSVField ByName(string name)
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
