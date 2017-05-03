using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ctx = new CarDealerContext();
            var customer = ctx.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var ctx = new CarDealerContext();
                ctx.Entry(customer).State = EntityState.Modified;
                ctx.SaveChanges();

                return RedirectToAction("All");
            }

            return View(customer);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "Name,BirthDate")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var context = new CarDealerContext();
                // Min years to have driving license is 18 + 5 years to not be young driver
                customer.IsYoungDriver = DateTime.Now.Year - customer.BirthDate.Year <= 23;
                context.Entry(customer).State = EntityState.Added;
                context.SaveChanges();

                return RedirectToAction("All");
            }

            return View(customer);
        }
    }
}
