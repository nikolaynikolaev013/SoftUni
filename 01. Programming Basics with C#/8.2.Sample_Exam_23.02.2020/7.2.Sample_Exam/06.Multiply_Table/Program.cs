using System;

namespace Multiply_Table
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string number = Console.ReadLine();

            for (int i = 1; i <= int.Parse(number[2].ToString()); i++)
            {
                for (int j = 1; j <= int.Parse(number[1].ToString()); j++)
                {
                    for (int k = 1; k <= int.Parse(number[0].ToString()); k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i*j*k};");
                    }
                }
            }
        }
    }
}
