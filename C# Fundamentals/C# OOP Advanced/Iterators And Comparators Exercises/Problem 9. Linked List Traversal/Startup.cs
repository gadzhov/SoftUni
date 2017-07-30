using System;
using Problem_9.Linked_List_Traversal.Generics;

namespace Problem_9.Linked_List_Traversal
{
    public class Startup
    {
        public static void Main()
        {
            var linkedList = new MyLinkedList<int>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Add":
                        linkedList.Add(int.Parse(tokens[1]));
                        break;

                    case "Remove":
                        var number = int.Parse(tokens[1]);
                        var removeIndex = linkedList.FirstIndexOf(number);
                        if (removeIndex > -1)
                        {
                            linkedList.Remove(linkedList.FirstIndexOf(number));
                        }
                        break;

                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}
