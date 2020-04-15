using CatelogService.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatelogService.DAL
{
    /// <summary>
    /// Currently It's not doing much here. But we can plan to have something here in future
    /// </summary>
    public class ProductRepository : EntityFrameworkRepository<ProductModel>, IProductRepository
    {
        public ProductRepository()
        {

        }

    }
}
