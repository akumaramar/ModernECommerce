using CatelogService.DAL;
using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductRepository _productRepository;
        
        public ProductBusiness(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductModel Add(ProductModel product)
        {
            return _productRepository.Add(product);

        }

        public ProductModel GetById(Guid id)
        {
            return _productRepository.Find(id);
        }
    }
}
