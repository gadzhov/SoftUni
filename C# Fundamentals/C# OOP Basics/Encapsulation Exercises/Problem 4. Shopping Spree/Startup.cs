using System;
using System.Collections.Generic;
using System.Linq;
using Problem_4.Shopping_Spree.Models;

namespace Problem_4.Shopping_Spree
{
    class Startup
    {
        static void Main(string[] args)
        {
            try
            {
                var people = new List<Person>();
                var products = new List<Product>();
                var peopleInfo = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var productsInfo = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                // Add all people to Collection
                foreach (var person in peopleInfo)
                {
                    var pInfo = person.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var pName = pInfo[0];
                    var pMoney = decimal.Parse(pInfo[1]);

                    people.Add(new Person(pName, pMoney));

                }
                // Add all products to Collection
                foreach (var product in productsInfo)
                {
                    var pInfo = product.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    var pName = pInfo[0];
                    var pCost = decimal.Parse(pInfo[1]);

                    products.Add(new Product(pName, pCost));
                }

                if (people.Count > 0)
                {
                    string input;
                    while ((input = Console.ReadLine()) != "END")
                    {
                        var inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var personName = inputArgs[0];
                        var productName = inputArgs[1];

                        var person = people.FirstOrDefault(p => p.Name == personName);
                        var product = products.FirstOrDefault(p => p.Name == productName);

                        try
                        {
                            person.BuyProduct(product);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    foreach (var person in people)
                    {
                        Console.Write($"{person.Name} - ");
                        Console.Write(person.Products.Count > 0 ? string.Join(", ", person.Products.Select(p => p.Name)) : "Nothing bought");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
