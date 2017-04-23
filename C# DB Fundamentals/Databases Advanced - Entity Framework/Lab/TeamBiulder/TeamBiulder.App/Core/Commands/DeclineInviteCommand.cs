using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class DeclineInviteCommand
    {
        public string Execute(string[] inputArgs)
        {
            // DeclineInvite <teamName>
            Check.CheckLength(1, inputArgs);
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];
            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsInviteExisting(teamName, currentUser))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }

            this.DeclineInvite(teamName, currentUser);

            return $"Invite from {teamName} declined.";
        }

        private void DeclineInvite(string teamName, User currrenUser)
        {
            using (var context = new TeamBiulderContext())
            {
                context.Users.Attach(currrenUser);
                context.Invitations
                    .FirstOrDefault(
                    i => i.Team.Name == teamName && 
                    i.InvitedUserId == currrenUser.Id && 
                    i.IsActive).IsActive = false;
                context.SaveChanges();
            }
        }
    }
}
