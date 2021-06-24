using System;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
    public abstract class Food : IFood
    {
        private const int DefaultMinimumPortion = 0;
        private const decimal DefaultMinimumPrice = 0.0m;

        private string name;
        private int portion;
        private decimal price;

        protected Food(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;
            private set
            {
                if (value <= DefaultMinimumPortion)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }
                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= DefaultMinimumPrice)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }


        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price:F2}";
        }
    }
}
