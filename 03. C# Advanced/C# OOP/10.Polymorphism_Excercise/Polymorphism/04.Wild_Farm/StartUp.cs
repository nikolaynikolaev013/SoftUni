using System;
using _04.Wild_Farm.Core;
using _04.Wild_Farm.Factories;
using _04.Wild_Farm.Factories.Animal;
using _04.Wild_Farm.IO;

namespace _04.Wild_Farm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            Engine engine = new Engine(writer, reader, foodFactory, animalFactory);

            engine.Run();
        }
    }
}
