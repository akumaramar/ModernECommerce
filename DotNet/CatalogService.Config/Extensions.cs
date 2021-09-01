using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Config
{
    public static class ExtensionMethods
    {
        public static IConfigurationBuilder AddMyConfiguration(this IConfigurationBuilder configuration, Action<ConfigurationOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            var configurationOptions = new ConfigurationOptions();
            options(configurationOptions);
            configuration.Add(new ServiceConfogurationSource(configurationOptions));
            return configuration;

            //_ = options ?? throw new ArgumentNullException(nameof(options));
            //var myConfigurationOptions = new MyConfigurationOptions();
            //options(myConfigurationOptions);
            //configuration.Add(new MyConfigurationSource(myConfigurationOptions));
            //return configuration;
        }
    }
    
}
