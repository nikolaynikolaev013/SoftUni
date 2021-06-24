using System;

namespace Sum_Prime_Non_Prime
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            int temp = 0;

            int sumPrime = 0;
            int sumNonPrime = 0;

            bool prime = false;

            while (command != "stop")
            {
                temp = int.Parse(command);

                if (temp < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {

                    for (double i = 2.0; i < temp; i++)
                    {
                        if ((temp / i) == (int)(temp / i))
                        {
                            prime = true;
                            break;
                        }
                    }

                    if (prime)
                    {
                        prime = false;
                        sumPrime += temp;
                    }
                    else
                    {
                        sumNonPrime += temp;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumNonPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumPrime}");
        }
    }
}
