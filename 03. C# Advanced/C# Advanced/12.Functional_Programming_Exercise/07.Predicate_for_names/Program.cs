using System;
using System.Linq;

namespace _07.Predicate_for_names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, bool> predicate = x =>
            {
                if (x.Length <= n)
                {
                    return true;
                }
                return false;
            };

            names = names.Where(predicate).ToList();

            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
