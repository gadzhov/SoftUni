using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Population_Counter
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Sofia|Bulgaria|1000000
            // report

            var input = Console.ReadLine();
            var populationCounter = new SortedDictionary<string, SortedDictionary<string, long>>();

            while (input != "report")
            {
                var splitedData = input.Split('|');
                var city = splitedData[0];
                var country = splitedData[1];
                var population = int.Parse(splitedData[2]);

                if (!populationCounter.ContainsKey(country))
                {
                    populationCounter.Add(country, new SortedDictionary<string, long>());
                    populationCounter[country].Add(city, population);
                }
                else
                {
                    if (!populationCounter[country].ContainsKey(city))
                    {
                        populationCounter[country].Add(city, population);
                    }
                }


                input = Console.ReadLine();
            }

            foreach (var cntr in populationCounter.OrderByDescending(ord => ord.Value.Values.Sum()))
            {
                Console.WriteLine($"{cntr.Key} (total population: {cntr.Value.Values.Sum()})");
                foreach (var ct in cntr.Value.OrderByDescending(ord => ord.Value))
                {
                    Console.WriteLine($"=>{ct.Key}: {ct.Value}");
                }
            }
        }
    }
}
