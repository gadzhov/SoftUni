namespace _10.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        private static Stack<Stack<char>> tempStack;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<char>();
            tempStack = new Stack<Stack<char>>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        var text = input[1];
                        foreach (var ch in text)
                        {
                            stack.Push(ch);
                        }
                        Backup(stack);
                        break;
                    case 2:
                        var count = int.Parse(input[1]);
                        if (stack.Count > 0)
                        {
                            for (int j = 0; j < count; j++)
                            {
                                stack.Pop();
                            }
                            Backup(stack);
                        }
                        break;
                    case 3:
                        var index = int.Parse(input[1]);
                        var counter = stack.Count;
                        foreach (var el in stack)
                        {
                            if (counter == index)
                            {
                                Console.WriteLine(el);
                                break;
                            }
                            counter--;
                        }
                        break;
                    case 4:
                        stack.Clear();
                        if (tempStack.Count > 0)
                        {
                            tempStack.Pop();
                            //stack = tempStack.Pop();
                            stack = new Stack<char>(tempStack.Peek());
                        }
                        break;
                }
            }
        }

        private static void Backup(Stack<char> stack)
        {
            var t = new Stack<char>();
            foreach (var s in stack)
            {
                t.Push(s);
            }

            tempStack.Push(t);
        }
    }
}
