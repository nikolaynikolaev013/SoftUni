using System;

namespace Walking
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            double sum = 0;

            while (command != "Going home")
            {
                if (command != "Going home")
                {
                    sum += double.Parse(command);

                    if (sum >= 10000)
                    {
                        break;
                    }

                    command = Console.ReadLine();
                }

                if (command == "Going home")
                {
                    command = Console.ReadLine();
                    sum += double.Parse(command);
                    break;
                }

            }

            if (command == "Going home")
            {
                command = Console.ReadLine();
                sum += double.Parse(command);
            }
            if (sum >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{10000 - sum} more steps to reach goal.");
            }
        }
    }
}