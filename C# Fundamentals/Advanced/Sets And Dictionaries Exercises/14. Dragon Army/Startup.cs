using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Dragon_Army
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dragonsDict = new Dictionary<string, Dictionary<string, double[]>>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var type = input[0];
                var name = input[1];
                var damage = input[2] != "null" ? double.Parse(input[2]) : 45;
                var health = input[3] != "null" ? double.Parse(input[3]) : 250;
                var armor = input[4] != "null" ? double.Parse(input[4]) : 10;

                var stats = new double[] { damage, health, armor };

                if (!dragonsDict.ContainsKey(type))
                {
                    dragonsDict.Add(type, new Dictionary<string, double[]>());
                    dragonsDict[type].Add(name, stats);
                    continue;
                }
                if (dragonsDict[type].ContainsKey(name))
                {
                    dragonsDict[type][name] = stats;
                    continue;
                }
                dragonsDict[type].Add(name, stats);
            }

            foreach (var dragon in dragonsDict)
            {
                var averageDamage = 0.0;
                var averageHealth = 0.0;
                var averageArmor = 0.0;
                foreach (var stat in dragon.Value.Values)
                {
                    averageDamage += stat[0];
                    averageHealth += stat[1];
                    averageArmor += stat[2];
                }
                averageDamage /= dragon.Value.Values.Count;
                averageHealth /= dragon.Value.Values.Count;
                averageArmor /= dragon.Value.Values.Count;
                Console.WriteLine($"{dragon.Key}::({averageDamage:f2}/{averageHealth:F2}/{averageArmor:f2})");

                foreach (var arr in dragon.Value.OrderBy(d => d.Key))
                {
                    Console.WriteLine($"-{arr.Key} -> damage: {arr.Value[0]}, health: {arr.Value[1]}, armor: {arr.Value[2]}");
                }
            }
        }
    }
}
