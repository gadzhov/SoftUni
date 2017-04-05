using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class AddTeamToCommand
    {
        public string Execute(string[] inputArgs)
        {
            // AddTeamTo <eventName> <teamName>
            Check.CheckLength(2, inputArgs);
            AuthenticationManager.Authorize();

            var eventName = inputArgs[0];
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            var teamName = inputArgs[1];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfEvent(eventName, AuthenticationManager.GetCurrentUser()))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            this.AddTeamToEvent(teamName, eventName);
            
            return $"Team {teamName} added for {eventName}!";
        }

        private void AddTeamToEvent(string teamName, string eventName)
        {
            using (var context = new TeamBiulderContext())
            {
                var team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                var ev = context.Events
                    .OrderByDescending(e => e.StartDate)
                    .FirstOrDefault(e => e.Name == eventName);

                if (ev.ParticipatingTeams.Any(t => t.Name == teamName))
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.CannotAddSameTeamTwice);
                }

                ev.ParticipatingTeams.Add(team);
                context.SaveChanges();
            }
        }
    }
}
