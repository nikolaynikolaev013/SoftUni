using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Snake snake = new Snake(name);
        }
    }
}