using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Destination_mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            string pattern = @"(=|\/)(?<location>[A-Z][A-Za-z]{2,})(\1)";

            int numOfValidDestinations = 0;

            List<string> locations = new List<string>();


            MatchCollection validLocations = Regex.Matches(destinations, pattern);

            if (validLocations.Count > 0)
            {
                foreach (Match location in validLocations)
                {
                    numOfValidDestinations += location.Groups["location"].Value.Length;
                    locations.Add(location.Groups["location"].Value);
                }
            }

            Console.WriteLine("Destinations: " + String.Join(", ", locations));
            Console.WriteLine($"Travel Points: {numOfValidDestinations}");
        }
    }
}
