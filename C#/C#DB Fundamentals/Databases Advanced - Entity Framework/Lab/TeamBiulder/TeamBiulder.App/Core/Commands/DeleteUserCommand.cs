using TeamBiulder.App.Utilities;
using TeamBiulder.Data;

namespace TeamBiulder.App.Core.Commands
{
    public class DeleteUserCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            AuthenticationManager.Authorize();

            var currentUser = AuthenticationManager.GetCurrentUser();

            using (var context = new TeamBiulderContext())
            {
                context.Users.Attach(currentUser);
                currentUser.IsDeleted = true;
                context.SaveChanges();

                AuthenticationManager.LogOut();
            }

            return $"User {currentUser.UserName} was deleted successfully!";
        }
    }
}
