using Microsoft.Extensions.Configuration;
using ModernECommerce.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Config
{
    public class ServiceConfigProvider : ConfigurationProvider
    {
        public ServiceConfogurationSource Source { get; }

        public ServiceConfigProvider(ServiceConfogurationSource source)
        {
            Source = source;
        }

        public override void Load()
        {
            Set(GlobalConstants.CONNECTIONSTRING, Source.ConfigService.GetConfigList().DbConnectionString);
                        
        }
    }
}
