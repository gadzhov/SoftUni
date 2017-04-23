using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class ImportUsersCommand
    {
        public string Execute(string[] inputArgs)
        {
            // ImportUsers <filePathToXmlFile>
            Check.CheckLength(1, inputArgs);

            var filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }
            List<User> users;
            try
            {
                users = this.GetUsersFromXml(filePath);
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            this.AddUsers(users);

            return $"You have successfully imported {users.Count} users!";
        }

        private void AddUsers(List<User> users)
        {
            using (var context = new TeamBiulderContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }

        private List<User> GetUsersFromXml(string filePath)
        {
            var xDoc = XDocument.Load(filePath);
            var xElements = xDoc.Root.Elements();
            var users = new List<User>();
            foreach (var xElement in xElements)
            {
                var userName = xElement.Element("username").Value;
                var password = xElement.Element("password").Value;
                var firstName = xElement.Element("first-name").Value;
                var lastName = xElement.Element("last-name").Value;
                var age = int.Parse(xElement.Element("age").Value);
                Gender gender;
                var g = xElement.Element("gender").Value;
                Enum.TryParse(g, true, out gender);

                var user = new User()
                {
                    UserName = userName,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };

                users.Add(user);
            }
            return users;
        }
    }
}
