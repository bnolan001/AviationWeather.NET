namespace Testing.Unit.Data
{
    public class TAFXML
    {
        public static readonly string SINGLE_STATION_NO_ICING_NO_TURBULENCE = "<response xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XML-Schema-instance\" version=\"1.2\" xsi:noNamespaceSchemaLocation=\"http://aviationweather.gov/adds/schema/taf1_2.xsd\">" +
            "<request_index>69296481</request_index>" +
            "<data_source name=\"tafs\"/>" +
            "<request type=\"retrieve\"/>" +
            "<errors/>" +
            "<warnings/>" +
            "<time_taken_ms>9</time_taken_ms>" +
            "<data num_results=\"11\">" +
            "<TAF>" +
            "<raw_text>KPHL 262320Z 2700/2806 11008KT P6SM SCT040 BKN100 FM270800 10010KT P6SM BKN020 OVC040 FM271000 10012G20KT 5SM -RA BR OVC010 WS020/16040KT FM271300 15014G24KT 3SM +RA BR OVC008 WS020/19045KT FM271700 20010G18KT 5SM -RA BR OVC015 FM271900 24011KT P6SM SCT050</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T23:20:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T23:20:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-27T00:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-28T06:00:00Z</valid_time_to>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T00:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>110</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"4000\"/>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"10000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T10:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"2000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"4000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T10:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T13:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>12</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<wind_shear_hgt_ft_agl>2000</wind_shear_hgt_ft_agl>" +
            "<wind_shear_dir_degrees>160</wind_shear_dir_degrees>" +
            "<wind_shear_speed_kt>40</wind_shear_speed_kt>" +
            "<visibility_statute_mi>5.0</visibility_statute_mi>" +
            "<wx_string>-RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T13:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T17:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>150</wind_dir_degrees>" +
            "<wind_speed_kt>14</wind_speed_kt>" +
            "<wind_gust_kt>24</wind_gust_kt>" +
            "<wind_shear_hgt_ft_agl>2000</wind_shear_hgt_ft_agl>" +
            "<wind_shear_dir_degrees>190</wind_shear_dir_degrees>" +
            "<wind_shear_speed_kt>45</wind_shear_speed_kt>" +
            "<visibility_statute_mi>3.0</visibility_statute_mi>" +
            "<wx_string>+RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"800\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T17:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T19:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>200</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<wind_gust_kt>18</wind_gust_kt>" +
            "<visibility_statute_mi>5.0</visibility_statute_mi>" +
            "<wx_string>-RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1500\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T19:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-28T06:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>240</wind_dir_degrees>" +
            "<wind_speed_kt>11</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"5000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 262039Z 2621/2724 13008KT P6SM SCT060 BKN100 FM270600 09010KT P6SM BKN040 OVC100 FM270800 10010KT P6SM BKN020 OVC040 FM271000 10012G20KT 5SM -RA BR OVC010 WS020/16040KT FM271300 15014G24KT 3SM +RA BR OVC008 WS020/19045KT FM271700 20010G18KT 5SM -RA BR OVC015 FM271900 27012G20KT P6SM SCT035</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T20:39:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T20:39:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T21:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-28T00:00:00Z</valid_time_to>" +
            "<remarks>AMD</remarks>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T21:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T06:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>130</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"6000\"/>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"10000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T06:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>90</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"4000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"10000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T10:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"2000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"4000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T10:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T13:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>12</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<wind_shear_hgt_ft_agl>2000</wind_shear_hgt_ft_agl>" +
            "<wind_shear_dir_degrees>160</wind_shear_dir_degrees>" +
            "<wind_shear_speed_kt>40</wind_shear_speed_kt>" +
            "<visibility_statute_mi>5.0</visibility_statute_mi>" +
            "<wx_string>-RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T13:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T17:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>150</wind_dir_degrees>" +
            "<wind_speed_kt>14</wind_speed_kt>" +
            "<wind_gust_kt>24</wind_gust_kt>" +
            "<wind_shear_hgt_ft_agl>2000</wind_shear_hgt_ft_agl>" +
            "<wind_shear_dir_degrees>190</wind_shear_dir_degrees>" +
            "<wind_shear_speed_kt>45</wind_shear_speed_kt>" +
            "<visibility_statute_mi>3.0</visibility_statute_mi>" +
            "<wx_string>+RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"800\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T17:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T19:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>200</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<wind_gust_kt>18</wind_gust_kt>" +
            "<visibility_statute_mi>5.0</visibility_statute_mi>" +
            "<wx_string>-RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1500\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T19:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-28T00:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>270</wind_dir_degrees>" +
            "<wind_speed_kt>12</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"3500\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 261743Z 2618/2724 10008KT P6SM BKN100 FM270600 09010KT P6SM BKN040 OVC100 FM270800 10010KT P6SM BKN020 OVC040 FM271000 10012G20KT 5SM -RA BR OVC010 WS020/16040KT FM271300 15014G24KT 3SM +RA BR OVC008 WS020/19045KT FM271700 20010G18KT 5SM -RA BR OVC015 FM271900 27012G20KT P6SM SCT035</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T17:43:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T17:43:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T18:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-28T00:00:00Z</valid_time_to>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T18:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T06:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"10000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T06:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>90</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"4000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"10000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T10:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"2000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"4000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T10:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T13:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>12</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<wind_shear_hgt_ft_agl>2000</wind_shear_hgt_ft_agl>" +
            "<wind_shear_dir_degrees>160</wind_shear_dir_degrees>" +
            "<wind_shear_speed_kt>40</wind_shear_speed_kt>" +
            "<visibility_statute_mi>5.0</visibility_statute_mi>" +
            "<wx_string>-RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T13:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T17:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>150</wind_dir_degrees>" +
            "<wind_speed_kt>14</wind_speed_kt>" +
            "<wind_gust_kt>24</wind_gust_kt>" +
            "<wind_shear_hgt_ft_agl>2000</wind_shear_hgt_ft_agl>" +
            "<wind_shear_dir_degrees>190</wind_shear_dir_degrees>" +
            "<wind_shear_speed_kt>45</wind_shear_speed_kt>" +
            "<visibility_statute_mi>3.0</visibility_statute_mi>" +
            "<wx_string>+RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"800\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T17:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T19:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>200</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<wind_gust_kt>18</wind_gust_kt>" +
            "<visibility_statute_mi>5.0</visibility_statute_mi>" +
            "<wx_string>-RA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1500\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T19:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-28T00:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>270</wind_dir_degrees>" +
            "<wind_speed_kt>12</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"3500\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 261504Z 2615/2718 08010KT P6SM BKN250 FM270700 09007KT P6SM OVC050 FM270800 10008KT P6SM OVC020 FM270900 10008KT P6SM -RA OVC035 FM271200 12011G20KT 3SM +SHRA OVC008</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T15:04:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T15:04:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T15:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T18:00:00Z</valid_time_to>" +
            "<remarks>AMD</remarks>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T15:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T07:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>80</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T07:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>90</wind_dir_degrees>" +
            "<wind_speed_kt>7</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"5000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T09:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"2000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T09:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T12:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<wx_string>-RA</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"3500\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T12:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T18:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>120</wind_dir_degrees>" +
            "<wind_speed_kt>11</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<visibility_statute_mi>3.0</visibility_statute_mi>" +
            "<wx_string>+SHRA</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"800\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 261127Z 2612/2718 03004KT P6SM FEW150 BKN250 FM270700 09007KT P6SM OVC050 FM270800 10008KT P6SM OVC020 FM270900 10008KT P6SM -RA OVC035 FM271200 12011G20KT 3SM +SHRA OVC008</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T11:27:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T11:27:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T12:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T18:00:00Z</valid_time_to>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T12:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T07:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>30</wind_dir_degrees>" +
            "<wind_speed_kt>4</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"FEW\" cloud_base_ft_agl=\"15000\"/>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T07:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>90</wind_dir_degrees>" +
            "<wind_speed_kt>7</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"5000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T09:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"2000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T09:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T12:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<wx_string>-RA</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"3500\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T12:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T18:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>120</wind_dir_degrees>" +
            "<wind_speed_kt>11</wind_speed_kt>" +
            "<wind_gust_kt>20</wind_gust_kt>" +
            "<visibility_statute_mi>3.0</visibility_statute_mi>" +
            "<wx_string>+SHRA</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"800\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 260848Z 2609/2712 25003KT P6SM BKN100 OVC250 FM270500 09007KT P6SM OVC050 FM270800 10008KT P6SM VCSH OVC020 FM271100 11010KT 3SM -SHRA BR OVC010</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T08:48:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T08:48:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T09:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T12:00:00Z</valid_time_to>" +
            "<remarks>AMD</remarks>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T09:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T05:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>250</wind_dir_degrees>" +
            "<wind_speed_kt>3</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"10000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T05:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>90</wind_dir_degrees>" +
            "<wind_speed_kt>7</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"5000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T11:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<wx_string>VCSH</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"2000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T11:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T12:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>110</wind_dir_degrees>" +
            "<wind_speed_kt>10</wind_speed_kt>" +
            "<visibility_statute_mi>3.0</visibility_statute_mi>" +
            "<wx_string>-SHRA BR</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"1000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 260539Z 2606/2712 25003KT P6SM BKN100 OVC250 FM270500 09007KT P6SM OVC050 FM270800 10008KT P6SM OVC020 FM270900 10008KT P6SM -RA OVC020</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T05:39:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T05:39:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T06:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T12:00:00Z</valid_time_to>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T06:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T05:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>250</wind_dir_degrees>" +
            "<wind_speed_kt>3</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"10000\"/>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T05:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T08:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>90</wind_dir_degrees>" +
            "<wind_speed_kt>7</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"5000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T09:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"2000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T09:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T12:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<wx_string>-RA</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"2000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 260241Z 2603/2706 22004KT P6SM SCT035 BKN200 FM261500 05007KT P6SM BKN200 FM262100 12005KT P6SM BKN120 FM270400 10006KT P6SM VCSH OVC040</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-26T02:41:00Z</issue_time>" +
            "<bulletin_time>2019-10-26T02:41:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T03:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T06:00:00Z</valid_time_to>" +
            "<remarks>AMD</remarks>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T03:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T15:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>220</wind_dir_degrees>" +
            "<wind_speed_kt>4</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"3500\"/>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T15:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T21:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>50</wind_dir_degrees>" +
            "<wind_speed_kt>7</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T21:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T04:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>120</wind_dir_degrees>" +
            "<wind_speed_kt>5</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"12000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T04:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T06:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>6</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<wx_string>VCSH</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"4000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 252320Z 2600/2706 22004KT P6SM SCT035 BKN200 FM260800 34003KT P6SM SCT120 FM261500 05007KT P6SM BKN200 FM262100 12005KT P6SM BKN120 FM270400 10006KT P6SM VCSH OVC040</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-25T23:20:00Z</issue_time>" +
            "<bulletin_time>2019-10-25T23:20:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-26T00:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T06:00:00Z</valid_time_to>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T00:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T08:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>220</wind_dir_degrees>" +
            "<wind_speed_kt>4</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"3500\"/>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T08:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T15:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>340</wind_dir_degrees>" +
            "<wind_speed_kt>3</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"12000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T15:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T21:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>50</wind_dir_degrees>" +
            "<wind_speed_kt>7</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T21:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T04:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>120</wind_dir_degrees>" +
            "<wind_speed_kt>5</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"12000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-27T04:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T06:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>6</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<wx_string>VCSH</wx_string>" +
            "<sky_condition sky_cover=\"OVC\" cloud_base_ft_agl=\"4000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 252057Z 2521/2624 22008KT P6SM SCT040 BKN200 FM260600 32003KT P6SM SCT250 FM261200 02004KT P6SM FEW250 FM261600 06005KT P6SM BKN200 FM262100 10006KT P6SM BKN080</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-25T20:57:00Z</issue_time>" +
            "<bulletin_time>2019-10-25T20:57:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-25T21:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T00:00:00Z</valid_time_to>" +
            "<remarks>AMD</remarks>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-25T21:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T06:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>220</wind_dir_degrees>" +
            "<wind_speed_kt>8</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"4000\"/>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T06:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T12:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>320</wind_dir_degrees>" +
            "<wind_speed_kt>3</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T12:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T16:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>20</wind_dir_degrees>" +
            "<wind_speed_kt>4</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"FEW\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T16:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T21:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>60</wind_dir_degrees>" +
            "<wind_speed_kt>5</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T21:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T00:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>6</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"8000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "<TAF>" +
            "<raw_text>KPHL 251725Z 2518/2624 20006KT P6SM BKN200 FM260600 VRB03KT P6SM SCT250 FM261600 06005KT P6SM BKN200 FM262100 10006KT P6SM BKN080</raw_text>" +
            "<station_id>KPHL</station_id>" +
            "<issue_time>2019-10-25T17:25:00Z</issue_time>" +
            "<bulletin_time>2019-10-25T17:25:00Z</bulletin_time>" +
            "<valid_time_from>2019-10-25T18:00:00Z</valid_time_from>" +
            "<valid_time_to>2019-10-27T00:00:00Z</valid_time_to>" +
            "<latitude>39.87</latitude>" +
            "<longitude>-75.23</longitude>" +
            "<elevation_m>18.0</elevation_m>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-25T18:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T06:00:00Z</fcst_time_to>" +
            "<wind_dir_degrees>200</wind_dir_degrees>" +
            "<wind_speed_kt>6</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T06:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T16:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>0</wind_dir_degrees>" +
            "<wind_speed_kt>3</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"SCT\" cloud_base_ft_agl=\"25000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T16:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-26T21:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>60</wind_dir_degrees>" +
            "<wind_speed_kt>5</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"20000\"/>" +
            "</forecast>" +
            "<forecast>" +
            "<fcst_time_from>2019-10-26T21:00:00Z</fcst_time_from>" +
            "<fcst_time_to>2019-10-27T00:00:00Z</fcst_time_to>" +
            "<change_indicator>FM</change_indicator>" +
            "<wind_dir_degrees>100</wind_dir_degrees>" +
            "<wind_speed_kt>6</wind_speed_kt>" +
            "<visibility_statute_mi>6.21</visibility_statute_mi>" +
            "<sky_condition sky_cover=\"BKN\" cloud_base_ft_agl=\"8000\"/>" +
            "</forecast>" +
            "</TAF>" +
            "</data>" +
            "</response>";
    }
}
