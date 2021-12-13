using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public class ProductTypeBusiness : BusinessBase<ProductTypeModel>, IProductTypeBusiness
    {
        public ProductTypeBusiness(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }
}
