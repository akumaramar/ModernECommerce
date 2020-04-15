using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModernECommerce.Common.Entity;

namespace DAL
{
    public class EntityFrameworkRepository<T> : DbContext, IRepository<T> where T: EntityBase
    {
        private DbSet<T> _entities;

        public EntityFrameworkRepository()
        {
            _entities = this.Set<T>();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //String connectionString = "Server=.;Database=NewDb;Trusted_Connection=True;";
            String connectionString = "Server=localhost, 1433;Database=CatalogDB;User Id=sa;Password=Ramesh17@;";
            optionsBuilder.UseSqlServer(connectionString);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dynmically Add this model

            // Find a better way to scan through all the Models and add them dynamically
            modelBuilder.Model.AddEntityType(typeof(T));
            base.OnModelCreating(modelBuilder);
        
        }

        private void UpdateStandardFields(T entity)
        {
            entity.ID = Guid.NewGuid();
            entity.LastModifiedBy = "Ajay";
            entity.LastModifiedOn = DateTime.Now;
        }

        public T Add(T entity)
        {
            UpdateStandardFields(entity);
            EntityEntry<T> t = _entities.Add(entity);
            base.SaveChanges();
            return t.Entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            UpdateStandardFields(entity);
            EntityEntry<T> t = _entities.Add(entity);
            await base.SaveChangesAsync();
            return t.Entity;
        }

        public void Delete(Guid ID)
        {
            T t = _entities.Where(e => e.ID == ID).SingleOrDefault();

            // We just need to mark this one as deleted
            if (t != null)
            {
                t.MarkDeleted = true;

                base.SaveChanges();
            }

           

        }

        public async Task DeleteAsync(Guid ID)
        {
            T t = await _entities.FirstOrDefaultAsync<T>(p => p.ID == ID && p.MarkDeleted == false);

            if(t != null)
            {
                t.MarkDeleted = true;
                await base.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }

        public T Find(Guid ID)
        {
            T t = _entities.FirstOrDefault<T>(p => p.ID == ID && p.MarkDeleted == false);

            return t;

        }

        public Task<T> FindAsync(T entity)
        {

            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            T t = _entities.FirstOrDefault<T>(p => p.ID == entity.ID);
            base.Entry<T>(t).CurrentValues.SetValues(entity);
            base.SaveChanges();
            return entity;
            //throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            base.Entry<T>(entity).State = EntityState.Modified;
            await base.SaveChangesAsync();
            return entity;

            //throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where<T>(a => a.MarkDeleted == false); //.Select<T>(a => a.  .Find<T>(a => a.) //.ToList<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> returnEntities = await _entities.Where<T>(a => a.MarkDeleted == false).ToListAsync<T>();
            return returnEntities;
        }

        public async Task<T> FindAsync(Guid ID)
        {
            T t = await _entities.FirstOrDefaultAsync<T>(p => p.ID == ID && p.MarkDeleted == false);
            return t;
        }
    }
}
