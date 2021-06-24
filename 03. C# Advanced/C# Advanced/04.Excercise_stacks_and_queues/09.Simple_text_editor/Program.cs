using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.Simple_text_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder();
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();
            stack.Push(builder.ToString());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                switch (command[0])
                {

                    case "1":
                        var input = command[1];

                        builder.Append(input);
                        stack.Push(builder.ToString());
                        break;

                    case "2":
                        var count = int.Parse(command[1]);

                        builder.Remove(builder.Length - count, count);
                        stack.Push(builder.ToString());
                        break;

                    case "3":
                        var index = int.Parse(command[1]);
                        Console.WriteLine(builder[index - 1]);
                        break;
                    case "4":
                        stack.Pop();
                        builder = new StringBuilder(stack.Peek());
                        break;

                }
            }
        }
    }
}
