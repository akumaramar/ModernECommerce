using CatalogService.DAL.EF;
using CatelogService.DAL;
using CatelogService.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _productRepository;
        
        //public ProductBusiness(IProductRepository productRepository)
        //{
        //    this._productRepository = productRepository;
        //}

        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<ProductModel> products = null;

            using (UnitOfWork uow = new UnitOfWork())
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
            //IEnumerable<ProductModel> products = null;

            using (UnitOfWork uow = new UnitOfWork())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                return await prodRep.GetAllAsync();
            }

            //return products;

            //return _productRepository.GetAllAsync();
        }

        public async Task<ProductModel> AddAsync(ProductModel product)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                return await prodRep.AddAsync(product);
            }

            //return _productRepository.AddAsync(product);
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                return await prodRep.FindAsync(id);
            }
            //return _productRepository.FindAsync(id);
        }

        public async Task<ProductModel> UpdateSync(ProductModel productModel)
        {
            using (UnitOfWork uow = new UnitOfWork())
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

                //throw new ApplicationException("No Product with passed ID");
                //return await prodRep.UpdateAsync(productModel);
            }
            //return _productRepository.UpdateAsync(productModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                IRepository<ProductModel> prodRep = uow.GetRepository<ProductModel>();
                await prodRep.DeleteAsync(id);
            }
            //return _productRepository.DeleteAsync(id);
        }
    }
}
