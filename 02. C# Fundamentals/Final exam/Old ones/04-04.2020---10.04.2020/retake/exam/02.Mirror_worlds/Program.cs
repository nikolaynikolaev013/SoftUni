using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Mirror_worlds
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([#@])(?<word1>[A-Za-z]{3,})\1{2}(?<word2>[A-Za-z]{3,})\1";

            List<string> words = new List<string>();

            var matches = Regex.Matches(text, pattern);

            if (matches.Count > 0)
            {
                int count = 0;

                Console.WriteLine($"{matches.Count} word pairs found!");

                foreach (Match match in matches)
                {
                    string word1 = match.Groups["word1"].Value;
                    string word2 = match.Groups["word2"].Value;

                    if (word1 == ReverseString(word2))
                    {
                        words.Add($"{word1} <=> {word2}");
                        count++;
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("No mirror words!");
                }
                else
                {
                    Console.WriteLine("The mirror words are:");

                    Console.Write(String.Join(", ", words));
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }

        public static string ReverseString(string input)
        {
            StringBuilder newString = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                newString.Append(input[input.Length - i - 1]);
            }

            return newString.ToString();
        }
    }
}
