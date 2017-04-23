using System;
using System.Linq;
using TeamBiulder.App.Utilities;
using TeamBiulder.Data;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core.Commands
{
    public class RegisterUserCommand
    {
        // RegisterUse <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
        public string Execute(string[] inputArgs)
        {
            // Validate input lenght
            Check.CheckLength(7, inputArgs);

            var username = inputArgs[0];

            // Validate given username
            if (username.Length < Constants.MinUsernameLenght || username.Length > Constants.MaxUsernameLenght)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            var password = inputArgs[1];

            // Validate password
            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            var repeatedPassword = inputArgs[2];

            // Validate passwords
            if (password != repeatedPassword)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.PasswordDoesNotMatch);
            }

            var firstName = inputArgs[3];
            var lastName = inputArgs[4];

            int age;
            bool isNumber = int.TryParse(inputArgs[5], out age);

            // Validate age.
            if (!isNumber || age <= 0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            Gender gender;
            bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);

            // Validate gender.
            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }

            // Chech if the given username is taken and if not to register a new one
            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));
            }

            this.RegisterUser(username, password, firstName, lastName, age, gender);

            return $"User {username} was registered successfully!";
        }

        private void RegisterUser(string username, string password, string firstName, string lastName, int age, Gender gender)
        {
            using (var context = new TeamBiulderContext())
            {
                var user = new User()
                {
                    UserName = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
