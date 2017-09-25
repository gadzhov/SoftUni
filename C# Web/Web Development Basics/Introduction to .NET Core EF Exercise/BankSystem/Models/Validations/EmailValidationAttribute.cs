namespace BankSystem.Models.Validations
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Must be in format (user)@(host) where:
    ///  1. (user) is a sequence of letters and digits, where '.', '-' and '_' can appear between them.
    ///  2. (host) is a sequence of at least two words, separated by dots '.'. Each word is sequence of letters and can have hyphens '-' between the letters.
    /// </summary>

    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            Regex regex = new Regex("^[^_.-].+[^_.-]@\\w+.\\w+$");

            return regex.Match(email).Success;
        }
    }
}
