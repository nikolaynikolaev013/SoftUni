using System;

namespace Password_Generator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());


            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (char k = 'a'; k < 'a' + l; k++)
                    {
                        for (char r = 'a'; r < 'a' + l; r++)
                        {
                            for (int e = 1; e <= n; e++)
                            {
                                if (e > i && e > j)
                                {
                                    Console.Write($"{i}{j}{k}{r}{e} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
