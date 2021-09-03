using CatalogService.ExternalDep;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Config
{
    public class ServiceConfogurationSource : IConfigurationSource
    {
        public string ServiceEndpointURL { get; set; }
        public IConfigService ConfigService { get; set; }
         


        public ServiceConfogurationSource(ConfigurationOptions options)
        {
            ServiceEndpointURL = options.ServiceEndPointURL;
            ConfigService = options.configService;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ServiceConfigProvider(this);
        }
    }
}
