using System;
using System.Text.RegularExpressions;

namespace _02.Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());

            string pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}[-A-Za-z0-9]*?[0-9])P@\$";

            string input = String.Empty;
            int counter = 0;


            for (int i = 0; i < numOfInputs; i++)
            {
                input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["username"]}, Password: {match.Groups["password"]}");
                    counter++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {counter}");
        }
    }
}
