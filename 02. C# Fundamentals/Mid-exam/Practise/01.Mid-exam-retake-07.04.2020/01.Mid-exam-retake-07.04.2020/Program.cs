using System;

namespace _01.Mid_exam_retake_07._04._2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            string input = String.Empty;
            int wonBattles = 0;

            while ((input = Console.ReadLine()) != "End of battle")
            {
                int distance = int.Parse(input);

                if (distance > 0)
                {
                    if (wonBattles > 0 && wonBattles % 3 == 0)
                    {
                        initialEnergy += wonBattles;
                    }


                    if (initialEnergy - distance < 0)
                    {
                        Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
                        return;
                    }

                    else if (initialEnergy >= distance)
                    {
                        wonBattles++;
                        initialEnergy -= distance;
                    }
                }
            }

            Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
        }
    }
}
