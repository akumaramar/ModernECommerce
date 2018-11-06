using DAL.Entity;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepositoryAsync<T> : IRepository<T> where T : EntityBase
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> FindAsync(T entity);

        Task DeleteAsync(Guid ID);
    }
}
