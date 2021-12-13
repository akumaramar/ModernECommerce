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

        public Task<ProductTypeModel> AddAsync(ProductTypeModel product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<ProductTypeModel> FindAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductTypeModel>> GetAllAsync()
        {
            return await Task<IEnumerable<CatalogBrandModel>>.Run(() =>
            {
                return _catalongBrand.FindAll(e => e.MarkDeleted == false && e.MarkDeleted == false); ;
            });
        }

        public Task<ProductTypeModel> UpdateAsync(ProductTypeModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
