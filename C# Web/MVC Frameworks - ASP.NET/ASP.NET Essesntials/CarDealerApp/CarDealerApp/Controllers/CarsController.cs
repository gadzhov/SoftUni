using System;
using System.Linq;
using System.Web.Mvc;
using CarDealer.Data;

namespace CarDealerApp.Controllers
{
    public class CarsController : Controller
    {
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