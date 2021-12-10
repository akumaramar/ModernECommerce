﻿using CatelogService.Model;
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
        }

        public Task<CatalogBrandModel> AddAsync(CatalogBrandModel product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<CatalogBrandModel> FindAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CatalogBrandModel>> GetAllAsync()
        {
            return await Task<IEnumerable<CatalogBrandModel>>.Run(() =>
            {
                return _catalongBrand.FindAll(e => e.MarkDeleted == false && e.MarkDeleted == false); ;
            });
        }

        public Task<CatalogBrandModel> UpdateAsync(CatalogBrandModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
