using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public interface IProductBusiness
    {
        IEnumerable<ProductModel> GetAll();

        Task<IEnumerable<ProductModel>> GetAllAsyc();

        ProductModel Add(ProductModel product);

        ProductModel GetById(Guid id);

        ProductModel Update(ProductModel productModel);

        void Delete(Guid id);
    }
}
