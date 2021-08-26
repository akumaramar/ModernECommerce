using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DAL;

namespace CatalogService.DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, Object> repositories = new Dictionary<string, Object>();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            Type repType = typeof(EFRepositoryBase<TEntity>);
            String repositoryName = repType.FullName;

            if (!repositories.ContainsKey(repositoryName))
            {
                var repInstance = Activator.CreateInstance(repType);
                repositories.Add(repositoryName, repInstance);
            }

            return repositories[repositoryName] as IRepository<TEntity>;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
