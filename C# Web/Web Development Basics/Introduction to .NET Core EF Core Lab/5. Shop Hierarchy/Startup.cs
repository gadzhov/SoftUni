namespace _5._Shop_Hierarchy
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using _5._Shop_Hierarchy.Data;
    using _5._Shop_Hierarchy.Models;

    public class Startup
    {
        public static void Main()
        {
            using (Entity dbContext = new Entity())
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                AddSalesmenData(dbContext);
                AddItemData(dbContext);

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    string command = cmdArgs[0];

                    string[] dataArgs = cmdArgs[1].Split(new[] { ';' });

                    switch (command)
                    {
                        case "register":
                            RegisterCommand(dbContext, dataArgs);
                            break;
                        case "order":
                            OrderCommand(dbContext, dataArgs);
                            break;
                        case "review":
                            ReviewCommand(dbContext, dataArgs);
                            break;
                        default:
                            break;
                    }
                }

                //List<Salesmen> salesmens = dbContext.Salesmens
                //    .OrderByDescending(s => s.Customers.Count)
                //    .ThenBy(s => s.Name)
                //    .ToList();
                //foreach (var salesmen in salesmens)
                //{
                //    Console.WriteLine(salesmen);
                //}

                //dbContext
                //    .Customers
                //    .Include(c => c.Orders)
                //    .Include(c => c.Reviews)
                //    .OrderByDescending(c => c.Orders.Count)
                //    .ThenByDescending(c => c.Reviews.Count)
                //    .ToList()
                //    .ForEach(Console.WriteLine);

                //int customerIdToPrintAbout = int.Parse(Console.ReadLine());
                //Customer customer = dbContext
                //    .Customers
                //    .Include(c => c.Orders)
                //    .ThenInclude(c => c.Items)
                //    .Include(c => c.Reviews)
                //    .ToList()
                //    .FirstOrDefault(c => c.Id == customerIdToPrintAbout);

                //Console.WriteLine(customer);

                //int id = int.Parse(Console.ReadLine());
                //var customer = dbContext.Customers.Single(x => x.Id == id);

                //dbContext.Entry(customer)
                //    .Collection(b => b.Orders).Load();

                //int ordersCount = customer.Orders.Count;

                //dbContext.Entry(customer)
                //    .Collection(c => c.Reviews).Load();

                //dbContext.Entry(customer)
                //    .Reference(c => c.Salesmen).Load();

                int id = int.Parse(Console.ReadLine());

                var customer = dbContext.Customers
                    .FirstOrDefault(x => x.Id == id);

                int ordersCount = dbContext.Entry(customer)
                    .Collection(b => b.Orders)
                    .Query()
                    .Count(o => o.Items.Count > 1);

                Console.WriteLine($"Orders count: {ordersCount}");
            }
        }

        private static void AddItemData(Entity dbContext)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] itemsArgs = input
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string itemName = itemsArgs[0];
                decimal itemPrice = decimal.Parse(itemsArgs[1]);

                Item item = new Item { Name = itemName, Price = itemPrice };

                dbContext.Items.Add(item);
            }
            dbContext.SaveChanges();

        }

        private static void AddSalesmenData(Entity dbContext)
        {
            string[] salesMenArgs = Console.ReadLine()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in salesMenArgs)
            {
                Salesmen salesman = new Salesmen { Name = name };
                dbContext.Salesmens.Add(salesman);
            }
            dbContext.SaveChanges();
        }

        private static void ReviewCommand(Entity dbContext, string[] dataArgs)
        {
            int customerId = int.Parse(dataArgs[0]);
            int itemId = int.Parse(dataArgs[1]);
            Review review = new Review();
            Item item = dbContext.Items.Find(itemId);
            item.Reviews.Add(review);
            Customer customer = dbContext.Customers.Find(customerId);
            customer.Reviews.Add(review);

            dbContext.SaveChanges();
        }

        private static void OrderCommand(Entity dbContext, string[] dataArgs)
        {
            int customerId = int.Parse(dataArgs[0]);
            string[] itemsArgs = dataArgs.Skip(1).ToArray();

            Order order = new Order();

            foreach (string ia in itemsArgs)
            {
                int itemId = int.Parse(ia);
                Item item = dbContext
                    .Items
                    .Find(itemId);
                ItemsOrders itemsOrders = new ItemsOrders() { Item = item, Order = order };
                order.Items.Add(itemsOrders);
            }


            dbContext.Customers.Find(customerId).Orders.Add(order);

            dbContext.SaveChanges();
        }

        private static void RegisterCommand(Entity dbContext, string[] cmdArgs)
        {
            string customerName = cmdArgs[0];
            int salesmenId = int.Parse(cmdArgs[1]);

            Customer customer = new Customer { Name = customerName, SalesmenId = salesmenId };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
    }
}
