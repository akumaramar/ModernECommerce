using DAL;
using DAL.Entity;
using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderEntity order1 = new OrderEntity();
            order1.AddOrderItem(Guid.NewGuid(), 12, 100);

            OrderEntity order2 = new OrderEntity();
            order2.AddOrderItem(Guid.NewGuid(), 21, 200);


            OrderRepository repository = new OrderRepository();
            repository.Configure();
            Task<OrderEntity> added = repository.AddAsync(order1);
            Console.WriteLine("First record Added");

            Task<OrderEntity> second = repository.AddAsync(order2);
            Console.WriteLine("Second record Added");
            added.Wait();
            second.Wait();
            Console.WriteLine("Record Added. Thank you.");
       }
    }
}
