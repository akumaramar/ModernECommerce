using System;
using System.Collections.Generic;
using System.Text;
using CatelogService.Model;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ProductModel> AddAsync(ProductModel product)
        {
            return await Task<ProductModel>.Run(() =>
            {
                return Add(product); 
            });
        }

        public void Delete(Guid ID)
        {
            ProductModel foundEntity = dataHolder.Products.FirstOrDefault(e => e.ID == ID);

            dataHolder.Products.Remove(foundEntity);
        }

        public async Task DeleteAsync(Guid ID)
        {
            await Task.Run(() =>
            {
                Delete(ID);
            });

        }

        public ProductModel Find(Guid ID)
        {
            ProductModel foundEntity = dataHolder.Products.FirstOrDefault(e => e.ID == ID);

            return foundEntity;
        }

        public async Task<ProductModel> FindAsync(Guid ID)
        {
            return await Task<ProductModel>.Run(() =>
            {
                return Find(ID);
            });
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return dataHolder.Products;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await Task<IEnumerable<ProductModel>>.Run(() =>
            {
                return GetAll();
            });
        }

        public ProductModel Update(ProductModel entity)
        {
            ProductModel foundEntity = dataHolder.Products.FirstOrDefault(e => e.ID == entity.ID);

            foundEntity.Name = entity.Name;
            foundEntity.ImageUrl = entity.ImageUrl;
            return foundEntity;
        }

        public async Task<ProductModel> UpdateAsync(ProductModel entity)
        {
            return await Task<ProductModel>.Run(() =>
            {
                return Update(entity);
            });

        }
    }
}
