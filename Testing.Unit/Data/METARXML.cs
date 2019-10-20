namespace Testing.Unit.Data
{
    public class METARXML
    {
        public static readonly string SINGLE_STATION_METAR_KIAD = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<response xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XML-Schema-instance\" version=\"1.2\" xsi:noNamespaceSchemaLocation=\"http://aviationweather.gov/adds/schema/metar1_2.xsd\">" +
            "  <request_index>15836447</request_index>" +
            "  <data_source name = \"metars\" /> " +
            "  <request type=\"retrieve\" />" +
            "  <errors />" +
            "  <warnings />" +
            "  <time_taken_ms>4</time_taken_ms>" +
            "  <data num_results = \"2\" > " +
            "    <METAR> " +
            "      <raw_text>KIAD 192252Z 15003KT 10SM FEW120 SCT180 BKN230 BKN250 14/06 A3001 RMK AO2 SLP164 T01440056</raw_text>" +
            "      <station_id>KIAD</station_id>" +
            "      <observation_time>2019-10-19T22:52:00Z</observation_time>" +
            "      <latitude>38.93</latitude>" +
            "      <longitude>-77.45</longitude>" +
            "      <temp_c>14.4</temp_c>" +
            "      <dewpoint_c>5.6</dewpoint_c>" +
            "      <wind_dir_degrees>150</wind_dir_degrees>" +
            "      <wind_speed_kt>3</wind_speed_kt>" +
            "      <visibility_statute_mi>10.0</visibility_statute_mi>" +
            "      <altim_in_hg>30.008858</altim_in_hg>" +
            "      <sea_level_pressure_mb>1016.4</sea_level_pressure_mb>" +
            "      <quality_control_flags>" +
            "        <auto_station>TRUE</auto_station>" +
            "      </quality_control_flags>" +
            "      <sky_condition sky_cover = \"FEW\" cloud_base_ft_agl=\"12000\" />" +
            "      <sky_condition sky_cover = \"SCT\" cloud_base_ft_agl=\"18000\" />" +
            "      <sky_condition sky_cover = \"BKN\" cloud_base_ft_agl=\"23000\" />" +
            "      <sky_condition sky_cover = \"BKN\" cloud_base_ft_agl=\"25000\" />" +
            "      <flight_category>VFR</flight_category>" +
            "      <metar_type>METAR</metar_type>" +
            "      <elevation_m>93.0</elevation_m>" +
            "    </METAR>" +
            "    <METAR>" +
            "      <raw_text>KIAD 192152Z 17005KT 10SM SCT200 BKN250 16/05 A3001 RMK AO2 SLP163 T01560050</raw_text>" +
            "      <station_id>KIAD</station_id>" +
            "      <observation_time>2019-10-19T21:52:00Z</observation_time>" +
            "      <latitude>38.93</latitude>" +
            "      <longitude>-77.45</longitude>" +
            "      <temp_c>15.6</temp_c>" +
            "      <dewpoint_c>5.0</dewpoint_c>" +
            "      <wind_dir_degrees>170</wind_dir_degrees>" +
            "      <wind_speed_kt>5</wind_speed_kt>" +
            "      <visibility_statute_mi>10.0</visibility_statute_mi>" +
            "      <altim_in_hg>30.008858</altim_in_hg>" +
            "      <sea_level_pressure_mb>1016.3</sea_level_pressure_mb>" +
            "      <quality_control_flags>" +
            "        <auto_station>TRUE</auto_station>" +
            "      </quality_control_flags>" +
            "      <sky_condition sky_cover = \"SCT\" cloud_base_ft_agl=\"20000\" />" +
            "      <sky_condition sky_cover = \"BKN\" cloud_base_ft_agl=\"25000\" />" +
            "      <flight_category>VFR</flight_category>" +
            "      <metar_type>SPECI</metar_type>" +
            "      <elevation_m>93.0</elevation_m>" +
            "    </METAR>" +
            "  </data>" +
            "</response>";

        public static readonly string SINGLE_STATION_METAR_SPECI = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<response xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XML-Schema-instance\" version=\"1.2\" xsi:noNamespaceSchemaLocation=\"http://aviationweather.gov/adds/schema/metar1_2.xsd\">" +
            "  <request_index>15918721</request_index>" +
            "  <data_source name=\"metars\" />" +
            "  <request type=\"retrieve\" />" +
            "  <errors />" +
            "  <warnings />" +
            "  <time_taken_ms>3</time_taken_ms>" +
            "  <data num_results=\"3\">" +
            "    <METAR>" +
            "      <raw_text>KATL 192352Z 04017KT 8SM -RA BKN007 OVC012 13/11 A2976 RMK AO2 SLP076 CIG 006V009 P0004 60074 T01280106 10133 20122 56007</raw_text>" +
            "      <station_id>KATL</station_id>" +
            "      <observation_time>2019-10-19T23:52:00Z</observation_time>" +
            "      <latitude>33.63</latitude>" +
            "      <longitude>-84.45</longitude>" +
            "      <temp_c>12.8</temp_c>" +
            "      <dewpoint_c>10.6</dewpoint_c>" +
            "      <wind_dir_degrees>40</wind_dir_degrees>" +
            "      <wind_speed_kt>17</wind_speed_kt>" +
            "      <visibility_statute_mi>8.0</visibility_statute_mi>" +
            "      <altim_in_hg>29.760826</altim_in_hg>" +
            "      <sea_level_pressure_mb>1007.6</sea_level_pressure_mb>" +
            "      <quality_control_flags>" +
            "        <auto_station>TRUE</auto_station>" +
            "      </quality_control_flags>" +
            "      <wx_string>-RA</wx_string>" +
            "      <sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"700\" />" +
            "      <sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1200\" />" +
            "      <flight_category>IFR</flight_category>" +
            "      <three_hr_pressure_tendency_mb>-0.7</three_hr_pressure_tendency_mb>" +
            "      <maxT_c>13.3</maxT_c>" +
            "      <minT_c>12.2</minT_c>" +
            "      <precip_in>0.04</precip_in>" +
            "      <pcp6hr_in>0.74</pcp6hr_in>" +
            "      <metar_type>METAR</metar_type>" +
            "      <elevation_m>296.0</elevation_m>" +
            "    </METAR>" +
            "    <METAR>" +
            "      <raw_text>KATL 192252Z 06013KT 2SM -RA BR BKN006 OVC012 13/11 A2977 RMK AO2 SFC VIS 6 LTG DSNT SE SLP079 CIG 005V008 CB DSNT SE P0009 T01280106</raw_text>" +
            "      <station_id>KATL</station_id>" +
            "      <observation_time>2019-10-19T22:52:00Z</observation_time>" +
            "      <latitude>33.63</latitude>" +
            "      <longitude>-84.45</longitude>" +
            "      <temp_c>12.8</temp_c>" +
            "      <dewpoint_c>10.6</dewpoint_c>" +
            "      <wind_dir_degrees>60</wind_dir_degrees>" +
            "      <wind_speed_kt>13</wind_speed_kt>" +
            "      <visibility_statute_mi>2.0</visibility_statute_mi>" +
            "      <altim_in_hg>29.769686</altim_in_hg>" +
            "      <sea_level_pressure_mb>1007.9</sea_level_pressure_mb>" +
            "      <quality_control_flags>" +
            "        <auto_station>TRUE</auto_station>" +
            "      </quality_control_flags>" +
            "      <wx_string>-RA BR</wx_string>" +
            "      <sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"600\" />" +
            "      <sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1200\" />" +
            "      <flight_category>IFR</flight_category>" +
            "      <precip_in>0.09</precip_in>" +
            "      <metar_type>METAR</metar_type>" +
            "      <elevation_m>296.0</elevation_m>" +
            "    </METAR>" +
            "    <METAR>" +
            "      <raw_text>KATL 192152Z 07018KT 2SM -RA BR BKN007 OVC012 13/11 A2976 RMK AO2 SFC VIS 4 SLP077 CIG 006V009 P0012 T01280111</raw_text>" +
            "      <station_id>KATL</station_id>" +
            "      <observation_time>2019-10-19T21:52:00Z</observation_time>" +
            "      <latitude>33.63</latitude>" +
            "      <longitude>-84.45</longitude>" +
            "      <temp_c>12.8</temp_c>" +
            "      <dewpoint_c>11.1</dewpoint_c>" +
            "      <wind_dir_degrees>70</wind_dir_degrees>" +
            "      <wind_speed_kt>18</wind_speed_kt>" +
            "      <visibility_statute_mi>2.0</visibility_statute_mi>" +
            "      <altim_in_hg>29.760826</altim_in_hg>" +
            "      <sea_level_pressure_mb>1007.7</sea_level_pressure_mb>" +
            "      <quality_control_flags>" +
            "        <auto_station>TRUE</auto_station>" +
            "      </quality_control_flags>" +
            "      <wx_string>-RA BR</wx_string>" +
            "      <sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"700\" />" +
            "      <sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1200\" />" +
            "      <flight_category>IFR</flight_category>" +
            "      <precip_in>0.12</precip_in>" +
            "      <metar_type>SPECI</metar_type>" +
            "      <elevation_m>296.0</elevation_m>" +
            "    </METAR>" +
            "  </data>" +
            "</response>";
    }
}