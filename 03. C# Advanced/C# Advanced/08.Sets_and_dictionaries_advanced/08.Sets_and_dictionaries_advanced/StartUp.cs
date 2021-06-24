using System;
using System.Collections.Generic;

namespace _08.Sets_and_dictionaries_advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join(Environment.NewLine, set));
        }
    }
}
