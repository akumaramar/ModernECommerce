using ModernECommerce.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    public class OrderEntity : EntityBase
    {

        public List<OrderItemEntity> OrderItems { get; set; }

        public OrderEntity()
        {
            OrderItems = new List<OrderItemEntity>();
        }

        public void AddOrderItem(Guid productID, int productQunatity, double productPrice)
        {
            // Add Order items
            OrderItems.Add(new OrderItemEntity { ProductID = productID, ProductQuantity = productQunatity, ProductPrice = productPrice });
        }
    }
}
