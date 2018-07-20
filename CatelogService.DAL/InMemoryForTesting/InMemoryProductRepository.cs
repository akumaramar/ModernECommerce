using System;
using System.Collections.Generic;
using System.Text;
using CatelogService.Model;
using System.Linq;

namespace CatelogService.DAL.InMemoryForTesting
{
    public class InMemoryProductRepository : IProductRepository
    {
        private DataHolder dataHolder = new DataHolder();

        public ProductModel Add(ProductModel entity)
        {
            entity.ID = Guid.NewGuid();
            dataHolder.Products.Add(entity);
            return entity;
        }

        public void Delete(Guid ID)
        {
            ProductModel foundEntity = dataHolder.Products.FirstOrDefault(e => e.ID == ID);

            dataHolder.Products.Remove(foundEntity);
        }

        public ProductModel Find(Guid ID)
        {
            ProductModel foundEntity = dataHolder.Products.FirstOrDefault(e => e.ID == ID);

            return foundEntity;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return dataHolder.Products;
        }

        public ProductModel Update(ProductModel entity)
        {
            ProductModel foundEntity = dataHolder.Products.FirstOrDefault(e => e.ID == entity.ID);

            foundEntity.Name = entity.Name;
            foundEntity.ImageUrl = entity.ImageUrl;
            return foundEntity;
        }
    }
}
