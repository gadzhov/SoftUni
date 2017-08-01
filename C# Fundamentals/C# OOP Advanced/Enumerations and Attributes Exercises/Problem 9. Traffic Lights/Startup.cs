using System;
using System.Collections.Generic;
using Problem_9.Traffic_Lights.Interfaces;
using Problem_9.Traffic_Lights.Models.Enums;

namespace Problem_9.Traffic_Lights
{
    public class Startup
    {
        public static void Main()
        {
            var initialLights = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var trafficLights = new List<ITrafficLight>();

            foreach (var light in initialLights)
            {
                trafficLights.Add(new TrafficLight(light));
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                trafficLights.ForEach(l => l.Cycle());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
