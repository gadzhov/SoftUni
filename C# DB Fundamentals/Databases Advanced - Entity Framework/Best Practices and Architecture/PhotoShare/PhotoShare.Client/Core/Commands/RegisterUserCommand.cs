using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System.Linq;
    using System;

    public class RegisterUserCommand
    {
        private UserService _userService;
        public RegisterUserCommand(UserService userService)
        {
            this._userService = userService;
        }
        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            var username = data[0];
            var password = data[1];
            var repeatPassword = data[2];
            var email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }
            if (this._userService.IsExistingByUserName(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            this._userService.Add(username, password, email);
            return "User " + username + " was registered successfully!";

        }
    }
}
