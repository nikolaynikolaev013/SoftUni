using System;

namespace Final_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Decode")
            {

                string[] command = input.Split('|');

                switch (command[0])
                {
                    case "Move":
                        message = Move(message: message, command: command);
                        break;
                    case "Insert":
                        message = Insert(message: message, command: command);
                        break;
                    case "ChangeAll":
                        message = ChangeAll(message: message, command: command);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        private static string ChangeAll(string message, string[] command)
        {
            string substring = command[1];
            string replacement = command[2];

            if (message.Contains(substring))
            {
                message = message.Replace(substring, replacement);
            }
            return message;
        }

        private static string Insert(string message, string[] command)
        {
            int index = int.Parse(command[1]);
            string value = command[2];

            if (index >= 0 && index <= message.Length)
            {
                message = message.Insert(index, value);
            }

            return message;
        }

        private static string Move(string message, string[] command)
        {
            int numOfLetters = int.Parse(command[1]);

            if (numOfLetters < message.Length)
            {
                string substring = message.Substring(0, numOfLetters);
                message = message.Remove(0, numOfLetters);
                message += substring;
            }

            return message;
        }
    }
}
