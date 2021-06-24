using System;

namespace Cake
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            int area = w * l;
            int pieces = 0;

            string command = Console.ReadLine();

            while (command != "STOP")
            {
                if (command != "STOP")
                {
                    pieces += int.Parse(command);

                    if (pieces > area)
                    {
                        Console.WriteLine($"No more cake left! You need {pieces - area} pieces more.");
                        break;
                    }

                    command = Console.ReadLine();
                }

            }

            if (command == "STOP")
            {
                Console.WriteLine($"{area - pieces} pieces are left.");
            }
        }
    }
}
