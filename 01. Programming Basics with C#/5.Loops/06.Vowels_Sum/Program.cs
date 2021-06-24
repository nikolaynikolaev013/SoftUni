using System;

namespace Vowels_Sum
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i <= input.Length-1; i++)
            {
                switch (input[i])
                {
                    case 'a': sum += 1; break;
                    case 'e': sum += 2; break;
                    case 'i': sum += 3; break;
                    case 'o': sum += 4; break;
                    case 'u': sum += 5; break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
