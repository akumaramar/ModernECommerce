using Microsoft.Extensions.Configuration;
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
            Set("ConnectionString", Source.ConfigService.GetConfigList().Result.DbConnectionString);

            //base.Load();
            //Set("ConnectionString", "Data Source=APT04-4ZNCLH2;Initial Catalog=catalogdb;User ID=sa;Password=Ramesh17@");            
        }
    }
}
