using System;

namespace _02.Vowels_count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(VowelsCount(input.ToLower()));

        }

        static int VowelsCount(string str)
        {
            int counter = 0;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            for (int i = 0; i < str.Length; i++)
            {
                counter += CheckForVowel(str[i], vowels);
            }

            return counter;
        }

        static int CheckForVowel(char ch, char[] vowelsArr)
        {

            for (int i = 0; i < vowelsArr.Length; i++)
            {
                if (ch == vowelsArr[i])
                {
                    return 1;
                }

            }
            return 0;
        }
    }
}
