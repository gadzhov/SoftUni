using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Create_User.Models;

namespace Create_User
{
    class Startup
    {
        static void Main(string[] args)
        {
            try
            {
                var context = new UserContext();
                //context.Database.Initialize(true);
                var u2 = new User()
                {
                    Username = "Iv",
                    Password = "dD2!dwawda",
                    Age = 27,
                    Email = "dwada@wda.com",
                    LastTimeLoggedIn = DateTime.Now,
                    RegisteredOn = DateTime.Now,
                    IsDeleted = false
                };
                context.Users.Add(u2);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine(
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                throw;
            }

            // 11. Get Users by Email Privider
            var provider = Console.ReadLine();
            GetUsers(provider);
            // 12. Remove Inactive Users
            var date = DateTime.Parse(Console.ReadLine());
            IsDeleted(date);
        }

        public static void GetUsers(string provider)
        {
            var context = new UserContext();
            var users = context.Users.Where(u => u.Email.EndsWith(provider)).ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} {user.Email}");
            }
        }

        public static void IsDeleted(DateTime date)
        {
            var context = new UserContext();
            var users = context.Users.Where(u => u.LastTimeLoggedIn > date).ToList();
            foreach (var user in users)
            {
                context.Users.Remove(user);
            }
        }
    }
}
