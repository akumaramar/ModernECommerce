using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenFu;

namespace CatelogService.DAL.FakeDataProvider
{
    public class GenFuProductTypeRepository : IProductTypeRepository
    {
        private List<ProductTypeModel> _catalongBrand = new List<ProductTypeModel>();

        public GenFuProductTypeRepository()
        {
            GenFu.GenFu.Configure<ProductTypeModel>()
                .Fill(p => p.Name).AsLoremIpsumWords()
                .Fill(p => p.Description).AsLoremIpsumSentences()
                .Fill(p => p.ID, () => { return new Guid(); });

            _catalongBrand = A.ListOf<ProductTypeModel>();
        }

        public async Task<ProductTypeModel> AddAsync(ProductTypeModel product)
        {
            product.ID = Guid.NewGuid();

            _catalongBrand.Add(product);

            return await Task<CatalogBrandModel>.Run(() => {
                return product;
            });
        }

        public async Task DeleteAsync(Guid ID)
        {
            await Task.Run(() =>
            {
                ProductTypeModel product = FindAsync(ID).Result;

                if (product != null)
                {
                    product.MarkDeleted = true;
                }
            });
        }

        public async Task<ProductTypeModel> FindAsync(Guid ID)
        {
            return await Task<CatalogBrandModel>.Run(() =>
            {
                return _catalongBrand.FirstOrDefault(e => e.ID == ID && e.MarkDeleted == false);
            });
        }

        public async Task<IEnumerable<ProductTypeModel>> GetAllAsync()
        {
            return await Task<IEnumerable<CatalogBrandModel>>.Run(() =>
            {
                return _catalongBrand.FindAll(e => e.MarkDeleted == false && e.MarkDeleted == false); ;
            });
        }

        public async Task<ProductTypeModel> UpdateAsync(ProductTypeModel entity)
        {
            return await Task<ProductTypeModel>.Run(() =>
            {
                ProductTypeModel product = FindAsync(entity.ID).Result;
                product.Name = entity.Name;
                product.Description = entity.Description;
                product.AdditionalInfo = entity.AdditionalInfo;
                return product;
            });
        }
    }
}
