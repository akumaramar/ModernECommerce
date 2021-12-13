using ModernECommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.DTO
{
    public class ProductTypeDto : DtoBase
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public String AdditionalInfo { get; set; }
    }
}
