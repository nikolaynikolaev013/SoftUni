using System;
using _04.Wild_Farm.Models;

namespace _04.Wild_Farm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public FoodFactory()
        {
        }

        public IFood CreateFood(string[] args)
        {
            var type = args[0];
            var quantity = int.Parse(args[1]);

            IFood food = null;
            switch (type)
            {
                case nameof(Fruit):
                    food = new Fruit(quantity);
                    break;
                case nameof(Meat):
                    food = new Meat(quantity);
                    break;
                case nameof(Seeds):
                    food = new Seeds(quantity);
                    break;
                case nameof(Vegetable):
                    food = new Vegetable(quantity);
                    break;
            }
            return food;
        }
    }
}
