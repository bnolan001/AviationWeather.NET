namespace AviationWx.NET.Models.Constants
{
    public class URLConstants
    {
        public const string BaseURL = "https://aviationweather.gov";

        public const string BasePath = "/adds/dataserver_current/httpparam?";

        public const string LatestMETAR = "dataSource=metars&requestType=retrieve&format={format}&hoursBeforeNow=12&mostRecent=true&stationString={icao}";

        public const string PreviousHoursMETARs = "dataSource=metars&requestType=retrieve&format={format}&stationString={icaos}&hoursBeforeNow={hours}";

        public const string LatestTAF = "dataSource=tafs&requestType=retrieve&format={format}&stationString={icaos}&hoursBeforeNow={hours}";
    }
}
