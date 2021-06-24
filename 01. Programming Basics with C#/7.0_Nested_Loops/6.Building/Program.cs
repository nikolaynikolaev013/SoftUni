using System;

namespace Building
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int apartaments = int.Parse(Console.ReadLine());

            for (int i = floors; i >= 1; i--)
            {
                for (int j = 0; j < apartaments; j++)
                {
                    if (i == floors)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else if (i % 2 == 0)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else if (i % 2 != 0)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
