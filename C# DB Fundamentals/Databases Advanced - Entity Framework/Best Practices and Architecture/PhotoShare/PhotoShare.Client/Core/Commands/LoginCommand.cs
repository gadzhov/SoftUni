using System;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginCommand
    {
        private readonly UserService _userService;

        public LoginCommand(UserService userService)
        {
            this._userService = userService;
        }
        public string Execute(string[] data)
        {
            var username = data[0];
            var password = data[1];

            if (this._userService.IsLoggedIn(username))
            {
                throw new ArgumentException("You should logout first!");
            }
            if (this._userService.LoginHandler(username, password))
            {
                throw new ArgumentException("Invalid username or password!");
            }
            else
            {
                Console.WriteLine($"User {username} successfully logged in!");
            }

            return username;
        }
    }
}
