using System.Net.Http;
using System.Threading.Tasks;

namespace BNolan.AviationWx.NET.Connectors
{
    public class HttpConnector: IConnector
    {
        private static HttpClient _httpClient = new HttpClient();

        /// <summary>
        ///  Default constructor
        /// </summary>
        public HttpConnector()
        {
        }

        /// <summary>
        /// Sends a GET request via the HTTPClient against the requested
        /// URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string url)
        {
            var result = await _httpClient.GetAsync(url).ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            return response;
        }

    }
}
