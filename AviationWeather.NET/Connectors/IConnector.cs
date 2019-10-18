using System.Threading.Tasks;

namespace AviationWx.NET.Connectors
{
    public interface IConnector
    {
        Task<string> GetAsync(string paramPath);
    }
}
