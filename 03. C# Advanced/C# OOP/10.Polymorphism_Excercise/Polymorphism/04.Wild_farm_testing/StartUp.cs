using System;
using _04.Wild_Farm.Models;
using _04.Wild_Farm.Models.Animals;
using _04.Wild_Farm.Models.Animals.Mammals;
using NUnit.Framework;

namespace _04.Wild_farm_testing
{
    [TestFixture]
    class StartUp
    {
        private IAnimal animal;
        private IFood food;

        public void Initialise()
        {
        }

        [Test]
        public void TestDog()
        {
            animal = new Dog("Pesho", 2.2, "Varna");
            food = new Meat(2);

            animal.AskForFood();
            animal.Feed(food);

            Assert.That(animal.FoodEaten, Is.EqualTo(food.Quality));

        }
    }
}
