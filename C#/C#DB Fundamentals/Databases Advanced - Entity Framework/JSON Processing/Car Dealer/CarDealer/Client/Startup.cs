using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Data;
using Models;
using Newtonsoft.Json;

namespace Client
{
    class Startup
    {
        static void Main()
        {
            var context = new CarDealerContext();
            //Seed(context);
            //OrderedCustomers(context);
            //CarsFromMakeToyota(context);
            //LocalSuppliers(context);
            //CarsWithTheirListOfParts(context);
            //TotalSalesByCustomer(context);
            //SalesWithAppliedDiscount(context);
        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(c => new
                {
                    car = new
                    {
                        c.Car.Make,
                        c.Car.Model,
                        c.Car.TravelledDistance
                    },
                    customerName = c.Customer.Name,
                    c.Discount,
                    price = c.Car.Parts.Sum(p => p.Price),
                    priceWithDiscount = (double)c.Car.Parts.Sum(p => p.Price) - (c.Discount * (double) c.Car.Parts.Sum(p => p.Price))
                });
            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                });
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    Car = new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    },
                    Parts =
                    c.Parts.Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                });
            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Supliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                });
            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void CarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();
            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void OrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.IsYoungDriver,
                    Sales = "[]"
                })
                .ToList();
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            Console.WriteLine(json);
        }
        private static void Seed(CarDealerContext context)
        {
            SuppliersSeed(context);
            PartsSeed(context);
            CarsSeed(context);
            CustomersSeed(context);
            SalesSeed(context);
        }

        private static void SalesSeed(CarDealerContext context)
        {
            var rnd = new Random();
            var discount = new double[8] {0.0, 0.5, 0.10, 0.15, 0.20, 0.30, 0.40, 0.50};
            for (int i = 0; i < 200; i++)
            {
                var sale = new Sale()
                {
                    CarId = context.Cars.Find(rnd.Next(1, context.Cars.Count() + 1)).Id,
                    CustomerId = context.Customers.Find(rnd.Next(1, context.Customers.Count() + 1)).Id,
                    Discount = discount[rnd.Next(0, discount.Length)]
                };
                context.Sales.Add(sale);
            }
            context.SaveChanges();
        }

        private static void CustomersSeed(CarDealerContext context)
        {
            var json = File.ReadAllText("../../../Import/customers.json");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            foreach (var customer in customers)
            {
                context.Customers.AddOrUpdate(c => c.Name, customer);
            }
            context.SaveChanges();
        }

        private static void CarsSeed(CarDealerContext context)
        {
            var json = File.ReadAllText("../../../Import/cars.json");
            var cars = JsonConvert.DeserializeObject<List<Car>>(json);
            var rnd = new Random();
            foreach (var car in cars)
            {
                var randomCountParts = rnd.Next(10, 21);
                for (var i = 0; i < randomCountParts; i++)
                {
                    var randomPart = context.Parts.Find(rnd.Next(1, context.Parts.Count() + 1));
                    car.Parts.Add(randomPart);
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        private static void PartsSeed(CarDealerContext context)
        {
            var json = File.ReadAllText("../../../Import/parts.json");
            var parts = JsonConvert.DeserializeObject<List<Part>>(json);
            var rnd = new Random();
            foreach (var part in parts)
            {
                part.SuplierId = rnd.Next(1, context.Supliers.Count() + 1);
                context.Parts.AddOrUpdate(p => p.Name, part);
            }

            context.SaveChanges();
        }

        private static void SuppliersSeed(CarDealerContext context)
        {
            var json = File.ReadAllText("../../../Import/suppliers.json");
            var suppliers = JsonConvert.DeserializeObject<List<Suplier>>(json);
            foreach (var supplier in suppliers)
            {
                context.Supliers.AddOrUpdate(s => s.Name, supplier);
            }
            context.SaveChanges();
        }
    }
}
