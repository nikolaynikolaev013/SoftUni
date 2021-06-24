using System;
using System.Linq;
using System.Text;

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder message = new StringBuilder(Console.ReadLine().ToString());

            string input = String.Empty;


            while ((input = Console.ReadLine())!= "Reveal")
            {
                string[] command = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "InsertSpace")
                {
                    byte index = byte.Parse(command[1]);

                    message.Insert(index, " ");
                }

                else if (command[0] == "Reverse")
                {
                    string substring = command[1];

                    if (message.ToString().Contains(substring))
                    {
                        string reversedSubstring = reverseString(substring);
                        message.Remove(message.ToString().IndexOf(substring), substring.Length);
                        message.Append(reversedSubstring);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }

                else if (command[0] == "ChangeAll")
                {
                    string substring = command[1];
                    string replaceString = command[2];

                    if (message.ToString().Contains(substring))
                    {
                        message.Replace(substring, replaceString);
                    }
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        public static string reverseString(string originalString)
        {
            StringBuilder newString = new StringBuilder();

            for (int i = 0; i < originalString.Length; i++)
            {
                newString.Append(originalString[originalString.Length - 1 - i]);
            }

            return newString.ToString();
        }
    }
}
