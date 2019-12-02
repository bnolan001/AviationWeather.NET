using System;

namespace Testing.Unit.Data
{
    public class StationInfoCSV
    {
        public static string MULTIPLE_STATION_INFO_KDEN_KSEA_PHNL =
            "No errors" + Environment.NewLine +
            "No warnings" + Environment.NewLine +
            "4 ms" + Environment.NewLine +
            "data source=stations" + Environment.NewLine +
            "3 results" + Environment.NewLine +
            "station_id, wmo_id, latitude, longitude, elevation_m, site, state, country, site_type" + Environment.NewLine +
            "KDEN,72565,39.85,-104.65,1640.0,DENVER(DIA)    ,CO,US,METAR TAF" + Environment.NewLine +
            "KSEA,72793,47.45,-122.32,136.0,SEATTLE/METRO   ,WA,US,METAR TAF" + Environment.NewLine +
            "PHNL,91182,21.33,-157.92,4.0,HONOLULU        ,HI,US,METAR TAF";
    }
}
