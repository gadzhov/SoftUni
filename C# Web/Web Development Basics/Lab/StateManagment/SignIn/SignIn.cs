using System;
using System.Collections.Generic;
using System.Linq;
using PizzaMore.Data;
using PizzaMore.Utilities;

namespace SignIn
{
    class SignIn
    {
        public static IDictionary<string, string> RequestParameters;
        public static Header Header = new Header();

        static void Main(string[] args)
        {
            if (WebUtil.IsPost())
            {
                LogIn();
            }

            ShowPage();
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent("../htdocs/pm/signin.html");
        }

        private static void LogIn()
        {
            RequestParameters = WebUtil.RetrievePostParameters();
            var email = RequestParameters["email"];
            var passwordd = RequestParameters["password"];
            var hashedPassword = PasswordHasher.Hash(RequestParameters["password"]);
            using (var ctx = new PizzaMoreContext())
            {
                var user = ctx.Users.SingleOrDefault(u => u.Email == email);
                if (hashedPassword == user.Password)
                {
                    var session = new Session()
                    {
                        Id = new Random().Next().ToString(),
                        User = user
                    };

                    if (user != null)
                    {
                        Header.AddCookie(new Cookie("sid", session.Id));
                    }
                    ctx.Sessions.Add(session);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
