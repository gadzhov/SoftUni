using System;
using System.Linq;
using System.Reflection;
using TeamBiulder.App.Core.Commands;

namespace TeamBiulder.App.Core
{
    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            var result = string.Empty;
            var inputArgs = input.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            var commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();
            
            // Get command type
            Type commandType = Type.GetType("TeamBiulder.App.Core.Commands." + commandName + "Command");

            // If command's type is not found - it is not valid command.
            if (commandType == null)
            {
                throw new NotSupportedException($"Command {commandName} not supported!");
            }

            // Create a instance of command with the type that we already exracted.
            object command = Activator.CreateInstance(commandType);

            // Get the method called "Execute" of the command.
            MethodInfo executeMethod = command.GetType().GetMethod("Execute");

            // Invoke the method we found passing the instance of the command and
            // array of all expected arguments that the method should take when it is invoked.
            result = executeMethod.Invoke(command, new object[] {inputArgs}) as string;
            
            /*
            switch (commandName)
            {
                case "RegisterUser":
                    var registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(inputArgs);
                    break;
                case "Login":
                    var login = new LoginCommand();
                    result = login.Execute(inputArgs);
                    break;
                case "Logout":
                    var logout = new LogoutCommand();
                    result = logout.Execute(inputArgs);
                    break;
                case "DeleteUser":
                    var deleteUser = new DeleteUserCommand();
                    result = deleteUser.Execute(inputArgs);
                    break;
                case "CreateEvent":
                    var createEvent = new CreateEventCommand();
                    result = createEvent.Execute(inputArgs);
                    break;
                case "CreateTeam":
                    var createTeam = new CreateTeamCommand();
                    result = createTeam.Execute(inputArgs);
                    break;
                case "InviteToTeam":
                    var inviteToTeam = new InviteToTeamCommand();
                    result = inviteToTeam.Execute(inputArgs);
                    break;
                case "AcceptInvite":
                    var acceptInvite = new AcceptInviteCommand();
                    result = acceptInvite.Execute(inputArgs);
                    break;
                case "DeclineInvite":
                    var declineInvite = new DeclineInviteCommand();
                    result = declineInvite.Execute(inputArgs);
                    break;
                case "KickMember":
                    var kickMember = new KickMemberCommand();
                    result = kickMember.Execute(inputArgs);
                    break;
                case "Disband":
                    var disband = new DisbandTeamCommand();
                    result = disband.Execute(inputArgs);
                    break;
                case "AddTeamTo":
                    var addTeamTo = new AddTeamToCommand();
                    result = addTeamTo.Execute(inputArgs);
                    break;
                case "ShowEvent":
                    var showEvent = new ShowEventCommand();
                    result = showEvent.Execute(inputArgs);
                    break;
                case "ShowTeam":
                    var showTeam = new ShowTeamCommand();
                    result = showTeam.Execute(inputArgs);
                    break;
                case "ImportUsers":
                    var importsUsers = new ImportUsersCommand();
                    result = importsUsers.Execute(inputArgs);
                    break;
                case "ImportTeams":
                    var importTeam = new ImportTeamsCommand();
                    result = importTeam.Execute(inputArgs);
                    break;
                case "Exit":
                    var exit = new ExitCommand();
                    exit.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }
            */

            return result;
        }
    }
}
