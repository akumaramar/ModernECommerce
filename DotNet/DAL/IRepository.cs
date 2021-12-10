using DAL.Entity;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T> where T : EntityBase
    {
        //IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        //T Add(T entity);

        Task<T> AddAsync(T product);

        //T Update(T entity);

        Task<T> UpdateAsync(T entity);

        //T Find(Guid ID);

        Task<T> FindAsync(Guid ID);

        //void Delete(Guid ID);

        Task DeleteAsync(Guid ID);

    }
}
