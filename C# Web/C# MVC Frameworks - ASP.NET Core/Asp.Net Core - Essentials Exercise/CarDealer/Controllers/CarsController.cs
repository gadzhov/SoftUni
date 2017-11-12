namespace CarDealer.Controllers
{
    using Data;
    using Models;
    using Models.ViewModels;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using CarDealer.Models.BindingModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using System;

    [Route("Cars")]
    public class CarsController : Controller
    {
        private const string ModiefiedTable = "Car";

        private readonly CarDealerDbContext context;

        public CarsController(CarDealerDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("{make}")]
        public IActionResult Index(string make)
        {
            using (context)
            {
                IEnumerable<Car> cars = this.context
                    .Cars
                    .Where(c => c.Make == make)
                    .ToList();

                if (cars.Any())
                {
                    cars = cars
                        .OrderBy(c => c.Model)
                        .ThenByDescending(c => c.TravelledDistance);
                    ViewData["Title"] = make;

                    return View(cars);
                }

                return NotFound();
            }

        }

        [HttpGet]
        [Route("Add")]
        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Authorize]
        [Route("Add")]
        public IActionResult Add(CarBindingModel c)
        {
            using (this.context)
            {
                if (!ModelState.IsValid)
                {
                    return View(c);
                }

                Car car = new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                };

                Logger logger = new Logger
                {
                    ModifiedTable = ModiefiedTable,
                    User = User.Identity.Name,
                    Operation = "Add",
                    Time = DateTime.Now
                };

                this.context.Loggers.Add(logger);
                this.context.Cars.Add(car);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index), new { make = car.Make });
            }
        }

        [HttpGet]
        [Route("{id}/parts")]
        public IActionResult Parts(int id)
        {
            using (this.context)
            {
                Car car = this.context
                    .Cars
                    .Include(c => c.PartCars)
                    .ThenInclude(pc => pc.Part)
                    .FirstOrDefault(c => c.Id == id);

                
                if (car == null)
                {
                    return Redirect("/");
                }

                CarPartsViewModel carPartsViewModel = new CarPartsViewModel
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance,
                    Parts = car.PartCars.Select(p => new PartViewModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                };


                return View(carPartsViewModel);    
            }
        }
    }
}