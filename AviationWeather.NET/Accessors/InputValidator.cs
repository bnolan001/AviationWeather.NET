using System;
using System.Collections.Generic;
using System.Text;

namespace BNolan.AviationWx.NET.Accessors
{
    public static class InputValidator
    {
        public static bool ValidateLatitude(int latitude)
        {
            return latitude <= 90 && latitude >= -90;
        }

        public static bool ValidateLongitude(int longitude)
        {
            return longitude <= 180 && longitude >= -180;
        }
    }
}
