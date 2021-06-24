using System;
using System.Text;

namespace exam5
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Make":
                        email = Make(email: email, command: command);
                        break;
                    case "GetDomain":
                        GetDomain(email: email, command: command);
                        break;
                    case "GetUsername":
                        GetUsername(email: email, command: command);
                        break;
                    case "Replace":
                        char ch = char.Parse(command[1]);
                        email = email.Replace(ch, '-');
                        Console.WriteLine(email);
                        break;
                    case "Encrypt":
                        Encrypt(email: email);
                        break;
                }
            }
        }

        private static void Encrypt(string email)
        {
            foreach (var letter in email)
            {
                Console.Write($"{(int)letter} ");
            }
        }

        private static void GetUsername(string email, string[] command)
        {
            if (email.Contains("@"))
            {
                StringBuilder username = new StringBuilder();

                foreach (var letter in email)
                {
                    if (letter == '@')
                    {
                        break;
                    }

                    username.Append(letter);
                }

                Console.WriteLine(username.ToString());
            }
            else
            {
                Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
            }
        }

        private static void GetDomain(string email, string[] command)
        {
            int length = int.Parse(command[1]);
            if (length < email.Length)
            {
                Console.WriteLine(email.Substring(email.Length - length));
            }
        }

        private static string Make(string email, string[] command)
        {
            if (command[1] == "Upper")
            {
                email = email.ToUpper();
            }
            else if (command[1] == "Lower")
            {
                email = email.ToLower();
            }
            Console.WriteLine(email);
            return email;
        }
    }
}
