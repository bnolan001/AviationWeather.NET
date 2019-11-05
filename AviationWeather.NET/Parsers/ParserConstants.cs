using System;

namespace BNolan.AviationWx.NET.Parsers
{
    public static class ParserConstants
    {
        public static readonly string StringCulture = "en-US";

        public static readonly char CSVSplitCharacter = ',';

        public static readonly string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";

        public static readonly DateTimeOffset DefaultDateTime = new DateTime(1, 1, 1);
    }
}
