using System;

namespace OWn_Business
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
             double totalArea = width * length * height;

            string command = Console.ReadLine();

            int numOfComputers = 0;
            bool noMoreSpace = false;


            while (command != "Done")
            {
                numOfComputers += int.Parse(command);

                if (numOfComputers >= totalArea)
                {
                    noMoreSpace = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (noMoreSpace)
            {
                Console.WriteLine($"No more free space! You need {numOfComputers - totalArea} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{totalArea - numOfComputers} Cubic meters left.");
            }
        }
    }
}
