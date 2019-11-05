using System.Threading.Tasks;

namespace BNolan.AviationWx.NET.Connectors
{
    public interface IConnector
    {
        Task<string> GetAsync(string paramPath);
    }
}
