using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Service
{
    public class TagAlbumService
    {
        public static void Add(Album album, Tag tag)
        {
            using (var context = new PhotoShareContext())
            {
                context.Tags.Attach(tag);
                context.Albums.Attach(album);
                var firstOrDefault = context.Albums.FirstOrDefault(a => a.Name == album.Name);
                if (firstOrDefault != null)
                {
                    firstOrDefault.Tags.Add(tag);
                    context.SaveChanges();
                }
            }
        }
    }
}
