using System;
using System.Collections.Generic;
using System.Text;
using CatelogService.Model;
using GenFu;
using ModernECommerce.Common.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CatelogService.DAL.FakeDataProvider
{
    public class GenFuProductRepository : IProductRepository
    {
        private List<ProductModel> _products = new List<ProductModel>();

        public GenFuProductRepository()
        {
            GenFu.GenFu.Configure<ProductModel>()
                .Fill(p => p.Name).AsLastName()
                .Fill(p => p.ID, () => { return Guid.NewGuid(); });

            _products = A.ListOf<ProductModel>();

        }

        public ProductModel Add(ProductModel entity)
        {
            entity.ID = Guid.NewGuid();
            _products.Add(entity);
            return entity;
        }

        public async Task<ProductModel> AddAsync(ProductModel entity)
        {
            entity.ID = Guid.NewGuid();

            return await Task<ProductModel>.Run(() =>
            {
                return Add(entity);
            });

        }

        public void Delete(Guid ID)
        {
            ProductModel product  = Find(ID);

            if (product != null)
            {
                product.MarkDeleted = true;
            }
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
            return _products.FirstOrDefault(e => e.ID == ID && e.MarkDeleted == false);
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
            return _products.FindAll(e => e.MarkDeleted == false && e.MarkDeleted == false);
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
            ProductModel product = Find(entity.ID);
            product.Name = entity.Name;
            product.Description = entity.Description;
            return product;
        }

        public async Task<ProductModel> UpdateAsync(ProductModel entity)
        {
            return await Task<ProductModel>.Run(() =>
            {
                return Update(entity);
            });
        }
    }

    public static class StringFillerExtensions
    {
        public static GenFuConfigurator<T> AsID<T>(this GenFuStringConfigurator<T> configurator) where T : new ()
        {
            var filler = new CustomFiller<Guid>(configurator.PropertyInfo.Name,
                typeof(T),
                () =>
                {
                    return Guid.NewGuid();
                });

            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }
  }
