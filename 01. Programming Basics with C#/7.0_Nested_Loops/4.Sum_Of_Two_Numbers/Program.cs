using System;

namespace Sum_Of_Two_Numbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int counter = 0;
            int firstNum = 0;
            int secondNum = 0;

            bool done = false;

            for (int i = min; i <= max; i++)
            {
                for (int j = min; j <= max; j++)
                {
                    counter++;
                    if (i+j == magicNum)
                    {
                        done = true;
                        firstNum = i;
                        secondNum = j;
                        break;
                    }
                }
                if (done)
                {
                    break;
                }
            }

            if (done)
            {
                Console.WriteLine($"Combination N:{counter} ({firstNum} + {secondNum} = {magicNum})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
        }
    }
}
