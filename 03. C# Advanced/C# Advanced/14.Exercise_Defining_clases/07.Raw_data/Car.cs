using System;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, int speed, int power, int weight, string type, double[] pressure, int[] age)
        {
            this.Model = model;
            this.Engine = new Engine(speed, power);
            this.Cargo = new Cargo(weight, type);
            for (int i = 0; i < Tires.Length; i++)
            {
                this.Tires[i] = new Tire(pressure[i], age[i]);
            }
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; } = new Tire[4];

        public override string ToString()
        {
            return this.Model;
        }

    }
}
