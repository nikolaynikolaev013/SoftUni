using System;
namespace _04.Border_Control
{
    public class Citizen : IIdentifiable, INamable, IBirthable, IBuyer, IPerson
    {

        private const int DefaultFoodValue = 0;

        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; } = DefaultFoodValue;

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
