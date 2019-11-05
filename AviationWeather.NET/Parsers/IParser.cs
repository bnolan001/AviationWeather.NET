using System.Collections.Generic;

namespace BNolan.AviationWx.NET.Parsers
{
    public interface IParser<T>
    {
        List<T> Parse(string data, IList<string> icaos);
    }
}
