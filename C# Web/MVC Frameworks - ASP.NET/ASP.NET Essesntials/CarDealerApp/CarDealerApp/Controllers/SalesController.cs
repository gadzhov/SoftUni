using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealerApp.Controllers
{
    public class SalesController : Controller
    {
        [HttpGet]
        public ActionResult All()
        {
            var ctx = new CarDealerContext();
            var sales = ctx.Sales.ToList();

            return View(sales);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ctx = new CarDealerContext();
            var sale = ctx.Sales.Find(id);

            return View(sale);
        }

        [HttpGet]
        public ActionResult Discount(double? percent)
        {
            percent /= 100;
            var ctx = new CarDealerContext();
           IEnumerable<Sale> result = null;
            if (percent == null)
            {
                result = ctx.Sales.Where(s => s.Discount > 0.0).ToList();

                return View(result);
            }

            result = ctx.Sales.Where(s => s.Discount == percent.Value);

            return View(result);
        }
    }
}