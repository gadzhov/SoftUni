using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class LoginCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            var username = inputArgs[0];
            var password = inputArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            var user = this.getUserByCredentials(username, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return $"User {user.UserName} successfully logged in!";
        }

        private User getUserByCredentials(string username, string password)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Users
                    .FirstOrDefault(u => u.UserName == username && u.Password == password && !u.IsDeleted);
            }
        }
    }
}
