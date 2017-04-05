using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Projection.Models;
using Projection.Models.dtos;

namespace Projection
{
    class Startup
    {
        static void Main(string[] args)
        {
            ConfigurationAutoMapper();
            var context = new EmployeeContext();

            //context.Database.Initialize(true);
            //var employeeList = context.Employees.Where(e => e.Birthday.Value.Year < 1990).OrderByDescending(e => e.Salary).ToList();
            //var employeeDto = Mapper.Map<List<EmployeeDto>>(employeeList);

            var employeeDto = context.Employees
                .Where(e => e.Birthday.Value.Year < 1990)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeDto>();
            foreach (var dto in employeeDto)
            {
                var managerLastName = dto.ManagersLastName;
                if (managerLastName == null)
                {
                    managerLastName = "[no manager]";
                }
                Console.WriteLine($"{dto.FirstName} {dto.LastName} {dto.Salary:f2} - Manager: {managerLastName}");
            }
        }

        private static void ConfigurationAutoMapper()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>()
            .ForMember(dto => dto.ManagersLastName, option => option.MapFrom(source => source.Manager.LastName)));
        }
    }
}
