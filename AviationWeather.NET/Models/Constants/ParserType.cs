namespace AviationWx.NET.Models.Constants
{
    public class ParserType
    {
        public static ParserType XML { get; } = new ParserType(1, "XML");

        public static ParserType CSV { get; } = new ParserType(1, "CSV");

        public int Value { get; private set; }

        public string Name { get; private set; }

        public ParserType(int value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
