using DAL.Entity;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();

        T Add(T entity);

        T Update(T entity);

        T Find(Guid ID);

        void Delete(Guid ID);

    }
}
