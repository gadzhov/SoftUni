using System.Linq;
using PhotoShare.Client.Core.Commands;
using PhotoShare.Service;

namespace PhotoShare.Client.Core
{
    using System;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            var command = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            var result = string.Empty;
            var albumService = new AlbumService();
            var userService = new UserService();
            var townService = new TownService();
            var tagService = new TagService();
            var colorService = new ColorService();
            string currentUser;
            if (command == "Login")
            {
                
            }
            switch (command)
            {
                case "RegisterUser":
                    var registerUser = new RegisterUserCommand(userService);
                    result = registerUser.Execute(commandParameters);
                    break;
                case "AddTown":
                    var addTown = new AddTownCommand(townService);
                    result = addTown.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    var modifyUser = new ModifyUserCommand(userService, townService);
                    result = modifyUser.Execute(commandParameters);
                    break;
                case "DeleteUser": 
                    var deleteUser = new DeleteUser(userService);
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "AddTag":
                    var addTag = new AddTagCommand(tagService);
                    result = addTag.Execute(commandParameters);
                    break;
                case "CreateAlbum":
                    var createAlbum = new CreateAlbumCommand(albumService, userService, colorService, tagService);
                    result = createAlbum.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    var addTagTo = new AddTagToCommand(tagService, albumService);
                    result = addTagTo.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    var makeFriends = new MakeFriendsCommand(userService);
                    result = makeFriends.Execute(commandParameters);
                    break;
                case "ListFriends":
                    var listFriends = new PrintFriendsListCommand(userService);
                    listFriends.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    var shareAlbum = new ShareAlbumCommand(albumService, userService);
                    result = shareAlbum.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    var uploadPicture = new UploadPictureCommand(albumService);
                    result = uploadPicture.Execute(commandParameters);
                    break;
                case "Exit": 
                    var exit = new ExitCommand();
                    exit.Execute();
                    break;
                case "Login":
                    var login = new LoginCommand(userService);
                    result = login.Execute(commandParameters);
                    break;
                default:
                    return "Invalid Command";
            }
            return result;
        }
    }
}
