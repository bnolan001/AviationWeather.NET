using System.Threading.Tasks;

namespace BNolan.AviationWx.NET.Connectors
{
    /// <summary>
    /// Connector interface for use with the TAF and METAR data retrieval
    /// </summary>
    public interface IConnector
    {
        /// <summary>
        /// Requests the data via an async method and returns the string result
        /// </summary>
        /// <param name="paramPath"></param>
        /// <returns></returns>
        Task<string> GetAsync(string paramPath);
    }
}
