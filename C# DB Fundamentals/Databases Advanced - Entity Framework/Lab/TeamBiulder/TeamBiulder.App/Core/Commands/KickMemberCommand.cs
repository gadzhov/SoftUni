using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class KickMemberCommand
    {
        public string Execute(string[] inputArgs)
        {
            // KickMember <teamName> <username>
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            var userName = inputArgs[1];
            if (!CommandHelper.IsUserExisting(userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, userName));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, userName, teamName));
            }


            if (!CommandHelper.IsUserCreatorOfTeam(teamName, AuthenticationManager.GetCurrentUser()))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (AuthenticationManager.GetCurrentUser().UserName == userName)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "Disband"));
            }

            this.KickMemberFromTeam(teamName, userName);

            return $"User {userName} was kicked from {teamName}!";
        }

        private void KickMemberFromTeam(string teamName, string userName)
        {
            using (var context = new TeamBiulderContext())
            {
                var m = context.Users
                    .FirstOrDefault(u => u.UserName == userName);
                context.Teams
                    .FirstOrDefault(t => t.Name == teamName)
                    .Members
                    .Remove(m);
                context.SaveChanges();
            }
        }
    }
}
