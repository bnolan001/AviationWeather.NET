using System;
using System.Collections.Generic;
using System.Linq;

namespace BNolan.AviationWx.NET.Models.Enums
{
    public class TAFCSVField
    {
        public static TAFCSVField raw_text = new TAFCSVField("raw_text", 1);
        public static TAFCSVField station_id = new TAFCSVField("station_id", raw_text.Value + 1);
        public static TAFCSVField issue_time = new TAFCSVField("issue_time", station_id.Value + 1);
        public static TAFCSVField bulletin_time = new TAFCSVField("bulletin_time", issue_time.Value + 1);
        public static TAFCSVField valid_time_from = new TAFCSVField("valid_time_from", bulletin_time.Value + 1);
        public static TAFCSVField valid_time_to = new TAFCSVField("valid_time_to", valid_time_from.Value + 1);
        public static TAFCSVField remarks = new TAFCSVField("remarks", valid_time_to.Value + 1);
        public static TAFCSVField latitude = new TAFCSVField("latitude", remarks.Value + 1);
        public static TAFCSVField longitude = new TAFCSVField("longitude", latitude.Value + 1);
        public static TAFCSVField elevation_m = new TAFCSVField("elevation_m", longitude.Value + 1);
        public static TAFCSVField fcst_time_from = new TAFCSVField("fcst_time_from", elevation_m.Value + 1);
        public static TAFCSVField fcst_time_to = new TAFCSVField("fcst_time_to", fcst_time_from.Value + 1);
        public static TAFCSVField change_indicator = new TAFCSVField("change_indicator", fcst_time_to.Value + 1);
        public static TAFCSVField time_becoming = new TAFCSVField("time_becoming", change_indicator.Value + 1);
        public static TAFCSVField probability = new TAFCSVField("probability", time_becoming.Value + 1);
        public static TAFCSVField wind_dir_degrees = new TAFCSVField("wind_dir_degrees", probability.Value + 1);
        public static TAFCSVField wind_speed_kt = new TAFCSVField("wind_speed_kt", wind_dir_degrees.Value + 1);
        public static TAFCSVField wind_gust_kt = new TAFCSVField("wind_gust_kt", wind_speed_kt.Value + 1);
        public static TAFCSVField wind_shear_hgt_ft_agl = new TAFCSVField("wind_shear_hgt_ft_agl", wind_gust_kt.Value + 1);
        public static TAFCSVField wind_shear_dir_degrees = new TAFCSVField("wind_shear_dir_degrees", wind_shear_hgt_ft_agl.Value + 1);
        public static TAFCSVField wind_shear_speed_kt = new TAFCSVField("wind_shear_speed_kt", wind_shear_dir_degrees.Value + 1);
        public static TAFCSVField visibility_statute_mi = new TAFCSVField("visibility_statute_mi", wind_shear_speed_kt.Value + 1);
        public static TAFCSVField altim_in_hg = new TAFCSVField("altim_in_hg", visibility_statute_mi.Value + 1);
        public static TAFCSVField vert_vis_ft = new TAFCSVField("vert_vis_ft", altim_in_hg.Value + 1);
        public static TAFCSVField wx_string = new TAFCSVField("wx_string", vert_vis_ft.Value + 1);
        public static TAFCSVField not_decoded = new TAFCSVField("not_decoded", wx_string.Value + 1);
        public static TAFCSVField sky_cover = new TAFCSVField("sky_cover", not_decoded.Value + 1);
        public static TAFCSVField cloud_base_ft_agl = new TAFCSVField("cloud_base_ft_agl", sky_cover.Value + 1);
        public static TAFCSVField cloud_type = new TAFCSVField("cloud_type", cloud_base_ft_agl.Value + 1);
        public static TAFCSVField turbulence_intensity = new TAFCSVField("turbulence_intensity", cloud_type.Value + 1);
        public static TAFCSVField turbulence_min_alt_ft_agl = new TAFCSVField("turbulence_min_alt_ft_agl", turbulence_intensity.Value + 1);
        public static TAFCSVField turbulence_max_alt_ft_agl = new TAFCSVField("turbulence_max_alt_ft_agl", turbulence_min_alt_ft_agl.Value + 1);
        public static TAFCSVField icing_intensity = new TAFCSVField("icing_intensity", turbulence_max_alt_ft_agl.Value + 1);
        public static TAFCSVField icing_min_alt_ft_agl = new TAFCSVField("icing_min_alt_ft_agl", icing_intensity.Value + 1);
        public static TAFCSVField icing_max_alt_ft_agl = new TAFCSVField("icing_max_alt_ft_agl", icing_min_alt_ft_agl.Value + 1);
        public static TAFCSVField valid_time = new TAFCSVField("valid_time", icing_max_alt_ft_agl.Value + 1);
        public static TAFCSVField sfc_temp_c = new TAFCSVField("sfc_temp_c", valid_time.Value + 1);
        public static TAFCSVField max_or_min_temp_c = new TAFCSVField("max_or_min_temp_c", sfc_temp_c.Value + 1);

        public static TAFCSVField Unknown { get; } = new TAFCSVField("UNKNOWN", max_or_min_temp_c.Value + 1);

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

        public static TAFCSVField ByName(string name)
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
