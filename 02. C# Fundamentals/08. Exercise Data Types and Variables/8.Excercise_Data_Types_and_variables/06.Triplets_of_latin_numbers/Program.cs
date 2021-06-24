using System;

namespace _06.Triplets_of_latin_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char a = (char)('a' + i);
                        char b = (char)('a' + j);
                        char c = (char)('a' + k);
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
