using System;
namespace _04.Border_Control
{
    public class Rebel : IPerson, IBuyer
    {
        private const int DefaultFoodValue = 0;

        public Rebel(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; } = DefaultFoodValue;

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
