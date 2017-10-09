namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Models;
    using Infrastructure;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Linq;
    using Controllers.Repositories.Contracts;
    using MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories;
    using MyCoolWebServer.Database.Data;
    using MyCoolWebServer.Database.Models;
    using Server.Http;

    public class ShoppingController : Controller
    {
        private readonly CakesData cakesData;
        private IUserRepository uRepository;
        private ICakeRepository cRepository;
        private IOrderRepository oRepository;

        public ShoppingController()
        {
            this.cakesData = new CakesData();
            this.uRepository = new UserRepository(new CakeContext());
            this.cRepository = new CakeRepository(new CakeContext());
            this.oRepository = new OrderRepository(new CakeContext());
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            Product cake = this.cRepository.Find(id);

            if (cake == null)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            shoppingCart.Orders.Add(cake);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(i => $"<div>{i.Name} - ${i.Price:F2}</div><br />");

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(i => i.Price);
                
                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            List<Product> orders = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders;
            string currentUserName = req.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.uRepository.Get(currentUserName);
            Order newOrder = new Order
            {
                AuthorId = user.Id,
                DateOfCreation = DateTime.UtcNow
            };

            foreach (var ord in orders)
            {
                newOrder.Products.Add(new OrderProduct
                {
                    ProductId = ord.Id,
                });

                this.oRepository.Add(newOrder);
            }

            this.oRepository.Save();

            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();

            return this.FileViewResponse(@"shopping\finish-order");
        }
    }
}
