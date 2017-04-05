using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentutiesToNanoseconds
{
    class CentutiesToNanoseconds
    {
        static void Main(string[] args)
        {
            Console.Write("Centures = ");
            ulong centures = ulong.Parse(Console.ReadLine());
            ulong years = centures * 100;
            ulong days = (ulong)(years * 365.2422);
            ulong hours = days * 24;
            ulong minutes = hours * 60;
            ulong seconds = minutes * 60;
            ulong milliseconds = seconds * 1000;
            ulong microseconds = milliseconds * 1000;
            decimal nanoseconds = microseconds * 1000m;

            Console.WriteLine($"{centures} centures = {years} = {days} = {hours} = {minutes} = {seconds} = {milliseconds} = {microseconds} = {nanoseconds}");
        }
    }
}
