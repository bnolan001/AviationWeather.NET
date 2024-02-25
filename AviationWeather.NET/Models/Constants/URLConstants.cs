namespace BNolan.AviationWx.NET.Models.Constants
{
    public static class URLConstants
    {
        public const string BaseURL = "https://aviationweather.gov";

        public const string BasePath = "/api/data/dataserver?";

        #region METAR

        public const string LatestMETAR = "dataSource=metars&requestType=retrieve&format={format}&hoursBeforeNow=12&mostRecent=true&stationString={icao}";

        public const string PreviousHoursMETARs = "dataSource=metars&requestType=retrieve&format={format}&stationString={icaos}&hoursBeforeNow={hours}";

        #endregion METAR

        #region TAF

        public const string LatestTAF = "dataSource=tafs&requestType=retrieve&format={format}&stationString={icaos}&hoursBeforeNow={hours}";

        public const string PreviousHoursTAFsInBox = "dataSource=tafs&requestType=retrieve&format={format}&minLat={minLat}&minLon={minLon}&maxLat={maxLat}&maxLon={maxLon}&hoursBeforeNow={hours}";

        public const string PreviousHoursTAFsInRadial = "dataSource=tafs&requestType=retrieve&format={format}&radialDistance={radial};{longitude},{latitude}&hoursBeforeNow={hours}";

        #endregion TAF

        #region Station Info

        public const string StationInfo = "dataSource=stations&requestType=retrieve&format={format}&stationString={icao}";

        public const string RadialSearch = "dataSource=stations&requestType=retrieve&format={format}&radialDistance={distance};{longitude},{latitude}";

        public const string BoxSearch = "dataSource=stations&requestType=retrieve&format={format}&minLat={minLat}&minLon={minLon}&maxLat={maxLat}&maxLon={maxLon}";

        #endregion Station Info
    }
}
