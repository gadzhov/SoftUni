using System;
using Problem_4.Telephony.Entities;

namespace Problem_4.Telephony
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' });
            var urls = Console.ReadLine().Split(new[] { ' ' });

            var phone = new Smartphone(numbers, urls);

            Console.Write(phone.ToString());
        }
    }
}
