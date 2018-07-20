using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModernECommerce.Common.Dto
{
    public class DtoBase
    {
        [Key]
        public Guid ID { get; set; }

    }
}
