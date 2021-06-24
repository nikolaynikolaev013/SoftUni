using System;
using System.Text;

namespace _06.Replace_repeating_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i-1] == input[i])
                {
                    input.Remove(i, 1);
                    i--;
                }
            }

            Console.WriteLine(input.ToString());
        }
    }
}
