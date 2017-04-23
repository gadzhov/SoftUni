using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class UploadPictureCommand
    {
        private readonly AlbumService _AlbumService;

        public UploadPictureCommand(AlbumService albumService)
        {
            this._AlbumService = albumService;
        }
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            var albumName = data[0];
            var pictureTitle = data[1];
            var pictureFilePath = data[2];

            var album = this._AlbumService.GetAlbumByName(albumName);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            this._AlbumService.UploadPicture(album, pictureTitle, pictureFilePath);

            return $"Picture {pictureTitle} added to {album.Name}!";
        }
    }
}
