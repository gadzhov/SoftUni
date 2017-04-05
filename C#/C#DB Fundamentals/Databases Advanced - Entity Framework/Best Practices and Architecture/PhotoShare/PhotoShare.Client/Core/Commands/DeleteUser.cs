using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class DeleteUser
    {
        private readonly UserService _userService;

        public DeleteUser(UserService userService)
        {
            this._userService = userService;
        }
        public string Execute(string[] data)
        {
            var username = data[0];

            if (!this._userService.IsExistingByUserName(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            else if (this._userService.IsDeleted(username))
            {
                throw new ArgumentException($"User {username} is already deleted!");
            }
            this._userService.Remove(username);

            return $"User {username} was deleted successfully!";
        }
    }
}
