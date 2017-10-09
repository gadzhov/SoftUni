namespace MyCoolWebServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Infrastructure;
    using Models;
    using MyCoolWebServer.ByTheCakeApplication.Controllers.Repositories;
    using MyCoolWebServer.Database.Data;
    using Repositories.Contracts;
    using MyCoolWebServer.Database.Models;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class AccountController : Controller
    {
        private IUserRepository uRepository;
        private IOrderRepository oRepository;

        public AccountController()
        {
            this.uRepository = new UserRepository(new CakeContext());
            this.oRepository = new OrderRepository(new CakeContext());
        }

        // Unit testing
        public AccountController(IUserRepository uRepository)
        {
            this.uRepository = uRepository;
        }

        public IHttpResponse Register()
        {
            this.ViewData["error"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            const string formFullName = "username";
            const string formPassword = "password";
            const string formConfirmPassword = "confirmPassword";

            if (!req.FormData.ContainsKey(formFullName)
                || !req.FormData.ContainsKey(formPassword)
                || !req.FormData.ContainsKey(formConfirmPassword))
            {
                return new BadRequestResponse();
            }

            string userName = req.FormData[formFullName];
            string password = req.FormData[formPassword];
            string confirmPassword = req.FormData[formConfirmPassword];

            if (password != confirmPassword)
            {
                this.ViewData["error"] = "block";
                return this.FileViewResponse(@"account\register");
            }

            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] sha256Data = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
            string hasedPassword = Encoding.ASCII.GetString(sha256Data);

            User user = new User
            {
                Username = userName,
                Password = hasedPassword,
                DateOfRegistration = DateTime.UtcNow
            };

            //TODO: Check if username is not taken
            this.uRepository.Add(user);
            this.uRepository.Save();

            req.Session.Add(SessionStore.CurrentUserKey, user.Username);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";
            this.ViewData["redirectToLogin"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formPasswordKey))
            {
                return new BadRequestResponse();
            }

            string name = req.FormData[formNameKey];
            string password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";

                return this.FileViewResponse(@"account\login");
            }

            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] sha256Data = sha256.ComputeHash(Encoding.ASCII.GetBytes(password));
            string hasedPassword = Encoding.ASCII.GetString(sha256Data);

            User user = this.uRepository.Get(name);

            if (user == null || user.Password != hasedPassword)
            {
                this.ViewData["redirectToLogin"] = "block";
                this.ViewData["showError"] = "none";
                this.ViewData["authDisplay"] = "none";
                
                return this.FileViewResponse(@"account\login");
            }


            req.Session.Add(SessionStore.CurrentUserKey, name);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            string currentUserName = req.Session.Get(SessionStore.CurrentUserKey).ToString();

            if (currentUserName == null)
            {
                return new BadRequestResponse();
            }

            User currentUser = this.uRepository.Get(currentUserName);

            if (currentUser == null)
            {
                return new BadRequestResponse();
            }

            this.ViewData["nameInfo"] = currentUser.Username;
            this.ViewData["registeredInfo"] = currentUser.DateOfRegistration.ToShortDateString();
            this.ViewData["ordersCountInfo"] = currentUser.Orders.Count.ToString();

            return this.FileViewResponse(@"account\profile");
        }

        public IHttpResponse Orders(IHttpRequest req)
        {
            this.ViewData["tableData"] = "";

            string currentUserName = req.Session.Get<string>(SessionStore.CurrentUserKey);

            User user = this.uRepository.Get(currentUserName);

            if (user == null || currentUserName == null)
            {
                return new BadRequestResponse();
            }

            if (user.Orders.Any())
            {
                IEnumerable<string> ordersTd = user
                    .Orders
                    .Select(o =>
                        $@"<tr><td><a href=""/orderDetails/{o.Id}"">{o.Id}</a></td><td>{o.DateOfCreation}</td><td>{o.Products.Sum(p => p.Product.Price)}</td></tr>");

                string tableData = string.Join(Environment.NewLine, ordersTd);

                this.ViewData["tableData"] = tableData;
            }
            
            return this.FileViewResponse(@"account\orders");
        }

        public IHttpResponse OrderDetails(IHttpRequest req)
        {
            int orderId = int.Parse(req.UrlParameters["id"]);
            Order order = this.oRepository
                .Find(orderId);

            IEnumerable<string> ordersTd = order
                .Products
                .Select(p => $@"<tr><td><a href=""/cakeDetails/{p.ProductId}"">{p.Product.Name}</a></td><td>{p.Product.Price}</td></tr>");

            string tableData = string.Join(Environment.NewLine, ordersTd);

            this.ViewData["orderId"] = order.Id.ToString();
            this.ViewData["tableData"] = tableData;
            this.ViewData["orderDate"] = order.DateOfCreation.ToShortDateString();

            return this.FileViewResponse(@"account\order-detail");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }
    }
}
