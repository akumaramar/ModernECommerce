using AutoMapper;
using AutoMapper.Configuration;
using CatelogService.DTO;
using CatelogService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatelogService.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductDto>();
            CreateMap<ProductDto, ProductModel>();
        }
        
    }
}
