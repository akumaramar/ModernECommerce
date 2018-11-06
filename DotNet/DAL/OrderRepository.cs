using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// This is a wrapper around actual DB interaction layer repository. So in future we want to change the implementation
    /// of the actual DB interaction, we are mostly abstracted.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private EntityFrameworkRepository<OrderEntity> _orderRepostiory;

        public OrderRepository()
        {
            _orderRepostiory = new EntityFrameworkRepository<OrderEntity>();
        }

        public void Configure()
        {

            _orderRepostiory.Database.EnsureCreated();
        }

        public OrderEntity Add(OrderEntity entity)
        {
            return _orderRepostiory.Add(entity);
        }

        public Task<OrderEntity> AddAsync(OrderEntity entity)
        {
            return _orderRepostiory.AddAsync(entity);
        }

        public void Delete(Guid ID)
        {
            _orderRepostiory.Delete(ID);
        }

        public Task DeleteAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public OrderEntity Find(Guid ID)
        {
            return _orderRepostiory.Find(ID);
        }

        public Task<OrderEntity> FindAsync(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public OrderEntity Update(OrderEntity entity)
        {
            return _orderRepostiory.Update(entity);
        }

        public Task<OrderEntity> UpdateAsync(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
