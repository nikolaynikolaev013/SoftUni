using System;

namespace _04.Sum_of_char
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort n = ushort.Parse(Console.ReadLine());
            int sum = 0;
            char ch = '\0';

            for (int i = 0; i < n; i++)
            {
                ch = char.Parse(Console.ReadLine());
                sum += (int)ch;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
