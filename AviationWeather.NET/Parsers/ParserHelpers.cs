using System;

namespace AviationWx.NET.Parsers
{
    public class ParserHelpers
    {
        public static Nullable<float> GetValue(bool isPresent, float value)
        {
            if (isPresent)
            {
                return value;
            }

            return null;
        }

        public static int? GetValue(bool isPresent, int value)
        {
            if (isPresent)
            {
                return value;
            }

            return null;
        }

    }
}
