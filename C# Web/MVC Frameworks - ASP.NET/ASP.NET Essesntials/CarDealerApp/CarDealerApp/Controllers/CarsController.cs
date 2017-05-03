using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealerApp.Controllers
{
    public class CarsController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                var ctx = new CarDealerContext();
                ctx.Entry(car).State = EntityState.Added;
                ctx.SaveChanges();

                return RedirectToAction("All", new {make = car.Make});
            }

            return View(car);
        }

        [HttpGet]
        public ActionResult All(string make)
        {
            var ctx = new CarDealerContext();
            var cars = ctx.Cars
                .Where(c => c.Make == make)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();
            if (cars.Count == 0)
            {
                throw new ArgumentException("Invalid input data!");
            }

            return View(cars);
        }

        [HttpGet]
        public ActionResult About(int id)
        {
            var ctx = new CarDealerContext();
            var car = ctx.Cars.Find(id);

            return View(car);
        }
    }
}