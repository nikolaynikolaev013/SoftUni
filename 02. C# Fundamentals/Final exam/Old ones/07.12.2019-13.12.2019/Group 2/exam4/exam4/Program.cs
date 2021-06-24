using System;

namespace exam4
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Finish")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int startIndex = 0;
                int endIndex = 0;

                switch (command[0])
                {

                    case "Replace":
                        char currentChar = char.Parse(command[1]);
                        char newChar = char.Parse(command[2]);

                        message = message.Replace(currentChar, newChar);
                        Console.WriteLine(message);
                        break;

                    case "Cut":
                        startIndex = int.Parse(command[1]);
                        endIndex = int.Parse(command[2]);

                        if (startIndex < 0 || startIndex >= message.Length || endIndex < 0 || endIndex >= message.Length)
                        {
                            Console.WriteLine("Invalid indexes!");
                            continue;
                        }

                        message = message.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(message);
                        break;

                    case "Make":
                        if (command[1] == "Upper")
                        {
                            message = message.ToUpper();
                        }
                        else if (command[1] == "Lower")
                        {
                            message = message.ToLower();
                        }
                        Console.WriteLine(message);
                        break;

                    case "Check":
                        string substringToCheck = command[1];

                        if (message.Contains(substringToCheck))
                        {
                            Console.WriteLine($"Message contains {substringToCheck}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {substringToCheck}");
                        }
                        break;

                    case "Sum":
                        startIndex = int.Parse(command[1]);
                        endIndex = int.Parse(command[2]);

                        if (startIndex < 0 || startIndex >= message.Length || endIndex < 0 || endIndex >= message.Length)
                        {
                            Console.WriteLine("Invalid indexes!");
                            continue;
                        }

                        string substring = message.Substring(startIndex, endIndex - startIndex + 1);

                        int sum = 0;

                        foreach (var letter in substring)
                        {
                            sum += (int)letter;
                        }

                        Console.WriteLine(sum);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
