using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public interface IProductBusiness
    {
        Task<IEnumerable<ProductModel>> GetAllAsyc();

        Task<ProductModel> AddAsync(ProductModel product);

        Task<ProductModel> GetByIdAsync(Guid id);

        Task<ProductModel> UpdateSync(ProductModel productModel);

        Task DeleteAsync(Guid id);
    }
}
