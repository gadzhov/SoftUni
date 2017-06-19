using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Office_Stuff
{
    class Startup
    {
        static void Main()
        {
            // storage
            var companyOrders = new SortedDictionary<string, Dictionary<string, int>>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                // order input
                var order = Console.ReadLine().Split(new char[] { '|', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                FillDictionary(order, companyOrders);
            }

            // print
            Print(companyOrders);
        }

        private static void Print(SortedDictionary<string, Dictionary<string, int>> companyOrders)
        {
            // this list prepares the results for final formating
            var result = new List<string>();

            foreach (var pair1 in companyOrders)
            {
                Console.Write("{0}: ", pair1.Key);

                result.AddRange(pair1.Value.Select(pair2 => $"{pair2.Key}-{pair2.Value}"));
                Console.WriteLine(string.Join(", ", result));
                result.Clear();
            }
        }

        private static void FillDictionary(string[] order, SortedDictionary<string, Dictionary<string, int>> companyOrders)
        {
            var company = order[0];
            var product = order[2];
            var amount = int.Parse(order[1]);

            // storing the order details into the dictionary 
            if (!companyOrders.ContainsKey(company))
            {
                var products = new Dictionary<string, int> {{product, 0}};

                companyOrders.Add(company, products);
            }
            else if (!companyOrders[company].ContainsKey(product))
            {
                companyOrders[company].Add(product, 0);
            }
            companyOrders[company][product] += amount;
        }
    }
}
