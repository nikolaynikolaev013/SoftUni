using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfMessages = int.Parse(Console.ReadLine());

            string pattern = @"@(?<planetName>[A-Za-z]+)[^@\-!:>]*?:(?<population>\d+)[^@\-!:>]*?!(?<attackType>[AaDd])![^@\-!:>]*?->(?<soldierCount>\d+)";

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            for (int i = 0; i < numOfMessages; i++)
            {
                string input = Console.ReadLine();

                string decodedString = DecryptString(input);

                Match match = Regex.Match(decodedString, pattern);

                if (match.Success)
                {
                    string planet = match.Groups["planetName"].Value;
                    int population = int.Parse(match.Groups["population"].Value);
                    string attackType = match.Groups["attackType"].Value;
                    int soldierCount = int.Parse(match.Groups["soldierCount"].Value);

                    if (attackType.ToLower() == "a")
                    {
                        attackedPlanets.Add(planet);
                    }
                    else if (attackType.ToLower() == "d")
                    {
                        destroyedPlanets.Add(planet);
                    }
                }

            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                var sorted = attackedPlanets.OrderBy(x => x).ToList();

                foreach (var item in sorted)
                {
                    Console.WriteLine($"-> {item}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                var sorted = destroyedPlanets.OrderBy(x => x).ToList();

                foreach (var item in sorted)
                {
                    Console.WriteLine($"-> {item}");
                }
            }

        }


        public static string DecryptString(string input)
        {

            int lettersCount = 0;
            foreach (var letter in input)
            {
                if (Regex.IsMatch(letter.ToString().ToLower(), @"[star]"))
                {
                    lettersCount++;
                }
            }

            StringBuilder newInput = new StringBuilder();
            foreach (var letter in input)
            {
                newInput.Append((char)((int)letter - lettersCount));
            }

            return newInput.ToString();
        }
    }
}
