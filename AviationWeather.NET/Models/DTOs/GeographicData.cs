﻿namespace AviationWx.NET.Models.DTOs
{
    public class GeographicData
    {
        public float Latitude { get; set; }

        public float Longitude { get; set; }

        /// <summary>
        /// Height of the station as compared to sea level in meters
        /// </summary>
        public float Elevation_M { get; set; }
    }
}
