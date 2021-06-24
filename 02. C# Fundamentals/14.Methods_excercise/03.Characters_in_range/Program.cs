using System;

namespace _03.Characters_in_range
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch1 = char.Parse(Console.ReadLine());
            char ch2 = char.Parse(Console.ReadLine());
            char[] arr = { ch1, ch2 };

            CheckForCharsInBetween(arr);

        }

        static void CheckForCharsInBetween(char[] ch)
        {
            if ((int)ch[0] < (int)ch[1])
            {
                for (char i = (char)((int)ch[0] + 1); i < ch[1]; i++)
                {
                    Console.Write(i + " ");
                }
            }
            else
            {
                for (char i = (char)((int)ch[1] + 1); i < ch[0]; i++)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
