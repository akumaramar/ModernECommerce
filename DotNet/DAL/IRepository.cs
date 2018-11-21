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
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T Add(T entity);

        T Update(T entity);

        T Find(Guid ID);

        void Delete(Guid ID);

    }
}
