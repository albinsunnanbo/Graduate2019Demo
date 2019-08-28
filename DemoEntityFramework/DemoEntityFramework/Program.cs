using DemoEntityFramework.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DemoDbContext())
            {
                Init(ctx);
                //SeedOrders(ctx);

                //var orders2 = ctx.Orders
                //    .Where(o => o.Quantity > 5)
                //    .Select(o => new
                //    {
                //        o.Quantity,
                //        ProductName = o.Product.Name,
                //        CustomerName = o.Customer.Name,
                //    });

                var orders =
                    from o in ctx.Orders
                    where o.Quantity > 5
                    where o.Product.Name.Length > 4
                    where o.Customer.Orders.Count() == 3
                    select new
                    {
                        o.Quantity,
                        ProductName = o.Product.Name,
                        CustomerName = o.Customer.Name,
                    };


                foreach (var o in orders)
                {
                    Console.WriteLine($"{o.CustomerName} / {o.ProductName}: {o.Quantity}");
                }

                ctx.SaveChanges();
            }

            Console.WriteLine("done");
            Console.ReadKey();
        }

        private static void SeedOrders(DemoDbContext ctx)
        {
            var c = ctx.Customers.First();
            var p = ctx.Products.First();
            for (int i = 1; i < 10; i++)
            {
                var order = new Order
                {
                    Customer = c,
                    Product = p,
                    Quantity = i,
                };

                ctx.Orders.Add(order);
            }
        }

        private static void Init(DemoDbContext ctx)
        {
            int customerCount = ctx.Customers.Count();
            if (customerCount == 0)
            {
                ctx.Customers.Add(new Customer
                {
                    Name = "Kalle",
                });

                ctx.SaveChanges();
            }

            int productCount = ctx.Products.Count();
            if (productCount == 0)
            {
                ctx.Products.Add(new Product
                {
                    Name = "Ferarri",
                });

                ctx.SaveChanges();
            }
        }
    }
}
