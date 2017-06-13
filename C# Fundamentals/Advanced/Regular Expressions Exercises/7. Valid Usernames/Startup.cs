namespace _07.Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main(string[] args)
        {
            var users = Console.ReadLine().Split(new char[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            var validUsers = new List<string>();
            var rg = new Regex(@"^[A-Za-z]\w{2,24}$");

            foreach (var user in users)
            {
                if (rg.IsMatch(user))
                {
                    validUsers.Add(user);
                }
            }

            var maxSumLength = 0;
            var user1 = "";
            var user2 = "";

            for (var i = 0; i < validUsers.Count - 1; i++)
            {
                var sumLength = validUsers[i].Length + validUsers[i + 1].Length;

                if (sumLength > maxSumLength)
                {
                    maxSumLength = sumLength;

                    user1 = validUsers[i];
                    user2 = validUsers[i + 1];
                }
            }

            Console.WriteLine(user1);
            Console.WriteLine(user2);
        }
    }
}