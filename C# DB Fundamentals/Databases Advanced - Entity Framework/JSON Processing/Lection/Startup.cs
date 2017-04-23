using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Lection.Models;
using Newtonsoft.Json;

namespace Lection
{
    class Startup
    {
        static void Main(string[] args)
        {
            //Reference to System.Web.Essentials
            var product = new Product() {Name = "Front Bump", Description = "Seat Leon 1.9 TDI", Cost = 600m};
            var serializer = new JavaScriptSerializer();

            var jsonProduct = serializer.Serialize(product);
            var objProduct = serializer.Deserialize<Product>(jsonProduct);

            var products = new Dictionary<string, Product>()
            {
                {"pump", new Product() {Name = "wdada", Description = "dwadadada", Cost = 231m} },
                {"filter", new Product() {Name = "wdaaaaa", Description = "dwa", Cost = 32m} }
            };

            var jsonProducts = serializer.Serialize(products);
            var objProducts = serializer.Deserialize<Dictionary<string, Product>>(jsonProducts);

            //Json.NET
            var jsonProduct2 = JsonConvert.SerializeObject(product, Formatting.Indented);
            var objProduct2 = JsonConvert.DeserializeObject<Product>(jsonProduct2);
            Console.WriteLine(jsonProduct2);
        }
    }
}
