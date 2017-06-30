using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6.Company_Roster
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                // Mandatory information
                var employee = new Employee()
                {
                    Name = inputArgs[0],
                    Salary = decimal.Parse(inputArgs[1]),
                    Position = inputArgs[2],
                    Department = inputArgs[3]
                };
                // Optional information
                if (inputArgs.Length > 4 && inputArgs.Length < 7)
                {
                    if (inputArgs.Length == 5 && inputArgs[4].Contains("@"))
                    {
                        employee.Email = inputArgs[4];
                    }
                    else if (inputArgs.Length == 5)
                    {
                        employee.Age = int.Parse(inputArgs[4]);
                    }
                    else
                    {
                        employee.Email = inputArgs[4];
                        employee.Age = int.Parse(inputArgs[5]);
                    }
                }

                employees.Add(employee);
            }

            var grouped = employees
                .GroupBy(e => e.Department)
                .Select(e => new
                {
                    Department = e.Key,
                    AverageSalary = e.Average(emp => emp.Salary),
                    Employee = e.OrderByDescending(emp => emp.Salary)
                })
                .ToList()
                .OrderByDescending(x => x.AverageSalary)
                .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {grouped.Department}");
            foreach (var employee in grouped.Employee)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
            }
        }
    }
}
