using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AviationWx.NET.Connectors
{
    public class Http: IConnector
    {
        private static HttpClient _httpClient = new HttpClient();

        /// <summary>
        ///  
        /// </summary>
        public Http()
        {
        }

        public async Task<string> GetAsync(string url)
        {
            var result = await _httpClient.GetAsync(url);

            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();

            return response;
        }

    }
}
