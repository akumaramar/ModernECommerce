using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public interface IProductBusiness : IBusinessService<ProductModel>
    {
       //TODO: Need to see what can be added here
       // We can add something which is specific to Product Business apart from base supported items
    }
}
