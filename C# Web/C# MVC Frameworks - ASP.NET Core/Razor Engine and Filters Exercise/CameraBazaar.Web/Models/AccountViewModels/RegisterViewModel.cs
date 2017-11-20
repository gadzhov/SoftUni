namespace CameraBazaar.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} symbols.", MinimumLength = 4)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "The {0} must contains only letters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [RegularExpression("[a-z0-9]+", ErrorMessage = "The {0} can contain only lowercase letters and digits.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^\+\d{10,12}$", ErrorMessage = "The {0} must start with '+' sign followed by 10 to 12 digits")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
