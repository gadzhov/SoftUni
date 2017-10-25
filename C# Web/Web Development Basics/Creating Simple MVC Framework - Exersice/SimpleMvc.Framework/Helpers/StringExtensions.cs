namespace SimpleMvc.Framework.Helpers
{
    using System.Linq;

    public static class StringExtensions
    {
        public static string Capitaliza(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            char firstLetter = char.ToUpper(input.First());
            string rest = input.Substring(1);

            return $"{firstLetter}{rest}";
        }
    }
}
