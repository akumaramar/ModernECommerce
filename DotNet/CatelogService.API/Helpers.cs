using AutoMapper;
using Microsoft.AspNetCore.Http;
using ModernECommerce.Common.Dto;
using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatelogService.API
{
    /// <summary>
    /// Methods required for the transformation
    /// </summary>
    public static class Helpers
    {
        public static T ToEntity<T>(this DtoBase source, IMapper mapper) where T : EntityBase
        {
            return mapper.Map<T>(source);            
        }

        public static T ToDto<T>(this EntityBase source, IMapper mapper) where T : DtoBase
        {
            return mapper.Map<T>(source);
        }

        public static IEnumerable<T> ToEntityEnumerable<T>(this IEnumerable<DtoBase> source, IMapper mapper) where T : DtoBase
        {
            return mapper.Map<IEnumerable<T>>(source);
        }


        public static IEnumerable<T> ToDtoEnumerable<T>(this IEnumerable<EntityBase> source, IMapper mapper) where T : DtoBase
        {
            return mapper.Map<IEnumerable<T>>(source);
        }

    }
}
