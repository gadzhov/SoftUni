namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SocialNetwork.Data;
    using SocialNetwork.Models;
    using SocialNetwork.Models.Enums;
    using SocialNetwork.Utilities;

    public class Startup
    {
        public static void Main()
        {
            using (SocialNetworkContext context = new SocialNetworkContext())
            {
                context.Database.Migrate();

                // SeedData(context);
                // ListAllUsersWithAllFriends(context);
                // ListAllActiveUsersWithMoreThanFiveFriends(context);
                // SeedAlbumsData(context);
                // ListAllAlbumsInfo(context);
                // ListPicturesIncludedInMoreThanTwoAlbums(context);
                // ListAllAlbumsByGivenUserId(context);
                // RecieveTagsAndSaveThemToDb(context);
                // ListAllAlbumsByGivenTag(context);
                // ListAllUsersWithMoreThan3Tags(context);
            }
        }

        private static void ListAllUsersWithMoreThan3Tags(SocialNetworkContext context)
        {
            var users = context
                .Users
                .Where(u => u.AlbumsOwned.Any(a => a.Tags.Count >= 2)) // yeaa... lazy to fix seed...
                .OrderByDescending(u => u.AlbumsOwned.Count)
                .ThenBy(u => u.Username)
                .Select(u => new
                {
                    u.Username,
                    Album = u.AlbumsOwned.Select(a => new
                    {
                        a.Name,
                        TagName = a.Tags.Select(t => t.Tag.Name)
                    })
                })
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine(user.Username);
                foreach (var album in user.Album)
                {
                    Console.WriteLine($"--Name {album.Name}| {string.Join(", ", album.TagName)}");
                }
            }

        }

        private static void ListAllAlbumsByGivenTag(SocialNetworkContext context)
        {
            Console.WriteLine("Enter tag name:");
            string tagName = Console.ReadLine();
            var albums = context
                .Albums
                .Where(a => a.Tags.Any(t => t.Tag.Name == tagName))
                .OrderByDescending(a => a.Tags.Count)
                .ThenBy(a => a.Name)
                .Select(a => new
                {
                    a.Name,
                    a.Owner.Username
                })
                .ToList();

            foreach (var album in albums)
            {
                Console.WriteLine($"Name: {album.Name} | Owner: {album.Username}");
            }
        }

        private static void RecieveTagsAndSaveThemToDb(SocialNetworkContext context)
        {
            Console.WriteLine("Enter tag:");
            string tagAsString = Console.ReadLine();
            string validTag = tagAsString.Transform();
            List<Album> albums = context.Albums.ToList();
            Random rnd = new Random();

            Tag tag = new Tag()
            {
                Name = validTag
            };
            for (int i = 0; i < 2; i++)
            {
                int next = rnd.Next(0, albums.Count);
                if (tag.Albums.All(a => a.AlbumId != next))
                {
                    tag.Albums.Add(new AlbumTags()
                    {
                        AlbumId = albums[next].Id
                    });
                }
            }
            context.Tags.Add(tag);

            context.SaveChanges();

            Console.WriteLine($"{tag} was added to database");
        }

        private static void ListAllAlbumsByGivenUserId(SocialNetworkContext context)
        {
            Console.WriteLine("Enter ownerId:");
            int ownerId = int.Parse(Console.ReadLine());
            var albums = context
                .Albums
                .Where(a => a.OwnerId == ownerId)
                .Select(a => new
                {
                    a.Owner.Username,
                    a.Name,
                    a.IsPublic,
                    Pictures = a.Pictures
                        .Select(p => new
                        {
                            p.Picture.Title,
                            p.Picture.Path
                        })
                })
                .OrderBy(a => a.Name)
                .ToList();

            foreach (var album in albums)
            {
                Console.WriteLine($"Album name: {album.Name}| Owner {album.Username}");
                if (album.IsPublic)
                {
                    foreach (var picture in album.Pictures)
                    {
                        Console.WriteLine($"--{picture.Title}| {picture.Path}");
                    }
                }
                else
                {
                    Console.WriteLine("Private content!");
                }
            }
        }

        private static void ListPicturesIncludedInMoreThanTwoAlbums(SocialNetworkContext context)
        {
            var pictures = context
                .Pictures
                .Where(p => p.Albums.Count >= 2)
                .OrderByDescending(p => p.Albums.Count)
                .ThenBy(p => p.Title)
                .Select(p => new
                {
                    p.Title,
                    AlbumName = p.Albums.Select(a => a.Album.Name),
                    OwnerName = p.Albums.Select(a => a.Album.Owner.Username)
                })
                .ToList();

            foreach (var picture in pictures)
            {
                Console.WriteLine($"Title: {picture.Title}");
                Console.WriteLine($"--AlbumsOwned: {string.Join(", ", picture.AlbumName)}");
                Console.WriteLine($"---Owners: {string.Join(", ", picture.OwnerName)}");
            }
        }

        private static void ListAllAlbumsInfo(SocialNetworkContext context)
        {
            var albums = context
                .Albums
                .Select(a => new
                {
                    AlbumTitle = a.Name,
                    OwnerName = a.Owner.Username,
                    Count = a.Pictures.Count
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.OwnerName)
                .ToList();

            foreach (var album in albums)
            {
                Console.WriteLine($"Album title: {album.AlbumTitle}| Owner name: {album.OwnerName}| Pictures count: {album.Count}");
            }
        }

        private static void SeedAlbumsData(SocialNetworkContext context)
        {
            // Pictures
            for (int i = 0; i < 20; i++)
            {
                Picture picture = new Picture()
                {
                    Caption = $"caption{i}",
                    Path = $"D:\\Projects\\Visual Studio\\Web\\C# Web Development Basics\\Introduction to .NET Core EF Exercise\\{i}",
                    Title = $"title{i}"
                };

                context.Pictures.Add(picture);
            }

            context.SaveChanges();

            // AlbumsOwned
            Random rnd = new Random();
            List<User> users = context.Users.ToList();
            List<Picture> pictures = context.Pictures.ToList();
            for (int i = 0; i < 10; i++)
            {
                Album album = new Album()
                {
                    Name = $"album{i}",
                    BackgroundColor = (Colors)rnd.Next(0, 5),
                    IsPublic = rnd.Next(0, 10) % 2 == 0,
                    Owner = users[rnd.Next(0, users.Count)]
                };
                for (int j = 0; j < 3; j++)
                {
                    album.Pictures.Add(new AlbumPictures()
                    {
                        Picture = pictures[rnd.Next(0, pictures.Count)]
                    });
                }

                context.Albums.Add(album);
            }

            context.SaveChanges();
        }

        private static void ListAllActiveUsersWithMoreThanFiveFriends(SocialNetworkContext context)
        {
            var users = context
                .Users
                .Where(u => u.Friends.Count >= 2) // If is it 5 will print nothing (seed method put only 2 friends....)
                .OrderByDescending(u => u.Friends.Count)
                .ThenBy(u => u.Username)
                .Select(u => new
                {
                    u.Username,
                    NumberOfFriends = u.Friends.Count,
                    Period = Math.Floor(DateTime.Now.Subtract(u.RegisteredOn).TotalDays)
                });

            foreach (var user in users)
            {
                Console.WriteLine($"username: {user.Username}| number of friends: {user.NumberOfFriends}| period: {user.Period}");
            }
        }

        private static void ListAllUsersWithAllFriends(SocialNetworkContext context)
        {
            var users = context
                .Users
                .Where(u => u.Friends.Any())
                .Select(u => new
                {
                    u.Username,
                    Count = u.Friends.Count,
                    Friends = u.Friends
                        .Select(f => new
                        {
                            Status = f.Friend.IsDeleted ? "Inactive" : "Active"
                        })
                })
                .OrderByDescending(u => u.Count)
                .ThenBy(u => u.Username)
                .ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"User {user.Username} have {user.Count} friends");
                foreach (var friend in user.Friends)
                {
                    Console.WriteLine($"---{friend.Status}");
                }
            }
        }

        private static void SeedData(SocialNetworkContext context)
        {
            // Users
            DateTime currenDateTime = DateTime.Now;
            for (int i = 0; i < 40; i++)
            {
                User user = new User()
                {
                    Username = $"username{i}",
                    Age = i + 10,
                    Email = $"username{i}@abv.bg",
                    IsDeleted = false,
                    LastLogin = currenDateTime.AddDays(-i),
                    RegisteredOn = currenDateTime.AddMonths(-i),
                    Password = "As23@bg231"
                };

                context.Users.Add(user);
            }

            context.SaveChanges();

            // Friends
            Random rnd = new Random();
            List<User> users = context.Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    // If throw exception run it again :D
                    //TODO: check for duplicate key pairs in UserFriends table.
                    users[i].Friends.Add(new UserFriends()
                    {
                        User = users[i],
                        Friend = users[rnd.Next(0, users.Count)]
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
