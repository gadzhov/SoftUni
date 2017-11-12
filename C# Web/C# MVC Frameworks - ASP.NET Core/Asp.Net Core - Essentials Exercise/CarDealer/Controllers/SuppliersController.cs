namespace CarDealer.Controllers
{
    using Data;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using System;

    [Route("Suppliers")]
    public class SuppliersController : Controller
    {
        private const string ModiefiedTable = "Supplier";

        private readonly CarDealerDbContext context;

        public SuppliersController(CarDealerDbContext context)
        {
            this.context = context;
        }

        [Route("{filter}")]
        public IActionResult Info(string filter)
        {
            using (this.context)
            {
                IEnumerable<Supplier> suppliers = null;

                if (filter == "local")
                {
                    suppliers = this.context
                    .Suppliers
                    .Include(s => s.Parts)
                    .Where(s => !s.IsImporter)
                    .ToList();
                }
                else if (filter == "importers")
                {
                    suppliers = this.context
                        .Suppliers
                        .Include(s => s.Parts)
                        .Where(s => s.IsImporter)
                        .ToList();
                }

                if (suppliers == null)
                {
                    return new RedirectResult("/");
                }

                return View(suppliers);
            }
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            using (this.context)
            {
                IEnumerable<Supplier> suppliers = this.context
                    .Suppliers
                    .ToList();

                return View(suppliers);
            }
        }

        [HttpGet]
        [Route("Add")]
        [Authorize]
        public IActionResult Add() => View();

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public IActionResult Add(Supplier s)
        {
            using (this.context)
            {
                Supplier supplier = new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                };

                Logger logger = new Logger
                {
                    ModifiedTable = ModiefiedTable,
                    User = User.Identity.Name,
                    Operation = "Add",
                    Time = DateTime.Now
                };

                this.context.Loggers.Add(logger);
                this.context.Suppliers.Add(supplier);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Add));
            }
        }

        [Route("Edit")]
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            using (this.context)
            {
                Supplier supplier = this.context.Suppliers.FirstOrDefault(s => s.Id == id);

                if (supplier == null)
                {
                    return Redirect("/");
                }

                return View(supplier);
            }
        }

        [Route("Edit")]
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Supplier s)
        {
            using (this.context)
            {
                Supplier supplier = this.context.Suppliers.Find(s.Id);

                if (supplier == null)
                {
                    return Redirect("/");
                }

                supplier.Name = s.Name;
                supplier.IsImporter = s.IsImporter;

                Logger logger = new Logger
                {
                    ModifiedTable = ModiefiedTable,
                    User = User.Identity.Name,
                    Operation = "Edit",
                    Time = DateTime.Now
                };

                this.context.Loggers.Add(logger);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("Delete")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            using (this.context)
            {
                Supplier supplier = this.context.Suppliers.Find(id);

                return View(supplier);
            }
        }

        [HttpPost]
        [Route("Delete")]
        [Authorize]
        public IActionResult Delete([Bind("Id")] Supplier supplier)
        {
            using (this.context)
            {
                Logger logger = new Logger
                {
                    ModifiedTable = ModiefiedTable,
                    User = User.Identity.Name,
                    Operation = "Delete",
                    Time = DateTime.Now
                };

                this.context.Loggers.Add(logger);
                this.context.Suppliers.Remove(supplier);
                this.context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}