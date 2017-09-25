namespace BankSystem.Models.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Must contain at least 1 lowercase letter, 1 uppercase letter and 1 digit.
    /// </summary>

    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value as string;

            return password.Any(char.IsLower) && password.Any(char.IsUpper) && password.Any(char.IsDigit);
        }
    }
}
