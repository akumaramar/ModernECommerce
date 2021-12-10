using AutoMapper;
using AutoMapper.Configuration;
using CatelogService.DAL;
using CatelogService.DTO;
using CatelogService.Model;
using DAL;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatelogService.API
{
    public class MappingProfile : Profile
    {
        private IProductRepository _productRepository;
        private IServiceProvider _serviceProvider;

        public MappingProfile(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public MappingProfile()
        {
            // Product Model mapping 
            CreateMap<ProductModel, ProductDto>();
                //.ForMember(dest => dest.AvailableStocks, opt => opt.MapFrom(src => src.ID));
            CreateMap<ProductDto, ProductModel>();
            //    .ForMember<;

            // Product Catalog mapping
            CreateMap<ProductTypeModel, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductTypeModel>();

            // Product Type mapping
            CreateMap<CatalogBrandModel, CatalogBrandDto>();
            CreateMap<CatalogBrandDto, CatalogBrandModel>();

        }
        
    }

    public class CatelogIDToCatalogConverter : ITypeConverter<Guid, CatalogBrandModel>
    {
        private IServiceProvider _serviceProvider;

        public CatelogIDToCatalogConverter(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }
        public CatalogBrandModel Convert(Guid source, CatalogBrandModel destination, ResolutionContext context)
        {
            CatalogBrandModel catalogBrand = null;

            //using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            //{
            //    IRepository<CatalogBrandModel> catalogBrandRep = uow.GetRepository<CatalogBrandModel>();

            //    catalogBrand = catalogBrandRep.Find(source);
            //}

            return catalogBrand;
        }
    }
}
