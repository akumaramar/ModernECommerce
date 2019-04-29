using CatelogService.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.DAL
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        
    }
}
