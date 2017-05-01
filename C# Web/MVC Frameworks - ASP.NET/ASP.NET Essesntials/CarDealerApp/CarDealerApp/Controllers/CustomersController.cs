using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealerApp.Controllers
{
    public class CustomersController : Controller
    {
        [HttpGet]
        public ActionResult All(string order)
        {
            var ctx = new CarDealerContext();
            IEnumerable<Customer> customers = null;

            if (order == "ascending")
            {
                customers = ctx.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver == false)
                    .ToList();
            }
            else if (order == "descending")
            {
                customers = ctx.Customers
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver == false)
                    .ToList();
            }

            return View(customers);
        }

        [HttpGet]
        public ActionResult About(int id)
        {
            var ctx = new CarDealerContext();
            var custommer = ctx.Customers.Find(id);

            return View(custommer);
        }
    }
}
