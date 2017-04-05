using System.Linq;
using PhotoShare.Models;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ModifyUserCommand
    {
        private readonly UserService _userService;
        private readonly TownService _townService;
        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this._userService = userService;
            this._townService = townService;
        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            var userName = data[0];
            var property = data[1];
            var value = data[2];

            var user = this._userService.GetUserByUserName(userName);

            if (user == null)
            {
                throw new ArgumentException();
            }

            switch (property)
            {
                case "Password":
                    user.Password = value;
                    this._userService.UpdateUsersPassword(user);
                    break;
                case "BornTown":
                {
                    var town = this._townService.GetByTownName(value);
                    if (town == null)
                    {
                        throw new ArgumentException($"Town {value} not found!");
                    }
                        this._userService.UpdateUsersBornTown(user, town);
                    }
                    break;
                case "CurrentTown":
                {
                    var town = this._townService.GetByTownName(value);
                    if (town == null)
                    {
                        throw new ArgumentException($"Town {value} not found!");
                    }
                        this._userService.UpdateUsersCurrentTown(user, town);
                    }
                    break;
                default:
                    throw new ArgumentException($"Property {property} not suppoerted!");
            }

            //this._userService.UpdateUser(user);
            return $"User {userName} {property} is {value}.";
        }
    }
}
