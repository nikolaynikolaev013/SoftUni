using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"[a-zA-Z]+";
            string distancePattern = @"\d";

            Dictionary<string, double> participants = new Dictionary<string, double>();
            string[] part = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end of race")
            {
                string name = String.Concat(Regex.Matches(input, namePattern));

                if (part.Contains(name))
                {
                    double km = Regex.Matches(input, distancePattern).Select(x => int.Parse(x.Value)).Sum();
                    if (participants.ContainsKey(name))
                    {
                        participants[name] += km;
                    }
                    else
                    {
                        participants.Add(name, km);
                    }
                }

            }

            var sorted = participants.OrderByDescending(x => x.Value).Select(x=>x.Key).ToList();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");

        }
    }
}
