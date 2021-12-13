using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public class CatalogBrandBusiness : BusinessBase<CatalogBrandModel>, ICatalogBrandBusiness
    {
        public CatalogBrandBusiness(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
