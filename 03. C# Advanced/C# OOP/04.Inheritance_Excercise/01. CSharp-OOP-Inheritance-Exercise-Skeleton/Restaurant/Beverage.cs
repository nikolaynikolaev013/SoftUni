using System;
namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double ml) : base(name, price)
        {
            this.Milliters = ml;
        }

        public double Milliters { get; set; }
    }
}
