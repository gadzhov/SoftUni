namespace CarDealer.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using Models.BindingModels;
    using System.Linq;
    using System.Collections.Generic;
    using System;
    using Microsoft.AspNetCore.Authorization;

    public class PartsController : Controller
    {
        private const string ModiefiedTable = "Part";

        private readonly CarDealerDbContext context;

        public PartsController(CarDealerDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            using (this.context)
            {
                IEnumerable<Part> parts = this.context
                    .Parts
                    .ToList();

                return View(parts);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            using (this.context)
            {
                ViewBag.Suppliers = new SelectList(this.context
                    .Suppliers
                    .Select(s => s.Name)
                    .ToList());
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(PartBindingModel p)
        {
            using (this.context)
            {
                if (ModelState.IsValid)
                {
                    int supplierid = this.context
                        .Suppliers
                        .FirstOrDefault(s => s.Name == p.Supplier)
                        .Id;

                    Part part = new Part
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Quantity = p.Quantity == null ? 1 : p.Quantity,
                        SupplierId = supplierid
                    };

                    Logger logger = new Logger
                    {
                        ModifiedTable = ModiefiedTable,
                        User = User.Identity.Name,
                        Operation = "Add",
                        Time = DateTime.Now
                    };

                    this.context.Loggers.Add(logger);
                    this.context.Parts.Add(part);
                    this.context.SaveChanges();

                    return RedirectToAction(nameof(All));
                }

                return View(p);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            using (this.context)
            {
                Part part = this.context.Parts.Find(id);

                return View(part);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Delete(Part p)
        {
            using (this.context)
            {
                Part part = this.context.Parts.Find(p.Id);
                this.context.Parts.Remove(part);

                Logger logger = new Logger
                {
                    ModifiedTable = ModiefiedTable,
                    User = User.Identity.Name,
                    Operation = "Delete",
                    Time = DateTime.Now
                };

                this.context.Loggers.Add(logger);
                this.context.SaveChanges();

                return RedirectToAction(nameof(All));
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            using (this.context)
            {
                Part part = this.context.Parts.Find(id);

                return View(part);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Part p)
        {
            using (this.context)
            {
                Part part = this.context.Parts.Find(p.Id);

                part.Price = p.Price;
                part.Quantity = p.Quantity;

                Logger logger = new Logger
                {
                    ModifiedTable = ModiefiedTable,
                    User = User.Identity.Name,
                    Operation = "Edit",
                    Time = DateTime.Now
                };

                this.context.Loggers.Add(logger);
                context.SaveChanges();

                return RedirectToAction(nameof(All));
            }
        }
    }
}
