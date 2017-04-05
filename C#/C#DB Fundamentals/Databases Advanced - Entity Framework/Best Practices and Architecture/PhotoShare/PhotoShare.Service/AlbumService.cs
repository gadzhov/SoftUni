using System;
using System.Collections.Generic;
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Service
{
    public class AlbumService
    {
        public void CreateAlbum(User user, string albumTitle, Color bgColor, List<Tag> tagNames)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(user);
                foreach (var tag in tagNames)
                {
                    context.Tags.Attach(tag);
                }
                context.Albums.Add(new Album()
                {
                    Name = albumTitle,
                    Tags = tagNames,
                    BackgroundColor = bgColor,
                    AlbumRoles = new List<AlbumRole>()
                    {
                        new AlbumRole()
                        {
                            User = user,
                            Role = Role.Owner
                        }
                    }
                });
                context.SaveChanges();
            }
        }

        public bool IsAlbumExist(string albumTitle)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumTitle);
            }
        }

        public Album GetAlbumByName(string name)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.FirstOrDefault(a => a.Name == name);
            }
        }

        public Album GetAlbumById(int id)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Find(id);
            }
        }

        public void ShareAlbum(Album album, User user, string permission)
        {
            using (var context = new PhotoShareContext())
            {
                context.Albums.Attach(album);
                context.Users.Attach(user);
                Role permissionRole;
                Enum.TryParse(permission, out permissionRole);

                album.AlbumRoles.Add(new AlbumRole()
                {
                    User = user,
                    Role = permissionRole
                });
                context.SaveChanges();
            }
        }

        public void UploadPicture(Album album, string pictureTitle, string pictureFilePath)
        {
            using (var context = new PhotoShareContext())
            {
                context.Albums.Attach(album);
                album.Pictures.Add(new Picture()
                {
                    Title = pictureTitle,
                    Path = pictureFilePath
                });
                context.SaveChanges();
            }
        }
    }
}
