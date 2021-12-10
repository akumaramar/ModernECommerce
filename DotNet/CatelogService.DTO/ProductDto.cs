using ModernECommerce.Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CatelogService.DTO
{
    public class ProductDto : DtoBase
    {
        [Required]
        public String Name { get; set; }

        [StringLength(500)]
        public String Description { get; set; }

        public String ImageUrl { get; set; }


        [Required]
        public int AvailableStocks { get; set; }


        //public Guid CatalogID { get; set; }

        //public Guid ProductTypeID { get; set; }

        public int RestockThreshold { get; set; }

        public int MaxStockThreshold { get; set; }
    }
}
