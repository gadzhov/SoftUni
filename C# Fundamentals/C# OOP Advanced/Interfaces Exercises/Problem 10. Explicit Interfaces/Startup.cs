using System;
using Problem_10.Explicit_Interfaces.Interfaces;
using Problem_10.Explicit_Interfaces.Models;

namespace Problem_10.Explicit_Interfaces
{
    public class Startup
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArgs = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = cmdArgs[0];
                var country = cmdArgs[1];
                var age = int.Parse(cmdArgs[2]);

                var citizen = new Citizen(name, country, age);
                IPerson iPerson = citizen;
                IResident iResident = citizen;

                Console.WriteLine(iPerson.GetName());
                Console.WriteLine(iResident.GetName());
            }
        }
    }
}
