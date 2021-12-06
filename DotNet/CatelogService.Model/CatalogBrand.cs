using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Model
{
    public class CatalogBrand : EntityBase
    {
        [Required]
        [StringLength(300)]
        public String BrandName { get; set; }

        public String BrandDescription { get; set; }
    }
}
