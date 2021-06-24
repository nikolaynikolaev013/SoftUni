using System;

namespace Math_Puzzle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 30; j++)
                {
                    for (int k = 1; k <= 30; k++)
                    {
                        if (j > i && k > j && i + j + k == key)
                        {
                            Console.WriteLine($"{i} + {j} + {k} = {i + j + k}");
                            counter++;
                        }

                        if (k < j && j < i && i * j * k == key)
                        {
                            Console.WriteLine($"{i} * {j} * {k} = {i*j*k}");
                            counter++;
                        }
                    }
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
