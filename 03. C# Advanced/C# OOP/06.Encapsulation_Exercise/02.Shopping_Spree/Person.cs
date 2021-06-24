using System;
using System.Collections.Generic;

namespace _02.Shopping_Spree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<Product>();
        }

        public string Name {
            get => this.name;
            private set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money {
            get => this.money;
            private set {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Bag { get; private set; }

        public string BuyProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                Bag.Add(product);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            if (this.Bag.Count <= 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {String.Join(", ", this.Bag)}";
        }
    }
}
