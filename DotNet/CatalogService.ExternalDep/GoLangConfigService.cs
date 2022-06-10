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
        private const String URLTOCONNECT = "http://host.docker.internal:8889/api/v1/configuration?name=connectionString";
        //private const String URLTOCONNECT = "http://localhost:8889/api/v1/configuration?name=connectionString";
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public GoLangConfigService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ConfigToRunApp GetConfigList()
        {
            var uri = new Uri(URLTOCONNECT);

            var stringResponse = _httpClient.GetStringAsync(uri).Result;

            return JsonSerializer.Deserialize<ConfigToRunApp>(stringResponse);

        }
    }
}
