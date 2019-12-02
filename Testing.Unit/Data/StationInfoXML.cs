using System;

namespace Testing.Unit.Data
{
    public class StationInfoXML
    {
        public static string MULTIPLE_STATION_KIAD_ORBB_ZBAA =
            "<response xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XML-Schema-instance\" version=\"1.0\" xsi:noNamespaceSchemaLocation=\"http://weather.aero/schema/station1_0.xsd\">" + Environment.NewLine +
            "<request_index>7850904</request_index>" + Environment.NewLine +
            "<data_source name=\"stations\"/>" + Environment.NewLine +
            "<request type=\"retrieve\"/>" + Environment.NewLine +
            "<errors/>" + Environment.NewLine +
            "<warnings/>" + Environment.NewLine +
            "<time_taken_ms>4</time_taken_ms>" + Environment.NewLine +
            "<data num_results=\"3\">" + Environment.NewLine +
            "<Station>" + Environment.NewLine +
            "<station_id>KIAD</station_id>" + Environment.NewLine +
            "<wmo_id>72403</wmo_id>" + Environment.NewLine +
            "<latitude>38.93</latitude>" + Environment.NewLine +
            "<longitude>-77.45</longitude>" + Environment.NewLine +
            "<elevation_m>93.0</elevation_m>" + Environment.NewLine +
            "<site>WASH DC/DULLES</site>" + Environment.NewLine +
            "<state>VA</state>" + Environment.NewLine +
            "<country>US</country>" + Environment.NewLine +
            "<site_type>" + Environment.NewLine +
            "<METAR/>" + Environment.NewLine +
            "<rawinsonde/>" + Environment.NewLine +
            "<TAF/>" + Environment.NewLine +
            "</site_type>" + Environment.NewLine +
            "</Station>" + Environment.NewLine +
            "<Station>" + Environment.NewLine +
            "<station_id>ORBB</station_id>" + Environment.NewLine +
            "<wmo_id>40650</wmo_id>" + Environment.NewLine +
            "<latitude>33.22</latitude>" + Environment.NewLine +
            "<longitude>44.22</longitude>" + Environment.NewLine +
            "<elevation_m>34.0</elevation_m>" + Environment.NewLine +
            "<site>BAGHDAD-SIRSENK</site>" + Environment.NewLine +
            "<country>IQ</country>" + Environment.NewLine +
            "<site_type>" + Environment.NewLine +
            "<METAR/>" + Environment.NewLine +
            "</site_type>" + Environment.NewLine +
            "</Station>" + Environment.NewLine +
            "<Station>" + Environment.NewLine +
            "<station_id>ZBAA</station_id>" + Environment.NewLine +
            "<wmo_id>54511</wmo_id>" + Environment.NewLine +
            "<latitude>40.07</latitude>" + Environment.NewLine +
            "<longitude>116.58</longitude>" + Environment.NewLine +
            "<elevation_m>30.0</elevation_m>" + Environment.NewLine +
            "<site>BEIJING/PEKING</site>" + Environment.NewLine +
            "<country>CN</country>" + Environment.NewLine +
            "<site_type>" + Environment.NewLine +
            "<METAR/>" + Environment.NewLine +
            "<TAF/>" + Environment.NewLine +
            "</site_type>" + Environment.NewLine +
            "</Station>" + Environment.NewLine +
            "</data>" + Environment.NewLine +
            "</response>";
    }
}
