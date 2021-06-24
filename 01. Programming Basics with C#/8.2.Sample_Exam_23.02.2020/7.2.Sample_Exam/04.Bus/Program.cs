using System;

namespace Bus
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numOfPassagers = int.Parse(Console.ReadLine());
            int numOfStops = int.Parse(Console.ReadLine());

            int temp = 0;


            for (int i = 1; i <= numOfStops; i++)
            {
                temp = int.Parse(Console.ReadLine());

                numOfPassagers -= temp;

                temp = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    numOfPassagers -= 2;
                    numOfPassagers += temp;
                }
                else
                {
                    numOfPassagers += temp + 2;
                }
            }


            Console.WriteLine($"The final number of passengers is : {numOfPassagers}");
        }
    }
}
