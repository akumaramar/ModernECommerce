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
        //private IProductRepository _productRepository;
        private IServiceProvider _serviceProvider;

        public MappingProfile(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;

            CreateProfile();
        }

        public MappingProfile()
        {
            CreateProfile();

        }

        private void CreateProfile()
        {
            // Product Model mapping 
            CreateMap<ProductModel, ProductDto>()
                .ForMember(dest => dest.ProductTypeID, opt => opt.MapFrom(src => src.PType.ID))
                .ForMember(dest => dest.CatalogID, opt => opt.MapFrom(src => src.Catalog.ID));

            CreateMap<ProductDto, ProductModel>()
                .ForMember(dest => dest.PType, opt => opt.MapFrom(src => GetProductTypeFromProductId(src.ProductTypeID)))
                .ForMember(dest => dest.Catalog, opt => opt.MapFrom(src => GetCatalogBrandFromCatalogId(src.CatalogID)));

            // Product Catalog mapping
            CreateMap<ProductTypeModel, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductTypeModel>();

            // Product Type mapping
            CreateMap<CatalogBrandModel, CatalogBrandDto>();
            CreateMap<CatalogBrandDto, CatalogBrandModel>();
        }

        private CatalogBrandModel GetCatalogBrandFromCatalogId(Guid id)
        {
            CatalogBrandModel catalogBrand = null;
            
            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<CatalogBrandModel> catalogBrandRep = uow.GetRepository<CatalogBrandModel>();

                catalogBrand = catalogBrandRep.FindAsync(id).Result;
            }

            return catalogBrand;
        }

        private ProductTypeModel GetProductTypeFromProductId(Guid id)
        {
            ProductTypeModel productTypeModel = null;

            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<ProductTypeModel> productTypeResitory = uow.GetRepository<ProductTypeModel>();

                productTypeModel = productTypeResitory.FindAsync(id).Result;
            }

            return productTypeModel;
        }

    }

    //public class CatalogIDtoCatalogResolver : IValueResolver<ProductDto, ProductModel, ProductTypeModel>
    //{

    //    public ProductTypeModel Resolve(ProductDto source, ProductModel destination, ProductTypeModel destMember, ResolutionContext context)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class CatelogIDToCatalogConverter : ITypeConverter<Guid, CatalogBrandModel>
    //{
    //    private IServiceProvider _serviceProvider;

    //    public CatelogIDToCatalogConverter(IServiceProvider serviceProvider)
    //    {
    //        this._serviceProvider = serviceProvider;
    //    }


    //    //public CatalogBrandModel Convert(Guid source, CatalogBrandModel destination, ResolutionContext context)
    //    //{
    //    //    CatalogBrandModel catalogBrand = null;

    //    //    //using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
    //    //    //{
    //    //    //    IRepository<CatalogBrandModel> catalogBrandRep = uow.GetRepository<CatalogBrandModel>();

    //    //    //    catalogBrand = catalogBrandRep.Find(source);
    //    //    //}

    //    //    return catalogBrand;
    //    //}
    //}
}
