using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Cubic_s_Rube
{
    class Startup
    {
        static void Main(string[] args)
        {
            var dimension = int.Parse(Console.ReadLine());
            string input;
            var cube = new long[dimension][][];
            var particlesToApply = new HashSet<long[]>();

            while ((input = Console.ReadLine()) != "Analyze")
            {
                particlesToApply.Add(input
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray());
            }

            // Init Cube
            for (int x = 0; x < cube.Length; x++)
            {
                cube[x] = new long[dimension][];
                for (int y = 0; y < cube[x].Length; y++)
                {
                    cube[x][y] = new long[dimension];
                }
            }

            foreach (var ele in particlesToApply)
            {
                var x = ele[0];
                var y = ele[1];
                var z = ele[2];
                var particle = ele[3];

                try
                {
                    cube[x][y][z] = particle;
                }
                catch 
                {
                    // ignore
                }
            }
            long sum = 0;
            var notChanged = 0;

            for (int x = 0; x < cube.Length; x++)
            {
                for (int y = 0; y < cube[x].Length; y++)
                {
                    for (int z = 0; z < cube[x][y].Length; z++)
                    {
                        if (cube[x][y][z] != 0)
                        {
                            sum += cube[x][y][z];
                        }
                        else
                        {
                            notChanged++;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(notChanged);
        }
    }
}
