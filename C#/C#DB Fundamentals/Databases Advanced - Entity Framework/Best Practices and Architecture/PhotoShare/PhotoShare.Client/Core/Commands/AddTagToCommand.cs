using PhotoShare.Client.Utilities;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class AddTagToCommand
    {
        private readonly TagService _tagService;
        private readonly AlbumService _albumService;

        public AddTagToCommand(TagService tagService, AlbumService albumService)
        {
            this._tagService = tagService;
            this._albumService = albumService;
        }
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            var albumName = data[0];
            var tagName = data[1].ValidateOrTransform();
            if (!this._tagService.IsTagExistByTagName(tagName) || !this._albumService.IsAlbumExist(albumName))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }
            var album = this._albumService.GetAlbumByName(albumName);
            var tag = this._tagService.GeTagByName(tagName);
            TagAlbumService.Add(album, tag);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
