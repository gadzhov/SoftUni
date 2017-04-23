using System;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class CreateTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            // CreateTeam <name> <acronym> <description>
            if (inputArgs.Length != 2 && inputArgs.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(inputArgs));
            }
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];
            if (teamName.Length > Constants.MaxTeamNameLenght)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNameNotValid, teamName));
            }

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            var acronym = inputArgs[1];

            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            var description = inputArgs.Length == 3 ? inputArgs[2] : null;

            this.AddTeam(teamName, acronym, description);


            return $"Team {teamName} successfully created!";
        }

        private void AddTeam(string teamName, string acronym, string description)
        {
            using (var context = new TeamBiulderContext())
            {
                var team = new Team()
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                };

                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
    }
}
