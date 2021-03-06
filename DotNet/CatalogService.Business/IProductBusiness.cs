﻿using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business
{
    public interface IProductBusiness
    {
        IEnumerable<ProductModel> GetAll();

        Task<IEnumerable<ProductModel>> GetAllAsyc();

        ProductModel Add(ProductModel product);

        Task<ProductModel> AddAsync(ProductModel product);

        ProductModel GetById(Guid id);

        Task<ProductModel> GetByIdAsync(Guid id);

        ProductModel Update(ProductModel productModel);

        Task<ProductModel> UpdateSync(ProductModel productModel);

        void Delete(Guid id);

        Task DeleteAsync(Guid id);
    }
}
