using System;
using System.Text;
using System.Text.RegularExpressions;

namespace exam2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "TakeOdd")
                {
                    pass = TakeOdd(pass: pass);
                    Console.WriteLine(pass);
                }
                else if (command[0] == "Cut")
                {
                    int startIndex = int.Parse(command[1]);
                    int length = int.Parse(command[2]);

                    StringBuilder newPass = new StringBuilder();
                    newPass.Append(pass.Substring(0, startIndex));
                    newPass.Append(pass.Substring(startIndex + length, pass.Length - length - startIndex));

                    pass = newPass.ToString();
                    Console.WriteLine(pass);

                }

                else if (command[0] == "Substitute")
                {
                    string substring = command[1];
                    string substitute = command[2];
                    if (pass.Contains(substring))
                    {
                        pass = pass.Replace(substring, substitute);
                        Console.WriteLine(pass);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {pass}");

        }

        public static string TakeOdd(string pass)
        {
            StringBuilder newPass = new StringBuilder();

            for (int i = 0; i < pass.Length; i++)
            {
                if (i%2==1)
                {
                    newPass.Append(pass[i]);
                }
            }

            return newPass.ToString();
        }
    }
}
