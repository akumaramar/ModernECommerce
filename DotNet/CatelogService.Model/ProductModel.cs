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

    }
}
