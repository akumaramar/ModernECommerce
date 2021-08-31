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
        private IProductRepository _productRepository;
        private IServiceProvider _serviceProvider;

        public ProductBusiness(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<ProductModel> products = null;
           
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductModel> prodRep =  uow.GetRepository<ProductModel>();
                products = prodRep.GetAll();
            }

            return products;
        }

        public ProductModel Add(ProductModel product)
        {
            return _productRepository.Add(product);

        }

        public ProductModel GetById(Guid id)
        {
            return _productRepository.Find(id);
        }

        public ProductModel Update(ProductModel productModel)
        {
            return _productRepository.Update(productModel);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
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
