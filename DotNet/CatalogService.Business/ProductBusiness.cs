using CatalogService.DAL.EF;
using CatelogService.DAL;
using CatelogService.Model;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public class ProductBusiness : BusinessBase<ProductModel>, IProductBusiness //IProductBusiness
    {
        public ProductBusiness(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        protected override void AfterGetAll(IEnumerable<ProductModel> modelList, IUnitOfWork uow, IRepository<ProductModel> prodRep)
        {
            base.AfterGetAll(modelList, uow, prodRep);

            // Load the child records of Product
            
        }

    }
}
