using System;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class AcceptInviteCommand
    {
        public string Execute(string[] inputArgs)
        {
            // AcceptInvite <teamName>
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsInviteExisting(teamName, currentUser))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }

            this.AcceptInvite(teamName);

            return $"User {currentUser.UserName} joined team {teamName}!";
        }

        private void AcceptInvite(string teamName)
        {
            using (var context = new TeamBiulderContext())
            {
                var currentUser = AuthenticationManager.GetCurrentUser();
                var team = context.Teams.FirstOrDefault(t => t.Name == teamName);

                context.Users.Attach(currentUser);
                currentUser.Teams.Add(team);

                var invitation = context.Invitations
                    .FirstOrDefault(i => i.TeamId == team.Id && i.InvitedUserId == currentUser.Id && i.IsActive);
                invitation.IsActive = false;

                context.SaveChanges();
            }
        }
    }
}
