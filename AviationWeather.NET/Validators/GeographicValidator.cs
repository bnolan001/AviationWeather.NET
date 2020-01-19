using System;

namespace BNolan.AviationWx.NET.Validators
{
    public static class GeographicValidator
    {
        /// <summary>
        /// Verifies the latitude value is valid.  If not it throws an exception
        /// </summary>
        /// <param name="latitude"></param>
        public static void ValidateLatitude(double latitude){
            if (latitude > 90.0 || latitude < -90.0)
            {
                throw new ArgumentOutOfRangeException("Latitude must be a value between -90.0 and 90.0", nameof(latitude));
            }
        }

        public static void ValidateLongitude(double longitude)
        {
            if(longitude > 180.0 || longitude < -180.0)
            {
                throw new ArgumentOutOfRangeException("Longitude must be a value between -180.0 and 180.0", nameof(longitude));
            }
        }
    }
}
