using System;
using System.Reflection;

namespace Problem_3.Oldest_Family_Member
{
    class Startup
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }
            var n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                var inputTokens = Console.ReadLine().Split(' ');
                var member = new Person()
                {
                    Name = inputTokens[0],
                    Age = int.Parse(inputTokens[1])
                };
                family.AddMember(member);
            }
            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}
