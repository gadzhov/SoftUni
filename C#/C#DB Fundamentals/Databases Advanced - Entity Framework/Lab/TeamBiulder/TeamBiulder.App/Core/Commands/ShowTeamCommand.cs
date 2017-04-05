using System;
using System.CodeDom.Compiler;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class ShowTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            // ShowTeam <teamName>
            Check.CheckLength(1, inputArgs);

            var teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            return this.ShowTeam(teamName);
        }

        private string ShowTeam(string teamName)
        {
            using (var context = new TeamBiulderContext())
            {
                var team = context.Teams
                    .FirstOrDefault(t => t.Name == teamName);
                var result = $"{team.Name} {team.Acronym}";

                foreach (var member in team.Members)
                {
                    result += "\n" + $"--{member.UserName}";
                }

                return result;
            }
        }
    }
}
