using TeamBiulder.App.Utilities;

namespace TeamBiulder.App.Core.Commands
{
    public class LogoutCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            AuthenticationManager.Authorize();
            var currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.LogOut();

            return $"User {currentUser.UserName} successfully logged out!";
        }
    }
}
