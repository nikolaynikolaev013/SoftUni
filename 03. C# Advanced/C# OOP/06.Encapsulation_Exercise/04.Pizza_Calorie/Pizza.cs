using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pizza_Calorie
{
    public class Pizza
    {
        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;

        private const int MaxCountOfToppings = 10;

        private string name;

        public Pizza(string name){
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name {
            get => this.name;
            private set {
                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between {MinNameLength} and {MaxNameLength} symbols.");
                }

                this.name = value;
            }
        }
        public List<Topping> Toppings { get; private set; }
        public Dough Dough { get; set; }
        public int NumOfToppings => Toppings.Count;
        public double TotalCalories => this.Dough.TotalCalories + Toppings.Sum(x => x.TotalCalories);

        public void AddTopping(Topping topping)
        {
            if (NumOfToppings >= MaxCountOfToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxCountOfToppings}].");
            }
            this.Toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
