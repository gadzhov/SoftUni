namespace SimpleMvc.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Framework.Attributes.Methods;
    using Framework.Contracts;
    using Framework.Controllers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using SimpleMvc.App.Data;
    using SimpleMvc.App.Dto;
    using SimpleMvc.App.Models;
    using SimpleMvc.Framework.Contracts.Generic;
    using SimpleMvc.Framework.ViewEngine.Generic;

    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserDto user)
        {

            using (NotesDbContext context = new NotesDbContext())
            {
                context.Users.Add(new User
                {
                    Username = user.Username,
                    Password = user.Password
                });
                context.SaveChanges();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesDto> All()
        {
            List<UserDto> userNames = null;
            using (NotesDbContext context = new NotesDbContext())
            {
                userNames = context
                    .Users
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        Username = u.Username,
                        Password = u.Password
                    })
                    .ToList();
            }

            AllUsernamesDto viewModelDto = new AllUsernamesDto
            {
                Users = userNames
            };

            return this.View(viewModelDto);
        }

        [HttpGet]
        public IActionResult<UserProfileDto> Profile(int id)
        {
            UserProfileDto profile = new UserProfileDto();
            using (NotesDbContext context = new NotesDbContext())
            {
                User user = context
                    .Users
                    .Include(u => u.Notes)
                    .FirstOrDefault(u => u.Id == id);

                profile.Id = user.Id;
                profile.Name = user.Username;
                profile.Notes = user.Notes.Any()
                    ? user.Notes.Select(n => new NoteDto()
                    {
                        Title = n.Title,
                        Content = n.Content
                    }) : new List<NoteDto>();
            }
            
            return this.View(profile);
        }

        [HttpPost]
        public IActionResult<UserProfileDto> Profile(NoteDto note)
        {
            using (NotesDbContext context = new NotesDbContext())
            {
                context.Notes.Add(new Note
                {
                    Title = note.Title,
                    Content = note.Content,
                    OwnerId = note.OwnerId
                });
                context.SaveChanges();

            }

            return this.Profile(note.OwnerId);
        }
    }
}
