using System;
using _04.Wild_Farm.Models.Animals;

namespace _04.Wild_Farm.Factories.Animal
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] args);
    }
}
