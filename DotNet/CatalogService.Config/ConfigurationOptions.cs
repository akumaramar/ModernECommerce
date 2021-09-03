using CatalogService.ExternalDep;
using System;

namespace CatalogService.Config
{
    public class ConfigurationOptions
    {
        public String ServiceEndPointURL { get; set; }

        public IConfigService configService { get; set; }
    }
}
