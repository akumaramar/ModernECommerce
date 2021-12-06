using CatalogService.DAL.EF;
using CatelogService.DAL;
using CatelogService.Model;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private IServiceProvider _serviceProvider;

        public ProductBusiness(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        public async Task<IEnumerable<ProductModel>> GetAllAsyc()
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                return await prodRep.GetAllAsync();
            }
        }

        public async Task<ProductModel> AddAsync(ProductModel product)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                return await prodRep.AddAsync(product);
            }

        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                return await prodRep.FindAsync(id);
            }

        }

        public async Task<ProductModel> UpdateSync(ProductModel productModel)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                ProductModel product =  await prodRep.FindAsync(productModel.ID);

                if (product != null)
                {
                    product.Name = productModel.Name;
                    product.Description = productModel.Description;
                    product.ImageUrl = productModel.ImageUrl;

                    return await prodRep.UpdateAsync(product);
                }

                return null;

            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                await prodRep.DeleteAsync(id);
            }
        }
    }
}
