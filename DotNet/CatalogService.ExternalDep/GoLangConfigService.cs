using CatalogService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogService.ExternalDep
{
    public class GoLangConfigService : IConfigService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public GoLangConfigService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ConfigToRunApp> GetConfigList()
        {
            var uri = new Uri("http://localhost:5120/api/v1/configuration?name=connectionString");

            var stringResponse = await _httpClient.GetStringAsync(uri);

            return JsonSerializer.Deserialize<ConfigToRunApp>(stringResponse);

        }
    }
}
