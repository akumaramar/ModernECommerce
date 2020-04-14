using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        //Place for extra functions here
    }
}
