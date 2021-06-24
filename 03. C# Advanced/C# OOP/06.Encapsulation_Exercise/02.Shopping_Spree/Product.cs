using System;
namespace _02.Shopping_Spree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name { get => this.name;
            private set {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Cost { get => this.cost;
            private set {
                if (value < 0)
                {
                    throw new ArgumentException("");
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
