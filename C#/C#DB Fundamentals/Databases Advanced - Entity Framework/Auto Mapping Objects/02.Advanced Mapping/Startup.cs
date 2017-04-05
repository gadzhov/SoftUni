using System;
using System.Collections.Generic;
using AutoMapper;
using _02.Advanced_Mapping.Models;

namespace _02.Advanced_Mapping
{
    class Startup
    {
        static void Main()
        {
            ConfigureAutoMapping();
            var managers = Seed();
            var managerDtos = Mapper.Map<List<Employee>>(managers);
            foreach (var managerDto in managerDtos)
            {
                Console.WriteLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.Subordinates.Count}");
                foreach (var sb in managerDto.Subordinates)
                {
                    Console.WriteLine($"   - {sb.FirstName} {sb.LastName} {sb.Salary:F2}");
                }
            }
        }

        private static void ConfigureAutoMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(dt0 => dt0.Count, configExpression => configExpression.MapFrom(e => e.Subordinates.Count));
            });
        }

        private static List<Employee> Seed()
        {
            var managers = new List<Employee>();
            for (int i = 0; i < 3; i++)
            {
                var manager = new Employee()
                {
                    Salary = 1200m,
                    FirstName = "Galq",
                    LastName = "Ivanova",
                    Birthday = new DateTime(1990, 06, 28),
                    Address = "Burgas",
                    IsOnHoliday = true,
                    Subordinates = new List<Employee>(),
                    Manager = new Employee() {FirstName = "Ivan", LastName = "Ivanov"}

                };
                var employee1 = new Employee()
                {
                    Salary = 1200m,
                    FirstName = "Petar",
                    Birthday = new DateTime(1990, 06, 28),
                    LastName = "Petrov",
                    Address = "Burgas",
                    IsOnHoliday = false,
                    Manager = manager
                };
                var employee2 = new Employee()
                {
                    Salary = 1200m,
                    FirstName = "Nataliq",
                    Birthday = new DateTime(1990, 06, 28),
                    LastName = "Arangelova",
                    Address = "Burgas",
                    IsOnHoliday = false,
                    Manager = manager
                };
                var employee3 = new Employee()
                {
                    Salary = 1200m,
                    FirstName = "Dimitar",
                    Birthday = new DateTime(1990, 06, 28),
                    LastName = "Ivanov",
                    Address = "Burgas",
                    IsOnHoliday = true,
                    Manager = manager
                };
                manager.Subordinates.Add(employee1);
                manager.Subordinates.Add(employee2);
                manager.Subordinates.Add(employee3);
                managers.Add(manager);
            }

            return managers;
        }
    }
}
