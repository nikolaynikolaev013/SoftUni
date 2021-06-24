using System;
using System.Collections.Generic;

namespace _04.Wild_Farm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const string DefaultDogSound = "Woof!";
        private const double DefaultWeightGainForKG = 0.40;

        private List<string> defaultFavFood = new List<string>() { "Meat" };

        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override string Sound => DefaultDogSound;

        public override List<string> FavFood => this.defaultFavFood;

        public override double WeightGainForKG => DefaultWeightGainForKG;
    }
}
