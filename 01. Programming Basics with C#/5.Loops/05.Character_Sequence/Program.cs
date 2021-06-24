using System;

namespace Character_Sequence
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i <= input.Length - 1; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
