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
            CreateMap<ProductModel, ProductDto>()
                .ForMember(dest => dest.AvailableStocks, opt => opt.MapFrom(src => src.ID));
            //CreateMap<ProductDto, ProductModel>()
            //    .ForMember<;
        }
        
    }

    public class CatelogIDToCatalogConverter : ITypeConverter<Guid, CatalogBrand>
    {
        private IServiceProvider _serviceProvider;

        public CatelogIDToCatalogConverter(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }
        public CatalogBrand Convert(Guid source, CatalogBrand destination, ResolutionContext context)
        {
            CatalogBrand catalogBrand;

            using (IUnitOfWork uow = _serviceProvider.GetService<IUnitOfWork>())
            {
                IRepository<CatalogBrand> catalogBrandRep = uow.GetRepository<CatalogBrand>();

                catalogBrand = catalogBrandRep.Find(source);
            }

            return catalogBrand;
        }
    }
}
