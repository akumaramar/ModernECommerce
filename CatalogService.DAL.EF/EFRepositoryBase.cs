using CatelogService.DAL;
using CatelogService.Model;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.DAL.EF
{
    public class EFRepositoryBase<TEntity> : IRepository<TEntity> where TEntity: EntityBase
    {
        private CatalogServiceDbContext _dbContext;
        private DbSet<TEntity> _entities;

        public EFRepositoryBase(IConfiguration config, CatalogServiceDbContext dbContext)
        {

            _dbContext = dbContext; // new CatalogServiceDbContext(config);
            _dbContext.Database.EnsureCreated();
            _entities = _dbContext.Set<TEntity>();

        }

        public TEntity Add(TEntity entity)
        {
            entity.ID = Guid.NewGuid();

            UpdateEditLogs(entity);
            _entities.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity product)
        {
            product.ID = Guid.NewGuid();

 
            UpdateEditLogs(product);
            _entities.Add(product);
            await _dbContext.SaveChangesAsync();
 
            return product;
        }

        public void Delete(Guid ID)
        {
            
            TEntity product = _entities.Where(p => p.ID == ID).FirstOrDefault();

            if (product != null)
            {
                _entities.Remove(product);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteAsync(Guid ID)
        {
            TEntity product = _entities.Where(p => p.ID == ID).FirstOrDefault();

            if (product != null)
            {
                _entities.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public TEntity Find(Guid ID)
        {
            return _entities.Where(x => x.ID == ID).FirstOrDefault();
            
        }

        public async Task<TEntity> FindAsync(Guid ID)
        {
            return await Task<TEntity>.Run(() =>
            {
                return Find(ID);
            });
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
            
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task<TEntity>.Run(() =>
            {
                return GetAll();
            });
        }

        public TEntity Update(TEntity entity)
        {
            TEntity product = _entities.Where(p => p.ID == entity.ID).FirstOrDefault();

            if (product != null)
            {
                UpdateEditLogs(product);
                _dbContext.SaveChanges();
            }

            return product;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity product = _entities.Where(p => p.ID == entity.ID).FirstOrDefault();

            if (product != null)
            {
                await _dbContext.SaveChangesAsync();
            }

            return product;
        }

        private void UpdateEditLogs(TEntity product)
        {
            product.LastModifiedOn = DateTime.Now;
            product.LastModifiedBy = "Ajay";
        }
    }
}
