using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        string Sound { get; }
        List<string> FavFood { get; }
        double WeightGainForKG { get; }

        string AskForFood();
        void Feed(IFood food);
    }
}
