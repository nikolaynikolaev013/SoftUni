using System;

namespace Numbers_1_n_Step_3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
