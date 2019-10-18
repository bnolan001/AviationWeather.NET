using System.Collections.Generic;

namespace AviationWx.NET.Parsers
{
    public interface IParser<T>
    {
        List<T> Parse(string data, IList<string> icaos);
    }
}
