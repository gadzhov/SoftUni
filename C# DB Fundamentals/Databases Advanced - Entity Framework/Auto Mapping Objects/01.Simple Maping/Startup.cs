using System;
using AutoMapper;
using _01.Simple_Maping.Models;

namespace _01.Simple_Maping
{
    class Startup
    {
        static void Main(string[] args)
        {
            ConfigureAutoMapping();
            var employee = new Employee()
            {
                Address = "Sofia Mladost 4",
                Birthday = new DateTime(1990,04,25),
                FirstName = "Pamela",
                LastName = "Andonova",
                Salary = 3456.25m
            };

            var employeeDto = Mapper.Map<EmployeeDto>(employee);
        }

        private static void ConfigureAutoMapping()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
        }
    }
}
