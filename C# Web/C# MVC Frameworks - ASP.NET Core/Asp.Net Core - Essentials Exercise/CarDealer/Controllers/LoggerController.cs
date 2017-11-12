namespace CarDealer.Controllers
{
    using CarDealer.Data;
    using CarDealer.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("Logger")]
    public class LoggerController : Controller
    {
        private readonly CarDealerDbContext context;

        public LoggerController(CarDealerDbContext context)
        {
            this.context = context;
        }

        [Route("All")]
        public IActionResult Index(string search, int page)
        {
            using (this.context)
            {
                IEnumerable<Logger> AllLoggers = this.context.Loggers.ToList();
                IEnumerable<Logger> loggers = null;


                if (search != null)
                {
                    loggers = AllLoggers.Where(l => l.User.ToLower().Contains(search.ToLower()));
                    ViewBag.PaginationSize = loggers.Count() / 5;
                    loggers = loggers.Skip(page * 5).Take(5).ToList();
                }
                else
                {
                    loggers = AllLoggers.Skip(page * 5).Take(5).ToList();
                    double pagination = AllLoggers.Count() / 5.0;
                    ViewBag.PaginationSize = Math.Ceiling(pagination);
                }

                ViewBag.CurrentPage = page;

                return View(loggers);
            }
        }

        [Authorize]
        [Route("Clear")]
        [HttpGet]
        public IActionResult Clear()
        {
            using (this.context)
            {
                this.context.Database.ExecuteSqlCommand("TRUNCATE TABLE [LOGGERS]");

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
