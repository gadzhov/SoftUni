using System;
using System.Linq;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{

    public class AddTownCommand
    {
        private readonly TownService _townService;

        public AddTownCommand(TownService townService)
        {
            this._townService = townService;
        }
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            var townName = data[0];
            var country = data[1];

            if (this._townService.IsTownExisting(townName))
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }

            this._townService.AddTown(townName, country);
            return townName + " was added to database!";
        }
    }
}
