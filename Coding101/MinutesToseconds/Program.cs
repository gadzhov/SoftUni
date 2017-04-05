using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CenturiesToMinutes
    {
        static void Main(string[] args)
        {
            Console.Write("Centures = ");
            int centures = int.Parse(Console.ReadLine());
            int years = centures * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{centures} centuries = {years} years = {days} days = {hours} = {minutes} minutes");
        }
    }
}
