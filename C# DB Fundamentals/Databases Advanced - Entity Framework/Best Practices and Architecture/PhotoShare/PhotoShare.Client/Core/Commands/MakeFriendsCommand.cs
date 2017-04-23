using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class MakeFriendsCommand
    {
        private readonly UserService _userService;

        public MakeFriendsCommand(UserService userService)
        {
            this._userService = userService;
        }
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            var firstName = data[0];
            var secondName = data[1];

            if (!this._userService.IsExistingByUserName(firstName))
            {
                throw new ArgumentException($"{firstName} not found!");
            }
            else if (!this._userService.IsExistingByUserName(secondName))
            {
                throw new ArgumentException($"{secondName} not found!");
            }

            var secondUser = this._userService.GetUserByUserName(secondName);

            if (this._userService.AreTheyFriends(firstName, secondUser))
            {
                throw new ArgumentException($"{secondName} is already a friend to {firstName}");
            }

            this._userService.MakeFriends(firstName, secondUser);

            return $"Friend {secondName} added to {firstName}";
        }
    }
}
