using System;
using System.Collections.Generic;
using System.Linq;

namespace _25.Exercise_Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (var letter in text)
            {
                if (letter != ' ')
                {
                    if (letters.ContainsKey(letter))
                    {
                        letters[letter]++;
                    }
                    else
                    {
                        letters.Add(letter, 1);
                    }
                }
            }


            foreach (var letter in letters)
            {
                Console.WriteLine(letter.Key + " -> " + letter.Value);
            }
        }
    }
}
