using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Data.DTO;

namespace Data.Utilities
{
    public class QueryAndExportData
    {
        public static void ProductsInRange()
        {
            using (var context = new ProductShopContext())
            {
                // With DTO

                List<ProductInRangeDTO> products = context.Products
                    .Where(p => (p.Price >= 500 && p.Price <= 2000) && p.BuyerId != null)
                    .OrderBy(o => o.Price)
                    .Select(s => new { Name = s.Name, Price = s.Price, Seller = s.Seller.FirstName ?? "" + " " + s.Seller.LastName })
                    .ToList()
                    .Select(p => new { p.Name, p.Price, Seller = p.Seller.Trim() })
                    .Select(s => new ProductInRangeDTO { Name = s.Name, Price = s.Price, Seller = s.Seller })
                    .ToList();

                var serializer = new XmlSerializer(products.GetType(), new XmlRootAttribute("products"));

                var writer = new StreamWriter("../../../Data/Export/products-in-range.xml");

                using (writer)
                {
                    serializer.Serialize(writer, products);
                }


                /*
                var products = context.Products
                    .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.Buyer != null)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Buyer = p.Buyer.FirstName == null ? p.Buyer.LastName : string.Concat(p.Buyer.FirstName, " ", p.Buyer.LastName)
                    }).ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("products", products.Select(p => 
                    new XElement("product", new XAttribute("name", p.Name), new XAttribute("price", p.Price), new XAttribute("buyer", p.Buyer))));

                xDoc.Add(xEle);
                xDoc.Save("../../../Data/Export/products-in-range.xml");
                */
            }
        }

        public static void SoldProducts()
        {
            using (var context = new ProductShopContext())
            {
                //List<SellerDTO> users = context.Users
                //    .Where(u => u.ProductsSold.Count >= 1)
                //    .Select(u => new SellerDTO()
                //    {
                //        FirstName = u.FirstName,
                //        LastName = u.LastName,
                //        SoldProducts = u.ProductsSold.Select(p => new SoldProductsDTO()
                //        {
                //            Name = p.Name,
                //            Price = p.Price
                //        }).ToList()
                //    }).ToList();

                //var serializer = new XmlSerializer(users.GetType(), new XmlRootAttribute("users"));
                //var writer = new StreamWriter("../../../Data/Export/sold-products.xml");

                //using (writer)
                //{
                //    serializer.Serialize(writer, users);
                //}

                var users = context.Users
                    .Where(u => u.ProductsSold.Count >= 1)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        SoldProducts = u.ProductsSold.Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    }).ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("users", users.Select(u => 
                    new XElement("user", u.FirstName == null ? null : new XAttribute("first-name", u.FirstName), new XAttribute("last-name", u.LastName), 
                        u.SoldProducts.Select(p => 
                            new XElement("sold-product", new XElement("name", p.Name),
                            new XElement("price", p.Price))))));

                xDoc.Add(xEle);
                xDoc.Save("../../../Data/Export/sold-products.xml");
            }
        }

        public static void CategoriesByProductsCount()
        {
            using (var context = new ProductShopContext())
            {
                //var categories = context.Categories
                //    .OrderByDescending(c => c.Products.Count)
                //    .Select(c => new CategoriesByProductsCountDTO()
                //    {
                //        Name = c.Name,
                //        Count = c.Products.Count,
                //        AveragePrice = c.Products.Average(p => p.Price),
                //        TotalRevenue = c.Products.Sum((p => p.Price))
                //    }).ToList();

                //var serializer = new XmlSerializer(categories.GetType(), new XmlRootAttribute("categories"));
                //var writer = new StreamWriter("../../../Data/Export/categories-by-products-count.xml");
                //using (writer)
                //{
                //    serializer.Serialize(writer, categories);
                //}

                var categories = context.Categories
                    .OrderByDescending(c => c.Products.Count)
                    .Select(c => new
                    {
                        c.Name,
                        Count = c.Products.Count,
                        Average = c.Products.Average(p => p.Price),
                        Total = c.Products.Sum(p => p.Price)
                    }).ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("categories", categories.Select(c => 
                    new XElement("category", new XAttribute("name", c.Name),
                        new XElement("products-count", c.Count),
                        new XElement("average-price", c.Average),
                        new XElement("total-revenue", c.Total))));

                xDoc.Add(xEle);
                xDoc.Save("../../../Data/Export/categories-by-products-count.xml");
            }
        }

        public static void UsersAndProducts()
        {
            using (var context = new ProductShopContext())
            {
                var users = context.Users
                    .Where(u => u.ProductsSold.Count >= 1)
                    .OrderByDescending(u => u.ProductsSold.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                    }).ToList();

                var xDoc = new XDocument();
                var xEle = new XElement("users", new XAttribute("count", users.Count),
                    users.Select(u => new XElement("user", 
                    u.FirstName == null ? null : new XAttribute("first-name", u.FirstName),
                    new XAttribute("last-name", u.LastName),
                    u.Age == null ? null : new XAttribute("age", u.Age),
                    new XElement("sold-products", new XAttribute("count", u.Count),
                    u.Products.Select(p =>
                    new XElement("product", new XAttribute("name", p.Name),
                    new XAttribute("price", p.Price))
                    )))));
                xDoc.Add(xEle);

                xDoc.Save("../../../Data/Export/users-and-products.xml");
            }
        }
    }
}
