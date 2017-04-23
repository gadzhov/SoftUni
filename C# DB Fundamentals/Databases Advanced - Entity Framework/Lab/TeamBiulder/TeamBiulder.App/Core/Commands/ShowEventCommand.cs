using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class ShowEventCommand
    {
        public string Execute(string[] inputArga)
        {
            // ShowEvent <eventName>
            Check.CheckLength(1, inputArga);

            var eventName = inputArga[0];
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            return ShowEvent(eventName);
        }

        private string ShowEvent(string eventName)
        {
            using (var context = new TeamBiulderContext())
            {
                var ev =  context.Events
                    .OrderByDescending(e => e.StartDate)
                    .FirstOrDefault(e => e.Name == eventName);

                var result = $"{ev.Name} {ev.StartDate} {ev.EndDate} {ev.Description}";
                foreach (var team in ev.ParticipatingTeams)
                {
                    result += "\n" + $"--{team.Name}";
                }

                return result;
            }
        }
    }
}
