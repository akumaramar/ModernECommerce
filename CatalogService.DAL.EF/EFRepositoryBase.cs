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
        public EFRepositoryBase()
        {
            using (var db = new BaseDbContext<TEntity>())
            {
                db.Database.EnsureCreated();
            }
        }

        public TEntity Add(TEntity entity)
        {
            entity.ID = Guid.NewGuid();

            using (var db = new BaseDbContext<TEntity>())
            {
                UpdateEditLogs(entity);
                db.Entities.Add(entity);
                db.SaveChanges();
            }
            
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity product)
        {
            product.ID = Guid.NewGuid();

            using (var db = new BaseDbContext<TEntity>())
            {
                UpdateEditLogs(product);
                db.Entities.Add(product);
                await db.SaveChangesAsync();
            }

            return product;
        }

        public void Delete(Guid ID)
        {
            using (var db = new BaseDbContext<TEntity>())
            {
                TEntity product = db.Entities.Where(p => p.ID == ID).FirstOrDefault();

                if (product != null)
                {
                    db.Entities.Remove(product);
                    db.SaveChanges();
                }
            }
        }

        public async Task DeleteAsync(Guid ID)
        {
            using (var db = new BaseDbContext<TEntity>())
            {
                TEntity product = db.Entities.Where(p => p.ID == ID).FirstOrDefault();

                if (product != null)
                {
                    db.Entities.Remove(product);
                    await db.SaveChangesAsync();
                }
            }
        }

        public TEntity Find(Guid ID)
        {
            using (var db = new BaseDbContext<TEntity>())
            {
                return db.Entities.Where(x => x.ID == ID).FirstOrDefault();
            }
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
            using (var db = new BaseDbContext<TEntity>())
            {
                return db.Entities.ToList();
            }
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
            using (var db = new BaseDbContext<TEntity>())
            {
                TEntity product = db.Entities.Where(p => p.ID == entity.ID).FirstOrDefault();

                if (product != null)
                {
                    //product.Name = entity.Name;
                    //product.Description = entity.Description;
                    //product.ImageUrl = entity.ImageUrl;
                    UpdateEditLogs(product);
                    db.SaveChanges();
                }

                return product;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var db = new BaseDbContext<TEntity>())
            {
                TEntity product = db.Entities.Where(p => p.ID == entity.ID).FirstOrDefault();

                if (product != null)
                {
                    //product.Name = entity.Name;
                    //product.Description = entity.Description;
                    //product.ImageUrl = entity.ImageUrl;
                    //UpdateEditLogs(product);
                    await db.SaveChangesAsync();
                }

                return product;
            }
        }

        private void UpdateEditLogs(TEntity product)
        {
            product.LastModifiedOn = DateTime.Now;
            product.LastModifiedBy = "Ajay";
        }
    }
}
