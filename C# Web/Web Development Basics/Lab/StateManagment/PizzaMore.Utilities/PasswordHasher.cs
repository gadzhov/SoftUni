namespace PizzaMore.Utilities
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return $"SECRET{password}";
        }
    }
}
