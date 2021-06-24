using System;
using System.Collections.Generic;
using _04.Wild_Farm.Models.Animals.Birds;
using _04.Wild_Farm.Models.Animals.Mammals;
using _04.Wild_Farm.Models.Animals.Mammals.Felines;
using _04.Wild_Farm.Utilities;

namespace _04.Wild_Farm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string Sound { get; }

        public abstract List<string> FavFood { get; }

        public abstract double WeightGainForKG { get; }

        public string AskForFood()
        {
            return this.Sound;
        }

        public void Feed(IFood food)
        {
            if (!this.FavFood.Contains(food.GetType().Name))
            {
                string msg = String.Format(Exceptions.InvalidFoodException,this.GetType().Name, food.GetType().Name);
                throw new ArgumentException(msg);
            }
            
            this.Weight += food.Quality * this.WeightGainForKG;
            this.FoodEaten += food.Quality;
        }
    }
}
