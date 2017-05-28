using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Legendary_Farming
{
    class Startup
    {
        static void Main(string[] args)
        {
            // {quantity} {material} {quantity} {material} … {quantity} {material}
            // 3 Motes 5 stones 5 Shards

            var rareElem = new SortedDictionary<string, int>();
            var junkElem = new SortedDictionary<string, int>();
            var loop = true;

            while (loop)
            {
                var inputArray = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < inputArray.Length; i += 2)
                {
                    var quantity = int.Parse(inputArray[i]);
                    var material = inputArray[i + 1].ToLower();

                    if (material != "shards" && material != "fragments" && material != "motes")
                    {
                        if (!junkElem.ContainsKey(material))
                        {
                            junkElem.Add(material, quantity);
                        }
                        else
                        {
                            junkElem[material] += quantity;
                        }
                    }
                    else
                    {
                        if (!rareElem.ContainsKey(material))
                        {
                            rareElem.Add(material, quantity);
                            if (rareElem[material] >= 250)
                            {
                                loop = false;
                                break;
                            }
                        }
                        else
                        {
                            rareElem[material] += quantity;
                            if (rareElem[material] >= 250)
                            {
                                loop = false;
                                break;
                            }
                        }
                    }
                }
            }

            var legendary = rareElem.FirstOrDefault(e => e.Value >= 250).Key;
            switch (legendary)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    rareElem["shards"] -= 250;
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    rareElem["fragments"] -= 250;
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    rareElem["motes"] -= 250;
                    break;
            }

            if (!rareElem.ContainsKey("shards"))
            {
                rareElem.Add("shards", 0);
            }
            if (!rareElem.ContainsKey("fragments"))
            {
                rareElem.Add("fragments", 0);
            }
            if (!rareElem.ContainsKey("motes"))
            {
                rareElem.Add("motes", 0);
            }

            foreach (var ele in rareElem.OrderByDescending(e => e.Value).ThenBy(e => e.Key))
            {
                Console.WriteLine($"{ele.Key}: {ele.Value}");
            }
            foreach (var ele in junkElem)
            {
                Console.WriteLine($"{ele.Key}: {ele.Value}");
            }
        }
    }
}
