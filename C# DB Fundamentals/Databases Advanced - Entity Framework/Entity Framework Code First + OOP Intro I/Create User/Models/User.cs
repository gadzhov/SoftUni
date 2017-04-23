using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Create_User.Models
{
    public class User
    {
        private string _password;
        private string _email;

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4), MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6), MaxLength(50)]
        public string Password
        {
            get { return this._password; }

            set
            {
                if (!value.Any(char.IsLower))
                {
                    throw new ArgumentException("Should have at least 1 lowercase letter");
                }
                if (!value.Any(char.IsUpper))
                {
                    throw new ArgumentException("Should have at least 1 uppercase letter");
                }
                if (!value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Should have at least 1 digit");
                }
                var regex = new Regex(@"[!@#$%^&*,()_+<>?]");
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Should have at least 1 special symbol");
                }
                _password = value;
            }
        }

        [Required]
        public string Email
        {
            get { return this._email; }
            set
            {
                var regex = new Regex(@"^([a-z]*.*\-*_*[a-z]+)@[a-z]+\-*.+\.[a-z]+$");
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Email should be in correct form");
                }
                _email = value;
            }
        }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }
        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

    }
}
