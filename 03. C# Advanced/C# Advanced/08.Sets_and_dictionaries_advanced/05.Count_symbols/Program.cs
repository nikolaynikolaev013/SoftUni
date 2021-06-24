using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Count_symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            var dict = new SortedDictionary<char, int>();

            foreach (var letter in text)
            {
                if (dict.ContainsKey(letter))
                {
                    dict[letter]++;
                }
                else
                {
                    dict.Add(letter, 1);
                }
            }

            foreach (var letter in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}
