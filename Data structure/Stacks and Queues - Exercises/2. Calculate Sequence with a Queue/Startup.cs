using System;
using System.Collections.Generic;

namespace _2.Calculate_Sequence_with_a_Queue
{
    public class Startup
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();

            // S1 = n
            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                // Last element get and remove from the queue
                long headOfQue = queue.Dequeue();

                // S2 = S2 + 1
                queue.Enqueue(headOfQue + 1);

                // S3 = 2 * S1 + 1
                queue.Enqueue(headOfQue * 2 + 1);

                // S4 = S1 + 2
                queue.Enqueue(headOfQue + 2);

                Console.Write(headOfQue + (i < 49 ? ", " : string.Empty));
            }

            Console.WriteLine();
        }
    }
}
