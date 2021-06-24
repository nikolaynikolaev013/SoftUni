using System;
using System.Text.RegularExpressions;

namespace _02.Message_translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})\]";

            int numOfMessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfMessages; i++)
            {
                string message = Console.ReadLine();

                Match match = Regex.Match(message, pattern);

                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string messageToEncrypt = match.Groups["message"].Value;

                    Console.Write($"{command}: ");

                    foreach (var letter in messageToEncrypt)
                    {
                        Console.Write($"{(int)letter} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
