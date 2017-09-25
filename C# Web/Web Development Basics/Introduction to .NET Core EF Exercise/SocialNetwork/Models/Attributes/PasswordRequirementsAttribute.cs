namespace SocialNetwork.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class PasswordRequirementsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string password = value as string;
            char[] specialChars = new[] {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+', '<', '>', '?'};
            if (!password.Any(char.IsLower) || !password.Any(char.IsUpper) || !password.Any(char.IsDigit) || !password.Any(ch => specialChars.Contains(ch)))
            {
                return false;
            }

            return true;
        }
    }
}
