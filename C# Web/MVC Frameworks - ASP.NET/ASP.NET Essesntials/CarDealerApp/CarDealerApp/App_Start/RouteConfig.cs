using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Discount sale",
                url: "sales/discounted/{percent}",
                defaults: new { controller = "Sales", action = "Discount", percent = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Detail of a sale",
                url: "sales/{id}",
                defaults: new { controller = "Sales", action = "Details" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "List of all sales",
                url: "sales/",
                defaults: new { controller = "Sales", action = "All" }
            );

            routes.MapRoute(
                name: "Total sales by customer",
                url: "customers/{id}",
                defaults: new { controller = "Customers", action = "About" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Car with its list of parts",
                url: "cars/{id}/parts",
                defaults: new { controller = "Cars", action = "About" },
                constraints: new { id = @"\d+" }
            );

            routes.MapRoute(
                name: "Filter suppliers",
                url: "suppliers/{type}",
                defaults: new { controller = "Suppliers", action = "All" }
            );

            routes.MapRoute(
                name: "Cars from make",
                url: "cars/{make}",
                defaults: new { controller = "Cars", action = "All" }
            );

            routes.MapRoute(
                name: "Customers ordered",
                url: "customers/all/{order}/",
                defaults: new { controller = "Customers", action = "All", order = "ascending" },
                constraints: new { order = @"ascending|descending" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
