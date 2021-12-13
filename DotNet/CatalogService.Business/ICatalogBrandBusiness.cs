using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public interface ICatalogBrandBusiness : IBusinessService<CatalogBrandModel>
    {
        //TODO: Need to see what can be added here
        // We can add something which is specific to Product Business apart from base supported items
    }
}
