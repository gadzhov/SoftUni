using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CarDealer.App
{
    using System;

    using Data;
    using Models;

    public class Application
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();
            using (context)
            {
                //SeedXmlData(context);
                //Cars(context);
                //CarsFromMakeFerrari(context);
                //LocalSuppliers(context);
                //CarsWithTheirListOfParts(context);
                //TotalSalesByCustomer(context);
                //SalesWithAppliedDiscount(context);
            }
        }

        private static void SalesWithAppliedDiscount(CarDealerContext context)
        {
            using (context)
            {
                var sales = context.Sales
                    .Select(s => new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance,
                        s.Customer.Name,
                        s.Discount,
                        Price = s.Car.Parts.Sum(p => p.Price),
                        PriceWithDiscount = s.Car.Parts.Sum(p => p.Price) - (s.Car.Parts.Sum(p => p.Price) * s.Discount)
                    })
                    .ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("sales", sales.Select(s =>
                    new XElement("sale", 
                        new XElement("car", new XAttribute("make", s.Make), new XAttribute("model", s.Model), new XAttribute("travelled-distance", s.TravelledDistance)),
                        new XElement("customer-name", s.Name),
                        new XElement("discount", s.Discount),
                        new XElement("price", s.Price),
                       new XElement("price-with-discount", s.PriceWithDiscount))));

                xDoc.Add(xEle);
                xDoc.Save("../../Export/sales-with-applied-discount.xml");
            }
        }

        private static void TotalSalesByCustomer(CarDealerContext context)
        {
            using (context)
            {
                var customers = context.Customers
                    .Where(c => c.Sales.Count >= 1)
                    .Select(c => new
                    {
                        c.Name,
                        c.Sales.Count,
                        TotalMoney = c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))
                    })
                    .ToList()
                    .OrderByDescending(item => item.TotalMoney)
                    .ThenByDescending(item => item.Count)
                    .ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("customers", customers.Select(c => 
                    new XElement("customer", new XAttribute("full-name", c.Name), new XAttribute("bought-cars", c.Count), new XAttribute("spent-money", c.TotalMoney))));

                xDoc.Add(xEle);
                xDoc.Save("../../Export/total-sales-by-customer.xml");
            }
        }

        private static void CarsWithTheirListOfParts(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Select(c => new
                    {
                        c.Make,
                        c.Model,
                        c.TravelledDistance,
                        Parts = c.Parts.Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                    })
                    .ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("cars", cars.Select(c =>
                    new XElement("car", new XAttribute("make", c.Make), new XAttribute("model", c.Model), new XAttribute("travelled-distance", c.TravelledDistance), 
                        new XElement("parts",
                        c.Parts.Select(p =>
                            new XElement("part", new XAttribute("name", p.Name), new XAttribute("price", p.Price)))))));

                xDoc.Add(xEle);
                xDoc.Save("../../Export/cars-with-their-list-of-parts");
            }
        }

        private static void LocalSuppliers(CarDealerContext context)
        {
            using (context)
            {
                var suppliers = context.Suppliers
                    .Where(s => s.IsImporter == false)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Parts.Count
                    })
                    .ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("suppliers", suppliers.Select(s =>
                    new XElement("suplier", new XAttribute("id", s.Id), new XAttribute("name", s.Name),
                        new XAttribute("parts-count", s.Count))));

                xDoc.Add(xEle);
                xDoc.Save("../../Export/local-suppliers.xml");
            }
        }

        private static void CarsFromMakeFerrari(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Ferrari")
                    .OrderBy(c => c.Model)
                    .ThenByDescending(c => c.TravelledDistance)
                    .ToList();
                Console.WriteLine();

                var xDoc = new XDocument();
                var xEle = new XElement("cars", cars.Select(c =>
                    new XElement("car", new XAttribute("id", c.Id), new XAttribute("model", c.Model), new XAttribute("travelled-distance", c.TravelledDistance))));

                xDoc.Add(xEle);
                xDoc.Save("../../Export/cars-from-make-ferrari.xml");
            }
        }

        private static void Cars(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Where(c => c.TravelledDistance > 2000000)
                    .OrderBy(c => c.Make)
                    .ThenBy(c => c.Model)
                    .ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("cars", cars.Select(c =>
                    new XElement("car",
                        new XElement("make", c.Make),
                        new XElement("model", c.Model),
                        new XElement("travelled-distance", c.TravelledDistance))));

                xDoc.Add(xEle);
                xDoc.Save("../../Export/cars.xml");
            }
        }

        private static void SeedXmlData(CarDealerContext context)
        {
            using (context)
            {
                SeedSupliers(context);
                SeedParts(context);
                SeedCars(context);
                SeedCustomers(context);
                SeedSales(context);
            }
        }

        private static void SeedSales(CarDealerContext context)
        {
            using (context)
            {
                var discountArray = new decimal[8] { 0.0m, 0.05m, 0.10m, 0.15m, 0.20m, 0.30m, 0.40m, 0.50m };
                var rnd = new Random();
                var carsCount = context.Cars.Count() + 1;
                var customersCount = context.Customers.Count() + 1;
                var newSales = new List<Sale>();

                //Random 300 sales
                for (var i = 0; i < 300; i++)
                {
                    var newSale = new Sale()
                    {
                        CarId = context.Cars.Find(rnd.Next(1, carsCount)).Id,
                        CustomerId = context.Customers.Find(rnd.Next(1, customersCount)).Id,
                        Discount = discountArray[rnd.Next(0, discountArray.Length)]
                    };

                    newSales.Add(newSale);
                }

                context.Sales.AddRange(newSales);
                context.SaveChanges();
            }
        }

        private static void SeedCustomers(CarDealerContext context)
        {
            using (context)
            {
                var xDoc = XDocument.Load("../../Import/customers.xml");
                var customers = xDoc.Root.Elements();
                var newCustomers = new List<Customer>();

                foreach (var customer in customers)
                {
                    var name = customer.Attribute("name").Value;
                    var bithDate = DateTime.Parse(customer.Element("birth-date").Value);
                    var isYoungDriver = bool.Parse(customer.Element("is-young-driver").Value);

                    newCustomers.Add(new Customer()
                    {
                        Name = name,
                        BirthDate = bithDate,
                        IsYoungDriver = isYoungDriver
                    });
                }

                context.Customers.AddRange(newCustomers);
                context.SaveChanges();
            }
        }

        private static void SeedCars(CarDealerContext context)
        {
            using (context)
            {
                var xDoc = XDocument.Load("../../Import/cars.xml");
                var cars = xDoc.Root.Elements();
                var rnd = new Random();
                var newCars = new List<Car>();
                var partsCount = context.Parts.Count() + 1;

                foreach (var car in cars)
                {
                    var make = car.Element("make").Value;
                    var model = car.Element("model").Value;
                    var travelledDistance = long.Parse(car.Element("travelled-distance").Value);

                    var newCar = new Car()
                    {
                        Make = make,
                        Model = model,
                        TravelledDistance = travelledDistance
                    };

                    for (var i = 0; i < rnd.Next(10, 21); i++)
                    {
                        var part = context.Parts.Find(rnd.Next(1, partsCount));
                        newCar.Parts.Add(part);
                    }

                    newCars.Add(newCar);
                }

                context.Cars.AddRange(newCars);
                context.SaveChanges();
            }
        }

        private static void SeedParts(CarDealerContext context)
        {
            using (context)
            {
                var xDoc = XDocument.Load("../../Import/parts.xml");
                var parts = xDoc.Root.Elements();
                var rnd = new Random();
                var suppliersCount = context.Suppliers.Count() + 1;
                var newParts = new List<Part>();

                foreach (var part in parts)
                {
                    var name = part.Attribute("name").Value;
                    var price = decimal.Parse(part.Attribute("price").Value);
                    var quantity = int.Parse(part.Attribute("quantity").Value);

                    newParts.Add(new Part()
                    {
                        Name = name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = rnd.Next(1, suppliersCount)
                    });
                }

                context.Parts.AddRange(newParts);
                context.SaveChanges();
            }
        }

        private static void SeedSupliers(CarDealerContext context)
        {
            using (context)
            {
                var xDoc = XDocument.Load("../../Import/suppliers.xml");
                var suppliers = xDoc.Root.Elements();
                var newSupliers = new List<Supplier>();

                foreach (var supplier in suppliers)
                {
                    var name = supplier.Attribute("name").Value;
                    var isImporter = bool.Parse(supplier.Attribute("is-importer").Value);

                    newSupliers.Add(new Supplier()
                    {
                        Name = name,
                        IsImporter = isImporter
                    });
                }

                context.Suppliers.AddRange(newSupliers);
                context.SaveChanges();
            }
        }
    }
}
