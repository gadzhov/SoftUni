using System.Runtime.InteropServices;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ShareAlbumCommand
    {
        private readonly AlbumService _albumService;
        private readonly UserService _userService;

        public ShareAlbumCommand(AlbumService albumService, UserService userService)
        {
            this._albumService = albumService;
            this._userService = userService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            var albumId = int.Parse(data[0]);
            var username = data[1];
            var permission = data[2];

            var album = _albumService.GetAlbumById(albumId);

            if (album == null)
            {
                throw new ArgumentException($"Album with ID: {albumId} not found!");
            }

            if (!this._userService.IsExistingByUserName(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            if (permission != "Owner" && permission != "Viewer")
            {
                throw new ArgumentException($"Permission must be either “Owner” or “Viewer”!");
            }

            var user = _userService.GetUserByUserName(username);

            _albumService.ShareAlbum(album, user, permission);

            return $"Username {username} added to album {album.Name} ([permission])";
        }
    }
}
