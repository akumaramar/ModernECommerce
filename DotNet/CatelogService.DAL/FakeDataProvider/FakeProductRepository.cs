using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CatelogService.Model;
//using Faker;

namespace CatelogService.DAL.FakeDataProvider
{
    public class FakeProductRepository : IProductRepository
    {
        private List<ProductModel> _products = new List<ProductModel>();

        public FakeProductRepository()
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    _products.Add(Faker.);
            //}
        }
        public ProductModel Add(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public ProductModel Find(Guid ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ProductModel Update(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
