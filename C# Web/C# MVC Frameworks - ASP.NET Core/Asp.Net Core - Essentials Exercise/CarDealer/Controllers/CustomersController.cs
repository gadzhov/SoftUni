namespace CarDealer.Controllers
{
    using CarDealer.Data;
    using Microsoft.AspNetCore.Mvc;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models.ViewModels;
    using Microsoft.AspNetCore.Authorization;

    [Route("Customers")]
    public class CustomersController : Controller
    {
        private const string ModiefiedTable = "Customer";

        private readonly CarDealerDbContext context;

        public CustomersController(CarDealerDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize]
        [Route("Add")]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        [Route("Add")]
        public IActionResult Add([Bind("Name,BirthDate")] Customer c)
        {
            using (this.context)
            {
                if (ModelState.IsValid)
                {
                    int currentYear = DateTime.Now.Year;
                    int customerLicenseRegistration = c.BirthDate.Year + 18;

                    Customer customer = new Customer
                    {
                        Name = c.Name,
                        BirthDate = c.BirthDate,
                        IsYoungDriver = (currentYear - customerLicenseRegistration) < 2
                    };

                    Logger logger = new Logger
                    {
                        ModifiedTable = ModiefiedTable,
                        User = User.Identity.Name,
                        Operation = "Add",
                        Time = DateTime.Now
                    };

                    this.context.Loggers.Add(logger);
                    this.context.Customers.Add(customer);
                    this.context.SaveChanges();

                    return RedirectToAction(nameof(All), new { sortingMethod = "ascending" });
                }

                return View(c);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            using (this.context)
            {
                Customer customer = this.context
                    .Customers
                    .Find(id);

                if (customer == null)
                {
                    return Redirect("/");
                }

                return View(customer);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Edit/{id}")]
        public IActionResult Edit([Bind("Id, Name, BirthDate")] Customer c)
        {
            using (this.context)
            {
                if (ModelState.IsValid)
                {
                    Customer customer = this.context
                        .Customers
                        .Find(c.Id);

                    customer.Name = c.Name;
                    customer.BirthDate = c.BirthDate;

                    Logger logger = new Logger
                    {
                        ModifiedTable = ModiefiedTable,
                        User = User.Identity.Name,
                        Operation = "Edit",
                        Time = DateTime.Now
                    };

                    this.context.Loggers.Add(logger);

                    this.context.SaveChanges();

                    return RedirectToAction(nameof(All), new { sortingMethod = "ascending" });
                }

                return View(c);
            }
        }

        [HttpGet]
        [Route("All/{sortingMethod}")]
        public IActionResult All(string sortingMethod)
        {
            IEnumerable<Customer> customers = this.context
            .Customers
            .ToList();

            if (sortingMethod == "ascending")
            {
                customers = customers
                    .OrderBy(c => c.BirthDate)
                    .ThenByDescending(c => c.IsYoungDriver);

            }
            else if (sortingMethod == "descending")
            {
                customers = customers
                    .OrderByDescending(c => c.BirthDate)
                    .ThenByDescending(c => c.IsYoungDriver);
            }
            else
            {
                return NotFound();
            }


            return View(customers);
        }

        [Route("Sales/{id}")]
        public IActionResult Sales(int id)
        {
            using (this.context)
            {
                CustomerViewModel customer = this.context
                    .Customers
                    .Include(c => c.Sales)
                    .ThenInclude(s => s.Car)
                    .Where(c => c.Id == id)
                    .Select(c => new CustomerViewModel
                    {
                        Name = c.Name,
                        BoughtCarsCount = c.Sales.Count,
                        TotalSpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                    })
                    .FirstOrDefault();

                return View(customer);
            }
        }
    }
}
