using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase;

    }
}
