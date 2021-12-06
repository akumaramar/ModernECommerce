using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CatelogService.Model
{
    public class ProductModel : EntityBase
    {
        [StringLength(300)]
        public String Name { get; set; }


        [StringLength(500)]
        public String Description { get; set; }

        public String ImageUrl { get; set; }

        [Required]
        public ProductTypeModel PType { get; set; }

        [Required]
        public CatalogBrand Catalog { get; set; }

        [Required]
        public int AvailableStocks { get; set; }


        public int RestockThreshold { get; set; }

        public int MaxStockThreshold { get; set; }

    }
}
