using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class DisbandTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            // Disband<teamName>
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, AuthenticationManager.GetCurrentUser()))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            this.DisbandTeam(teamName);
            return $"{teamName} has disbanded!";
        }

        private void DisbandTeam(string teamName)
        {
            using (var context = new TeamBiulderContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                context.Teams.Remove(team);
                context.SaveChanges();
            }
        }
    }
}
