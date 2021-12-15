using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenFu;

namespace CatelogService.DAL.FakeDataProvider
{
    public class GenFuCatalogBrandRepository : ICatalogBrandRepository
    {
        private List<CatalogBrandModel> _catalongBrand = new List<CatalogBrandModel>();

        public GenFuCatalogBrandRepository()
        {
            GenFu.GenFu.Configure<CatalogBrandModel>()
                .Fill(p => p.BrandName).AsMusicArtistName()
                .Fill(p => p.BrandDescription).AsMusicGenreDescription()
                .Fill(p => p.ID, () => { return new Guid(); });

            _catalongBrand = A.ListOf<CatalogBrandModel>();
        }

        public async Task<CatalogBrandModel> AddAsync(CatalogBrandModel product)
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
                CatalogBrandModel product = FindAsync(ID).Result;

                if (product != null)
                {
                    product.MarkDeleted = true;
                }
            });
        }

        public async Task<CatalogBrandModel> FindAsync(Guid ID)
        {
            return await Task<CatalogBrandModel>.Run(() =>
            {
                return _catalongBrand.FirstOrDefault(e => e.ID == ID && e.MarkDeleted == false);
            });
        }

        public async Task<IEnumerable<CatalogBrandModel>> GetAllAsync()
        {
            return await Task<IEnumerable<CatalogBrandModel>>.Run(() =>
            {
                return _catalongBrand.FindAll(e => e.MarkDeleted == false && e.MarkDeleted == false); ;
            });
        }

        public async Task<CatalogBrandModel> UpdateAsync(CatalogBrandModel entity)
        {
            return await Task<CatalogBrandModel>.Run(() =>
            {
                CatalogBrandModel product = FindAsync(entity.ID).Result;
                product.BrandName = entity.BrandName;
                product.BrandDescription = entity.BrandDescription;
                return product;
            });
        }
    }
}
