using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSpeedUnits
{
    class ConvertSpeedUnits
    {
        static void Main(string[] args)
        {
            float distanceM = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float time = 60f * hours + minutes + seconds / 60f;
            float speedMS = distanceM / (float)time / 60.0f;
            float speedKmH = (distanceM / 1000f) / (time / 60f);
            float speedMhH = speedKmH / 1.609f;

            Console.WriteLine($"{speedMS:0.########}");
            Console.WriteLine($"{speedKmH:0.########}");
            Console.WriteLine($"{speedMhH:0.########}");
        }
    }
}
