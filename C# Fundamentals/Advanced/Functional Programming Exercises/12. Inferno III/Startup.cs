using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem_12.S_Inferno_III
{
    class Program
    {
        static void Main(string[] args)
        {
            var gems = new List<int> {0};
            gems.AddRange(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            gems.Add(0);
            var command = Console.ReadLine();
            var commandHistory = new List<string>();

            while (command != "Forge")
            {

                var commands = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var comm = commands[0];
                var filter = commands[1];
                var parameter = commands[2];

                if (comm == "Exclude")
                {
                    commandHistory.Add(filter + ";" + parameter);
                }

                if (comm == "Reverse")
                {
                    commandHistory.Remove(filter + ";" + parameter);
                }

                command = Console.ReadLine();
            }

            var indexToRemove = new HashSet<int>();
            if (gems.Count > 2)
            {
                foreach (var row in commandHistory)
                {
                    var commands = row.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var filter = commands[0];
                    var parameter = commands[1];

                    switch (filter)
                    {
                        //"Starts with", "Ends with", "Length" and "Contains". 
                        case "Sum Left":
                            List<int> temp1 = SumLeft(gems, parameter);
                            indexToRemove.UnionWith(temp1);
                            break;
                        case "Sum Right":
                            List<int> temp2 = SumRight(gems, parameter);
                            indexToRemove.UnionWith(temp2);
                            break;
                        case "Sum Left Right":
                            List<int> temp3 = SumLeftRight(gems, parameter);
                            indexToRemove.UnionWith(temp3);
                            break;

                    }
                }
            }

            gems.RemoveAt(gems[0]);
            gems.RemoveAt(gems.Count - 1);


            foreach (var index in indexToRemove)
            {

                gems[index - 1] = 999999999;
            }



            if (gems.Count > 0)
            {
                Console.WriteLine(string.Join(" ", gems.Where(x => x != 999999999)));
            }
        }
        private static List<int> SumLeftRight(List<int> gems, string parameter)
        {
            var toRemove = new List<int>();
            for (var i = 1; i < gems.Count - 1; i++)
            {
                if (gems[i - 1] + gems[i] + gems[i + 1] == int.Parse(parameter))
                {
                    toRemove.Add(i);
                }
            }

            return toRemove;
        }

        private static List<int> SumRight(List<int> gems, string parameter)
        {
            var toRemove = new List<int>();
            for (var i = 1; i < gems.Count - 1; i++)
            {
                if (gems[i] + gems[i + 1] == int.Parse(parameter))
                {
                    toRemove.Add(i);
                }
            }

            return toRemove;
        }

        private static List<int> SumLeft(List<int> gems, string parameter)
        {
            var toRemove = new List<int>();
            for (var i = 1; i < gems.Count - 1; i++)
            {
                if (gems[i - 1] + gems[i] == int.Parse(parameter))
                {
                    toRemove.Add(i);
                }
            }

            return toRemove;
        }
    }
}