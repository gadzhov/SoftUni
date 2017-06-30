using System;

namespace Problem_5.Date_Modifier
{
    class Startup
    {
        static void Main(string[] args)
        {
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();

            var dateMod = new DateModifier();
            dateMod.CalculateDeference(date1, date2);
            Console.WriteLine(dateMod.Deference);
        }
    }
}
