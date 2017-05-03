using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealerApp.Controllers
{
    public class PartsController : Controller
    {
        private CarDealerContext ctx = new CarDealerContext();

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var part = ctx.Parts.Find(id);

            return View(part);
        }

        [HttpPost]
        public ActionResult Edit(Part part)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(part).State = EntityState.Modified;
                ctx.SaveChanges();

                return RedirectToAction("All");
            }

            return View(part);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var part = ctx.Parts.Find(id);
            return View(part);
        }

        [HttpPost]
        public ActionResult Delete(Part part)
        {
            if (ModelState.IsValid) 
            {
                ctx.Entry(part).State = EntityState.Deleted;
                ctx.SaveChanges();

                return RedirectToAction("All");
            }

            return View(part);
        }

        [HttpGet]
        public ActionResult All()
        {
            var parts = ctx.Parts.ToList();
            return View(parts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "Name,Price,Quantity")] Part part)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(part).State = EntityState.Added;
                ctx.SaveChanges();

                return RedirectToAction("All", "Parts");
            }

            return View(part);
        }
    }
}
