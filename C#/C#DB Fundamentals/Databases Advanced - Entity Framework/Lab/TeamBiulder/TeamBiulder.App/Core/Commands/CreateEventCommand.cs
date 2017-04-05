using System;
using System.Globalization;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class CreateEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            // CreateEvent <name> <description> <startDate> <endDate>
            Check.CheckLength(6, inputArgs);
            AuthenticationManager.Authorize();

            var eventName = inputArgs[0];
            var description = inputArgs[1];

            DateTime startDateTime;

            var isStartDateTime = DateTime.TryParseExact(inputArgs[2] + " " + inputArgs[3],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out startDateTime);

            DateTime enDateTime;

            var isEndDateTime = DateTime.TryParseExact(inputArgs[4] + " " + inputArgs[5],
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out enDateTime);

            if (!isStartDateTime || !isEndDateTime)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }
            
            if (startDateTime > enDateTime)
            {
                throw new ArgumentException("StartDate must be before EndDate!");
            }

            this.CreateEvent(eventName, description, startDateTime, startDateTime);

            return $"Event {eventName} was created successfully!";
        }

        private void CreateEvent(string eventName, string description, DateTime startDate, DateTime endDate)
        {
            using (var context = new TeamBiulderContext())
            {
                var newEvent = new Event()
                {
                    Name = eventName,
                    Description = description,
                    StartDate = startDate,
                    EndDate = endDate,
                    CreatorId = AuthenticationManager.GetCurrentUser().Id
                };

                context.Events.Add(newEvent);
                context.SaveChanges();

            }
        }
    }
}
