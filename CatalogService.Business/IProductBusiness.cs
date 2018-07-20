using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business
{
    public interface IProductBusiness
    {
        IEnumerable<ProductModel> GetAll();

        ProductModel Add(ProductModel product);

        ProductModel GetById(Guid id);
    }
}
