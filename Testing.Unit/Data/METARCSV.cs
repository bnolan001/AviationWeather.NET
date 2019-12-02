using System;

namespace Testing.Unit.Data
{
    public class METARCSV
    {
        public static string SINGLE_STATION_METAR_KPHL = "No errors" + Environment.NewLine +
            "No warnings" + Environment.NewLine +
            "3 ms" + Environment.NewLine +
            "data source= metars" + Environment.NewLine +
            "2 results" + Environment.NewLine +
            "raw_text, station_id, observation_time, latitude, longitude, temp_c, dewpoint_c, wind_dir_degrees, wind_speed_kt, wind_gust_kt, visibility_statute_mi, altim_in_hg, sea_level_pressure_mb, corrected, auto, auto_station, maintenance_indicator_on, no_signal, lightning_sensor_off, freezing_rain_sensor_off, present_weather_sensor_off, wx_string, sky_cover, cloud_base_ft_agl, sky_cover, cloud_base_ft_agl, sky_cover, cloud_base_ft_agl, sky_cover, cloud_base_ft_agl, flight_category, three_hr_pressure_tendency_mb, maxT_c, minT_c, maxT24hr_c, minT24hr_c, precip_in, pcp3hr_in, pcp6hr_in, pcp24hr_in, snow_in, vert_vis_ft, metar_type, elevation_m" + Environment.NewLine +
            "KDEN 310153Z 20012KT 10SM CLR M11/M17 A3022 RMK AO2 SLP312 T11111167, KDEN,2019-10-31T01:53:00Z,39.85,-104.65,-11.1,-16.7,200,12,,10.0,30.221457,1031.2,,,TRUE,,,,,,,CLR,,,,,,,,VFR,,,,,,,,,,,,METAR,1640.0" + Environment.NewLine +
            "KDEN 310053Z 20008KT 10SM FEW100 FEW200 M11/M18 A3021 RMK AO2 SLP306 T11061178, KDEN,2019-10-31T00:53:00Z,39.85,-104.65,-10.6,-17.8,200,8,,10.0,30.209646,1030.6,,,TRUE,,,,,,,FEW,10000,FEW,20000,,,,,VFR,,,,,,,,,,,,METAR,1640.0" + Environment.NewLine;
    }
}
