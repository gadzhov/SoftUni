using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class ImportTeamsCommand
    {
        public string Execute(string[] inputArgs)
        {
            // ImportTeams<filePathToXmlFile>
            Check.CheckLength(1, inputArgs);

            var filePath = inputArgs[0];
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }

            List<Team> teams;
            try
            {
                teams = this.GetTeamsFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            this.AddTeams(teams);

            return $"You have successfully imported {teams.Count} teams!";
        }

        private void AddTeams(List<Team> teams)
        {
            using (var context = new TeamBiulderContext())
            {
                context.Teams.AddRange(teams);
                context.SaveChanges();
            }
        }

        private List<Team> GetTeamsFromXml(string filePath)
        {
            var teams = new List<Team>();

            var xDoc = XDocument.Load(filePath);
            var xElemnets = xDoc.Root.Elements();
            
            foreach (var xElement in xElemnets)
            {
                var name = xElement.Element("name").Value;
                var acronym = xElement.Element("acronym").Value;
                var description = xElement.Element("description").Value;
                var creatorId = int.Parse(xElement.Element("creator-id").Value);

                var team = new Team()
                {
                    Name = name,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                };

                teams.Add(team);
            }

            return teams;
        }
    }
}
