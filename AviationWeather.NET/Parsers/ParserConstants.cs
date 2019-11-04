using System;

namespace AviationWx.NET.Parsers
{
    public static class ParserConstants
    {
        public static readonly string StringCulture = "en-us";

        public static readonly char CSVSplitCharacter = ',';

        public static readonly string DateTimeFormat = "yyyy-MM-ddThh:mm:ssZ";

        public static readonly DateTime DefaultDateTime = new DateTime(1000, 1, 1);
    }
}
