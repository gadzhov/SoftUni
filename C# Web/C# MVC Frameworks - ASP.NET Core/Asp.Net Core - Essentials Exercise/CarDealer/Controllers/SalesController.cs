namespace CarDealer.Controllers
{
    using Data;
    using Models;
    using Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using CarDealer.Models.BindingModels;
    using Microsoft.AspNetCore.Authorization;
    using System;

    [Route("Sales")]
    public class SalesController : Controller
    {
        private const string ModiefiedTable = "Sale";

        private readonly CarDealerDbContext context;

        public SalesController(CarDealerDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult All()
        {
            using (this.context)
            {
                IEnumerable<Sale> sales = this.context
                    .Sales
                    .ToList();

                return View(sales);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            using (this.context)
            {
                SaleDetailsView sale = this.context
                    .Sales
                    .Include(s => s.Car)
                    .Include(s => s.Customer)
                    .Where(s => s.Id == id)
                    .Select(s => new SaleDetailsView
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        CustomerName = s.Customer.Name
                    })
                    .FirstOrDefault();

                return View(sale);
            }
        }

        [HttpGet]
        [Route("discounted")]
        public IActionResult Discounted()
        {
            IEnumerable<SaleDetailsView> sales = this.context
                .Sales
                .Include(s => s.Car)
                .Include(s => s.Customer)
                .Where(s => s.Discount != 0.0)
                .Select(s => new SaleDetailsView
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount
                })
                .ToList();

            return View(sales);
        }

        [HttpGet]
        [Route("discounted/{percent}")]
        public IActionResult DiscountedByPercent(double percent)
        {
            using (this.context)
            {
                IEnumerable<Sale> sales = this.context
                    .Sales
                    .Include(s => s.Car)
                    .Include(s => s.Customer)
                    .Where(s => s.Discount == percent)
                    .ToList();

                if (!sales.Any())
                {
                    return Redirect("/");
                }

                IEnumerable<SaleDetailsView> discountedSales = sales
                    .Select(s => new SaleDetailsView
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount
                    });

                return View(discountedSales);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("add")]
        public IActionResult Add()
        {
            using (this.context)
            {
                ViewBag.Customers = new SelectList(this.context
                    .Customers
                    .Select(c => c.Name)
                    .ToList());

                ViewBag.Cars = this.context
                    .Cars
                    .Select(c => new
                    {
                        Id = c.Id,
                        Car = $"{c.Make} {c.Model}"
                    })
                    .ToList();

                ViewBag.Discounts = new SelectList(new List<double> { 0.0, 0.1, 0.2, 0.3, 0.4, 0.5 });

                return View();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("Add")]
        public IActionResult Add(SaleBindingModel s)
        {
            using (this.context)
            {
                if (ModelState.IsValid)
                {
                    Car car = this.context
                        .Cars
                        .Include(c => c.PartCars)
                        .ThenInclude(p => p.Part)
                        .FirstOrDefault(c => c.Id == s.CarId);

                    SaleReviewViewModel sale = new SaleReviewViewModel
                    {
                        Customer = s.Customer,
                        Car = $"{car.Make} {car.Model}",
                        Discount = s.Discount,
                        CarPrice = car.PartCars.Sum(pc => pc.Part.Price),
                        CarId = car.Id
                    };

                    ViewBag.IsYoungDriver = this.context.Customers.FirstOrDefault(c => c.Name == s.Customer).IsYoungDriver ? "(+5%)" : "";

                    return View(nameof(Review), sale);
                }

                ViewBag.Customers = new SelectList(this.context
                    .Customers
                    .Select(c => c.Name)
                    .ToList());

                ViewBag.Cars = this.context
                    .Cars
                    .Select(c => new
                    {
                        Id = c.Id,
                        Car = $"{c.Make} {c.Model}"
                    })
                    .ToList();

                ViewBag.Discounts = new SelectList(new List<double> {0.0, 0.1, 0.2, 0.3, 0.4, 0.5 });

                ModelState.AddModelError(string.Empty, "All fields are required.");

                return View(s);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("Review")]
        public IActionResult Review(SaleReviewViewModel s) => View(s);

        [HttpPost]
        [Authorize]
        [Route("Review")]
        public IActionResult Review(SaleBindingModel s)
        {
            using (this.context)
            {
                if (ModelState.IsValid)
                {
                    Sale sale = new Sale
                    {
                        CarId = s.CarId,
                        CustomerId = this.context.Customers.FirstOrDefault(c => c.Name == s.Customer).Id,
                        Discount = s.Discount / 100
                    };

                    Logger logger = new Logger
                    {
                        ModifiedTable = ModiefiedTable,
                        User = User.Identity.Name,
                        Operation = "Add",
                        Time = DateTime.Now
                    };

                    this.context.Loggers.Add(logger);
                    this.context.Sales.Add(sale);
                    this.context.SaveChanges();

                    return RedirectToAction(nameof(All));
                }

                return NotFound();
            }
        }
    }
}
