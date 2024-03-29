﻿using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogService.Model
{
    public class ProductTypeModel : EntityBase
    {
        [Required]
        [MaxLength(300)]
        public String Name { get; set; }

        public String Description { get; set; }

        public String AdditionalInfo { get; set; }
    }
}
