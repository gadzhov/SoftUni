using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Performance.Data;

namespace Performance
{
    class Startup
    {
        static void Main(string[] args)
        {
            PerformanceContext context = new PerformanceContext();
            Stopwatch stopwatch = new Stopwatch();
            long timePassed = 0L;
            int testCount = 10; // Amount of tests to perform
            for (int i = 0; i < testCount; i++)
            {
                // Clear all query cache
                context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
                stopwatch.Start();

                //var emp = context.Employees.Any(u => u.FirstName == "Bob");
                //QueryWithEagerLoading(context);
                //QueryWithLazyLoading(context);

                var employees = context.Employees
                    .ToList()
                    .Where(e => e.Subordinates.Any(s => s.Address.Town.Name.StartsWith("B")))
                    .Distinct()
                    .Select(e => e.FirstName);

                foreach (var e in employees)
                {
                    string result = $"{e}";
                }



                stopwatch.Stop();
                timePassed += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TimeSpan averageTimePassed = TimeSpan.FromMilliseconds(timePassed / (double)testCount);
            Console.WriteLine(averageTimePassed);
        }

        private static void QueryWithEagerLoading(PerformanceContext context)
        {
            List<Employee> employees = context.Employees.Include("Department").Include("Address").ToList();

            foreach (var employee in employees)
            {
                var result = $"{employee.FirstName} - {employee.Department.Name} - {employee.Address.AddressText}";
            }
        }

        private static void QueryWithLazyLoading(PerformanceContext context)
        {
            var employees = context.Employees.Select(e =>
                new
                {
                    Name = e.FirstName,
                    DepartmentName = e.Department.Name,
                    Address = e.Address.AddressText
                }).ToList();

            foreach (var employee in employees)
            {
                var result = $"{employee.Name} - {employee.DepartmentName} - {employee.Address}";
            }
        }
    }
}
