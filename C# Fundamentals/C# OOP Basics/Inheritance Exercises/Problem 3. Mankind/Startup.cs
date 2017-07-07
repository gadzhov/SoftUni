using System;
using Problem_3.Mankind.Models;

namespace Problem_3.Mankind
{
    class Startup
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine();
                var humanArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var firstName = humanArgs[0];
                var lastName = humanArgs[1];
                var facilityNumber = humanArgs[2];

                var student = new Student(firstName, lastName, facilityNumber);

                input = Console.ReadLine();
                humanArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                firstName = humanArgs[0];
                lastName = humanArgs[1];
                var salary = decimal.Parse(humanArgs[2]);
                var workingHours = decimal.Parse(humanArgs[3]);

                var worker = new Worker(firstName, lastName, salary, workingHours);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
