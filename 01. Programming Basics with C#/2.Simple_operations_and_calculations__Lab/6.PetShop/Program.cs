using System;

namespace PetShop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numOfDogs = int.Parse(Console.ReadLine());
            int numOfOtherAnimal = int.Parse(Console.ReadLine());

            Console.WriteLine($"{(double)numOfDogs*2.5+numOfOtherAnimal*4:f2} lv.");

        }
    }
}
