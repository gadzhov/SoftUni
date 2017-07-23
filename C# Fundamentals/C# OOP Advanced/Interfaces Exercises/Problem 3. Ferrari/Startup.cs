using System;
using Problem_3.Ferrari.Entities.Interfaces;

namespace Problem_3.Ferrari
{
    public class Startup
    {
        public static void Main()
        {
            var ferrariName = typeof(Entities.Ferrari).Name;
            var iCarInterfaceName = typeof(ICar).Name;

            var isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

            var driverName = Console.ReadLine();
            var ferrari = new Entities.Ferrari(driverName);
            Console.WriteLine(ferrari);
        }
    }
}
