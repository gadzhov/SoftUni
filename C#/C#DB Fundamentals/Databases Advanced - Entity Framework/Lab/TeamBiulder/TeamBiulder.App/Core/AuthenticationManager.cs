using System;
using TeamBiulder.App.Utilities;
using TeamBiulder.Models;

namespace TeamBiulder.App.Core
{
    public class AuthenticationManager
    {
        private static User currentUser;
        public static void Authorize()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }

        public static void Login(User user)
        {
            currentUser = user;
        }

        public static void LogOut()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
            currentUser = null;
        }

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }

        public static User GetCurrentUser()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
            return currentUser;
        }
    }
}
