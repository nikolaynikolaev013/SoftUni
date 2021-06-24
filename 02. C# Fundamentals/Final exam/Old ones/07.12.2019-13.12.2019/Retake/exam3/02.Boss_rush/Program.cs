using System;
using System.Text.RegularExpressions;

namespace _02.Boss_rush
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Za-z]+\s[A-Za-z]+)#";

            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["boss"]}, The {match.Groups["title"]}");
                    Console.WriteLine($">> Strength: {match.Groups["boss"].Length}");
                    Console.WriteLine($">> Armour: {match.Groups["title"].Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
