using System;
using System.Collections.Generic;
using System.Linq;
using _04.Wild_Farm.Factories;
using _04.Wild_Farm.Factories.Animal;
using _04.Wild_Farm.IO;
using _04.Wild_Farm.Models.Animals;

namespace _04.Wild_Farm.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;

        public Engine(IWriter writer, IReader reader, IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
        }

        public void Run()
        {
            List<IAnimal> animals = new List<IAnimal>();

            string input = String.Empty;

            while ((input = reader.ReadLine()) != "End")
            {

                var animalArgs = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                var foodArgs = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var animal = animalFactory.CreateAnimal(animalArgs);
                var food = foodFactory.CreateFood(foodArgs);

                writer.WriteLine(animal.AskForFood());
                animals.Add(animal);

                try
                {
                    animal.Feed(food);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
                
            }

            writer.WriteLine(String.Join(Environment.NewLine, animals));
        }
    }
}
