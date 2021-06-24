using System;
using _04.Wild_Farm.Models;

namespace _04.Wild_Farm.Factories
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] args);
    }
}
