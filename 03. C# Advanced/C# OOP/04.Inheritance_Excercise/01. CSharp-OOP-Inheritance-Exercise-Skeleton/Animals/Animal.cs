using System;
namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (String.IsNullOrEmpty(name) || age <= 0 || (gender != "Male" && gender != "Female"))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public abstract string ProduceSound();
    }
}
