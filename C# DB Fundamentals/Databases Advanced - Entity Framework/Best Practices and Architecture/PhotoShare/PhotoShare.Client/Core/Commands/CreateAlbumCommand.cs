using System.Linq;
using PhotoShare.Client.Utilities;
using PhotoShare.Models;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class CreateAlbumCommand
    {
        private readonly AlbumService _albumService;
        private readonly UserService _userService;
        private readonly ColorService _colorService;
        private readonly TagService _tagService;

        public CreateAlbumCommand(AlbumService albumService, UserService userService, ColorService colorService, TagService tagService)
        {
            this._albumService = albumService;
            this._userService = userService;
            this._colorService = colorService;
            this._tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            var username = data[0];
            var albumTitle = data[1];
            var bgColor = data[2];
            data = data.Skip(3).ToArray();
            var tagsArray = new string[data.Length];
            //Validate data or transforme
            for (var i = 0; i < data.Length; i++)
            {
                tagsArray[i] = data[i].ValidateOrTransform();
            }
            if (!this._userService.IsExistingByUserName(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (this._albumService.IsAlbumExist(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            if (!this._colorService.IsColorExist(bgColor))
            {
                throw new ArgumentException($"Color {bgColor} not found!");
            }

            if (tagsArray.Any(t => !this._tagService.IsTagExistByTagName(t.ValidateOrTransform())))
            {
                throw new ArgumentException("Invalid tags!");
            }

            var tags = _tagService.GeTags(tagsArray);

            User user = this._userService.GetUserByUserName(username);
            Color color = this._colorService.GetColorByName(bgColor);

            this._albumService.CreateAlbum(user, albumTitle, color, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}
