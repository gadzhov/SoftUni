using System.Collections.Generic;
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Service
{
    public class TagService
    {
        public static void AddTag(string tag)
        {
            using (var context = new PhotoShareContext())
            {
                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }
        }

        public bool IsTagExistByTagName(string tagName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == tagName);
            }
        }

        public List<Tag> GeTags(string[] tagArray)
        {
            using (var context = new PhotoShareContext())
            {
                var tagsCollection = new List<Tag>();
                for (var i = 0; i < tagArray.Length; i++)
                {
                    var tag = tagArray[i];
                    tagsCollection.Add(context.Tags.FirstOrDefault(t => t.Name == tag));
                }
                return tagsCollection;
            }
        }

        public Tag GeTagByName(string name)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Tags.FirstOrDefault(t => t.Name == name);
            }
        }
    }
}
