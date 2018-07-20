using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    public class OrderItemEntity: EntityBase
    {
        public Guid ProductID { get; set; }

        public int ProductQuantity { get; set; }

        public Double ProductPrice { get; set; }

    }
}
