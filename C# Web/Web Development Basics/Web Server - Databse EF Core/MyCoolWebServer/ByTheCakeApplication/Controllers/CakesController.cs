namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using Data;
    using Infrastructure;
    using Models;
    using Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories;
    using MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories.Contracts;
    using MyCoolWebServer.Database.Data;
    using MyCoolWebServer.Database.Models;

    public class CakesController : Controller
    {
        private ICakeRepository repository;
        private readonly CakesData cakesData;

        public CakesController()
        {
            this.cakesData = new CakesData();
            this.repository = new CakeRepository(new CakeContext());
        }

        // Unit testing
        public CakesController(ICakeRepository repository)
        {
            this.repository = repository;
        }

        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Add(string name, string price, string pictureUrl)
        {
            this.repository.Add(name, decimal.Parse(price), pictureUrl);
            this.repository.Save();
            
            //this.cakesData.Add(name, price);

            this.ViewData["name"] = name;
            this.ViewData["price"] = price;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData["searchTerm"] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                //this.ViewData["searchTerm"] = searchTerm;

                //var savedCakesDivs = this.cakesData
                //    .All()
                //    .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
                //    .Select(c => $@"<div>{c.Name} - ${c.Price:F2} <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a></div>");

                IEnumerable<Product> cakes = this.repository.Search(searchTerm);
                IEnumerable<string> cakesDivs = cakes
                    .Select(c => $@"<div><a href=""cakeDetails/{c.Id}"">{c.Name}</a> - ${c.Price:F2} <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}""><button>Order</button></a></div>")
                    .ToList();

                var results = "No cakes found";

                if (cakesDivs.Any())
                {
                    results = string.Join(Environment.NewLine, cakesDivs);
                }

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return this.FileViewResponse(@"cakes\search");
        }

        public IHttpResponse Details(IHttpRequest req)
        {
            int id = int.Parse(req.UrlParameters["id"]);

            Product cake = this.repository.Find(id);

            this.ViewData["cakeNameInfo"] = cake.Name;
            this.ViewData["cakePriceInfo"] = cake.Price.ToString();
            this.ViewData["imageUrlInfo"] = cake.ImageUrl;

            return this.FileViewResponse(@"cakes/details");
        }
    }
}
