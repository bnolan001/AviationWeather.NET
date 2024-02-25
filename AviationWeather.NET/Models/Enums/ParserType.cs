namespace BNolan.AviationWx.NET.Models.Enums
{
    public class ParserType
    {
        public static ParserType CSV { get; } = new ParserType("csv", 1);
        public static ParserType Unknown { get; } = new ParserType("Unknown", CSV.Value + 1);

        public int Value { get; private set; }

        public string Name { get; private set; }

        public ParserType(string name, int value)
        {
            Value = value;
            Name = name;
        }

        public static List<ParserType> List()
        {
            return new List<ParserType>() { CSV, Unknown };
        }

        public static ParserType ByValue(int value)
        {
            if (value < CSV.Value)
            {
                throw new ArgumentException($"'{nameof(value)} 'must have a value greater than -1.");
            }

            var field = List().Where(m => m.Value == value).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }

        public static ParserType ByName(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"'{nameof(name)} 'must have a value.");
            }

            var field = List().Where(m => String.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (field == null)
            {
                field = Unknown;
            }

            return field;
        }
    }
}
