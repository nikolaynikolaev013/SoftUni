using System;

namespace _02.Character_multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(StringMultiplier(str[0], str[1]));
        }

        public static int StringMultiplier(string str1, string str2)
        {
            int totalSum = 0;
            
            for (int i = 0; i < Math.Max(str1.Length, str2.Length); i++)
            {
                if (i >= str1.Length)
                {
                    totalSum += (int)str2[i];
                }
                else if (i >= str2.Length)
                {
                    totalSum += (int)str1[i];
                }
                else
                {
                    totalSum += (int)str1[i] * (int)str2[i];
                }
            }

            return totalSum;
        }
    }
}
