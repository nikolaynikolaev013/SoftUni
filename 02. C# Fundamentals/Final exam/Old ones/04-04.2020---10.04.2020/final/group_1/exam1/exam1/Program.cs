using System;
using System.Text;

namespace exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder key = new StringBuilder(Console.ReadLine());

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] command = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Contains")
                {
                    if (key.ToString().Contains(command[1]))
                    {
                        Console.WriteLine($"{key} contains {command[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (command[0]=="Flip")
                {
                    int startIndex = int.Parse(command[2]);
                    int endIndex = int.Parse(command[3]);

                    if (command[1] == "Lower")
                    {
                        string substring = key.ToString().Substring(startIndex, endIndex - startIndex);
                        key.Remove(startIndex, endIndex - startIndex);
                        key.Insert(startIndex, substring.ToLower());
                    }
                    else if (command[1] == "Upper")
                    {
                        string substring = key.ToString().Substring(startIndex, endIndex - startIndex);
                        key.Remove(startIndex, endIndex - startIndex);
                        key.Insert(startIndex, substring.ToUpper());
                    }

                    Console.WriteLine(key);
                }


                else if (command[0] == "Slice")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    key.Remove(startIndex, endIndex - startIndex);


                    Console.WriteLine(key);
                }
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
