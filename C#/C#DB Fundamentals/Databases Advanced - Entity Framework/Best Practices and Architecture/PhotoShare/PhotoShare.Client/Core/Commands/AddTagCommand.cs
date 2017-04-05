using System;
using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{

    using Utilities;

    public class AddTagCommand
    {
        private readonly TagService _tagService;

        public AddTagCommand(TagService tagService)
        {
            this._tagService = tagService;
        }
        public string Execute(string[] data)
        {
            var tag = data[0].ValidateOrTransform();

            if (this._tagService.IsTagExistByTagName(tag))
            {
                throw new ArgumentException($"Tag {tag} exists!");
            }

            TagService.AddTag(tag);
            return tag + " was added successfully to database!";
        }
    }
}
