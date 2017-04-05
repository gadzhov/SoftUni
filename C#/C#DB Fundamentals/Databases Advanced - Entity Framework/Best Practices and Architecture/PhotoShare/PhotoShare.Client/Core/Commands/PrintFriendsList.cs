using System.Linq;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class PrintFriendsListCommand
    {
        private readonly UserService _userService;

        public PrintFriendsListCommand(UserService userService)
        {
            this._userService = userService;
        }
        // PrintFriendsList <username>
        public void Execute(string[] data)
        {
            var username = data[0];

            if (!this._userService.IsExistingByUserName(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            var user = _userService.GetUserByUserName(username);
            var friendList = this._userService.GetUserFriendList(user);

            if (friendList.Count == 0)
            {
                Console.WriteLine("No friends for this user. :(");
                
            }
            Console.WriteLine("Friends:");
            var result = "";
            foreach (var friend in friendList)
            {
                Console.WriteLine($"-{friend.Username}");
            }
        }
    }
}
