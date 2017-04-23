using System.Linq;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Utilities
{
    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string username)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Users.Any(u => u.UserName == username && !u.IsDeleted);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Invitations
                    .Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Teams.Any(t => t.Name == teamName && t.Members.Any(m => m.UserName == username));
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Events
                    .Any(e => e.Name == eventName);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Events
                           .FirstOrDefault(e => e.Name == eventName)
                           .CreatorId == user.Id;
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Teams
                           .FirstOrDefault(t => t.Name == teamName)
                           .CreatorId == user.Id;
            }
        }
    }
}
