using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.DAL.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, Object> repositories = new Dictionary<string, Object>();
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityBase
        {
            Type repType = typeof(IRepository<TEntity>);
            String repositoryName = repType.FullName;

            

            if (!repositories.ContainsKey(repositoryName))
            {
                var repInstance = _serviceProvider.GetRequiredService(repType);
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
