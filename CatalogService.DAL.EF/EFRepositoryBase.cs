using CatelogService.DAL;
using CatelogService.Model;
using DAL;
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
        private BaseDbContext<TEntity> _dbContext;

        public EFRepositoryBase()
        {

            _dbContext = new BaseDbContext<TEntity>();
            _dbContext.Database.EnsureCreated();

        }

        public TEntity Add(TEntity entity)
        {
            entity.ID = Guid.NewGuid();

            UpdateEditLogs(entity);
            _dbContext.Entities.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity product)
        {
            product.ID = Guid.NewGuid();

 
            UpdateEditLogs(product);
            _dbContext.Entities.Add(product);
            await _dbContext.SaveChangesAsync();
 
            return product;
        }

        public void Delete(Guid ID)
        {
            
            TEntity product = _dbContext.Entities.Where(p => p.ID == ID).FirstOrDefault();

            if (product != null)
            {
                _dbContext.Entities.Remove(product);
                _dbContext.SaveChanges();
            }
            
        }

        public async Task DeleteAsync(Guid ID)
        {
            TEntity product = _dbContext.Entities.Where(p => p.ID == ID).FirstOrDefault();

            if (product != null)
            {
                _dbContext.Entities.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public TEntity Find(Guid ID)
        {
            return _dbContext.Entities.Where(x => x.ID == ID).FirstOrDefault();
            
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
            return _dbContext.Entities.ToList();
            
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
            TEntity product = _dbContext.Entities.Where(p => p.ID == entity.ID).FirstOrDefault();

            if (product != null)
            {
                //product.Name = entity.Name;
                //product.Description = entity.Description;
                //product.ImageUrl = entity.ImageUrl;
                UpdateEditLogs(product);
                _dbContext.SaveChanges();
            }

            return product;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity product = _dbContext.Entities.Where(p => p.ID == entity.ID).FirstOrDefault();

            if (product != null)
            {
                //product.Name = entity.Name;
                //product.Description = entity.Description;
                //product.ImageUrl = entity.ImageUrl;
                //UpdateEditLogs(product);
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
