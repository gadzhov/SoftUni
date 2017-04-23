using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class InviteToTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            // InviteToTeam <teamName> <username>
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            var teamName = inputArgs[0];
            var userName = inputArgs[1];
            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsTeamExisting(teamName) || !CommandHelper.IsUserExisting(userName))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }

            if (this.IsInvitePending(teamName, userName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!this.IsCreatorOrPartOfTeam(teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            this.SendInvite(teamName, userName);

            return $"Team {teamName} invited {userName}!";
        }

        private void SendInvite(string teamName, string userName)
        {
            using (var context = new TeamBiulderContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                var user = context.Users.FirstOrDefault(u => u.UserName == userName);

                var invitation = new Invitation()
                {
                    InvitedUser = user,
                    Team = team
                };

                if (context.Teams.Find(team.Id).CreatorId == user.Id)
                {
                    context.Teams.Find(team.Id).Members.Add(user);
                    invitation.IsActive = false;
                }

                context.Invitations.Add(invitation);
                context.SaveChanges();
            }
        }

        private bool IsCreatorOrPartOfTeam(string teamName)
        {
            using (var context = new TeamBiulderContext())
            {
                var currentUser = AuthenticationManager.GetCurrentUser();

                return context.Teams
                    .Include("Members")
                    .Any(t =>
                        t.Name == teamName &&
                        t.CreatorId == currentUser.Id || t.Members.Any(m => m.UserName == currentUser.UserName));
            }
        }

        private bool IsInvitePending(string teamName, string userName)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Invitations
                    .Include("Team")
                    .Include("InvitedUser")
                    .Any(i => i.Team.Name == teamName && i.InvitedUser.UserName == userName && i.IsActive);
            }
        }
    }
}
