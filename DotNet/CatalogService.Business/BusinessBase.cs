using DAL;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CatalogService.Business
{
    public abstract class BusinessBase<T> : IBusinessService<T> where T : EntityBase
    {
        protected IServiceProvider _serviceProvider;

        public BusinessBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task<T> AddAsync(T product)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<T> repository = uow.GetRepository<T>();

                // Do you want to do something before add.
                BeforeAdd(product, uow, repository);

                // Add the product
                T model = await repository.AddAsync(product);

                // Do you want to do something after add.
                AfterAdd(model, uow, repository);

                // Commit the transaction
                uow.Save();

                return model;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<T> repository = uow.GetRepository<T>();

                // Before Delete
                BeforeDelete(id, uow, repository);

                await repository.DeleteAsync(id);

                // Do you want to do something after delete
                AfterDelete(id, uow, repository);

            }

        }



        public async Task<IEnumerable<T>> GetAllAsyc()
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<T> repository = uow.GetRepository<T>();

                IEnumerable<T> modelList = await repository.GetAllAsync();

                // Do you want to do something after finding the object
                AfterGetAll(modelList, uow, repository);

                return modelList;
            }
        }


        public async Task<T> GetByIdAsync(Guid id)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<T> repository = uow.GetRepository<T>();

                // Do you want to do something before finding
                BeforeFind(id, uow, repository);

                T model = await repository.FindAsync(id);

                // Do you want to do something after finding the object
                AfterFind(model, uow, repository);

                return model;
            }

        }

        public async Task<T> UpdateSync(T model)
        {
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<T> repository = uow.GetRepository<T>();
                T foundProduct = await repository.FindAsync(model.ID);

                if (foundProduct != null)
                {
                    // Find all properties of the model and update correspnding
                    Type type = model.GetType();
                    PropertyInfo[] properties =  type.GetProperties();
                    PropertyInfo[] targetProperties = foundProduct.GetType().GetProperties();

                    for (int index = 0; index < properties.Length; index++)
                    {
                        targetProperties[index].SetValue(foundProduct, properties[index].GetValue(model));
                    }

                    //foundProduct.Name = model.Name;
                    //foundProduct.Description = model.Description;
                    //foundProduct.ImageUrl = model.ImageUrl;

                    // Do you want to do something before update
                    BeforeUpdate(model, uow, repository);

                    T updatedModel = await repository.UpdateAsync(foundProduct);

                    // Do you want to do something after update
                    AfterUpdate(updatedModel, uow, repository);

                    // After model
                    return updatedModel;
                }

                return null;
            }
        }

        protected virtual void AfterUpdate(T updatedModel, IUnitOfWork uow, IRepository<T> prodRep) { }

        protected virtual void BeforeUpdate(T model, IUnitOfWork uow, IRepository<T> prodRep) { }

        protected virtual void BeforeAdd(T originalModel, IUnitOfWork unitOfWork, IRepository<T> modelRepository) { }

        protected virtual void AfterAdd(T addedModel, IUnitOfWork unitOfWork, IRepository<T> modelRepository) { }

        protected virtual void BeforeFind(Guid idFound, IUnitOfWork unitOfWork, IRepository<T> modelRepository) { }

        protected virtual void AfterFind(T returnedModel, IUnitOfWork unitOfWork, IRepository<T> modelRepository) { }

        protected virtual void AfterGetAll(IEnumerable<T> modelList, IUnitOfWork uow, IRepository<T> prodRep) { }

        protected virtual void AfterDelete(Guid id, IUnitOfWork uow, IRepository<T> prodRep) { }
        protected virtual void BeforeDelete(Guid id, IUnitOfWork uow, IRepository<T> prodRep) { }
    }
}
