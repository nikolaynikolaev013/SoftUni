using System;
using System.Text;

namespace _07.String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            int power = 0;
            StringBuilder newStr = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    newStr.Append(current);
                }
                else if (power == 0)
                {
                    newStr.Append(current);
                }
                else
                {
                    power--;
                }

            }

            Console.WriteLine(newStr.ToString());
        }
    }
}
