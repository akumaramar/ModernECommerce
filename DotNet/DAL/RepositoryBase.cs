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
    public class EntityFrameworkRepository<T> : DbContext, IRepository<T> , IRepositoryAsync<T> where T: EntityBase
    {
        private DbSet<T> _entities;

        public EntityFrameworkRepository()
        {
            _entities = this.Set<T>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=.;Database=NewDb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.AddEntityType(typeof(T));
            base.OnModelCreating(modelBuilder);
        }

        private void UpdateStandardFields(T entity)
        {
            entity.ID = Guid.NewGuid();
            entity.LastModifiedBy = "Ajay";
            entity.LastModifiedOn = DateTime.Now;
        }

        public T Add(T enity)
        {
            UpdateStandardFields(enity);
            EntityEntry<T> t = _entities.Add(enity);
            base.SaveChanges();
            return t.Entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> t = _entities.Add(entity);
            await base.SaveChangesAsync();
            return t.Entity;
        }

        public void Delete(Guid ID)
        {
            T t = _entities.Where(e => e.ID == ID).SingleOrDefault();

            // We just need to mark this one as deleted
            t.MarkDeleted = true;

            base.SaveChanges();

        }

        public Task DeleteAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public T Find(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public new Task<T> FindAsync(Guid ID)
        {
            throw new NotImplementedException();
        }
    }
}
