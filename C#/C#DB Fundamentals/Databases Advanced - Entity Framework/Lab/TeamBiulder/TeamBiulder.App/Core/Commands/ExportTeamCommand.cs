using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class ExportTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            // ExportTeam <teamName>
            Check.CheckLength(1, inputArgs);

            var teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            Team team = this.GetTeamByNameWithMembers(teamName); 

            this.ExportTeam(team);

            return $"Team {teamName} exported!";
        }

        private void ExportTeam(Team team)
        {
            var json = JsonConvert.SerializeObject(new
            {
                team.Name,
                team.Acronym,
                Members = team.Members.Select(m => m.UserName)
            }, Formatting.Indented);

            File.WriteAllText("team.json", json);
        }

        private Team GetTeamByNameWithMembers(string teamName)
        {
            using (var context = new TeamBiulderContext())
            {
                return context.Teams
                    .Include("Members")
                    .FirstOrDefault(t => t.Name == teamName);
            }
        }
    }
}
