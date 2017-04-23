using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Service
{
    public class UserService
    {
        public virtual void Add(string username, string password, string email)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    IsDeleted = false,
                    RegisteredOn = DateTime.Now,
                    LastTimeLoggedIn = DateTime.Now
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public virtual bool IsExistingByUserName(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public User GetUserByUserName(string userName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == userName);
            }
        }
        //TODO Fix this issue, not updating the DB
        public void UpdateUsersBornTown(User user, Town town)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(user);
                context.Towns.Attach(town);
                context.Users.FirstOrDefault(u => u.Username == user.Username).BornTown = town;
                //context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void UpdateUsersCurrentTown(User user, Town town)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(user);
                context.Towns.Attach(town);
                context.Users.FirstOrDefault(u => u.Username == user.Username).CurrentTown = town;
                //context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateUsersPassword(User user)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public bool IsDeleted(string username)
        {
            using (var context = new PhotoShareContext())
            {
                var firstOrDefault = context.Users.FirstOrDefault(u => u.Username == username);
                return firstOrDefault != null && firstOrDefault.IsDeleted == true;
            }
        }

        public void Remove(string username)
        {
            using (var constext = new PhotoShareContext())
            {
                var user = constext.Users.SingleOrDefault(u => u.Username == username);
                if (user != null) user.IsDeleted = true;
                constext.SaveChanges();
            }
        }

        public bool AreTheyFriends(string firstName, User secondUser)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(secondUser);
                var firstOrDefault = context.Users.FirstOrDefault(u => u.Username == firstName);
                return firstOrDefault != null && firstOrDefault.Friends.Contains(secondUser);
            }
        }

        public void MakeFriends(string firstName, User secondUser)
        {
            using (var context = new PhotoShareContext())
            {
                var firstUser = GetUserByUserName(firstName);
                context.Users.Attach(firstUser);
                context.Users.Attach(secondUser);
                firstUser.Friends.Add(secondUser);
                context.SaveChanges();
            }
        }

        public List<User> GetUserFriendList(User user)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(user);
                return user.Friends.ToList();
            }
        }

        public bool IsLoggedIn(string currentUsername)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == currentUsername).IsLoged;
            }
        }

        public bool LoginHandler(string name, string password)
        {
            using (var context = new PhotoShareContext())
            {
                if (context.Users.Any(u => u.Username == name && u.Password == password))
                {
                    context.Users.FirstOrDefault(u => u.Username == name).IsLoged = true;
                    return false;
                }
                return true;
            }
        }
    }
}
