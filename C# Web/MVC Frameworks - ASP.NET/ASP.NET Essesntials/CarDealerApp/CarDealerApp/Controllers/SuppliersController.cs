using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealerApp.Controllers
{
    public class SuppliersController : Controller
    {
        [HttpGet]
        public ActionResult All(string type)
        {
            var ctx = new CarDealerContext();
            IEnumerable<Supplier> suppliers = null;


            if (type.ToLower() == "local")
            {
                suppliers = ctx.Suppliers
                    .Where(s => s.IsImporter)
                    .ToList();
            }
            else if (type.ToLower() == "importers")
            {
                suppliers = ctx.Suppliers
                    .Where(s => s.IsImporter == false)
                    .ToList();
            }

            if (suppliers == null)
            {
                throw new ArgumentException("Invalid input data!");
            }

            return View(suppliers);
        }
    }
}