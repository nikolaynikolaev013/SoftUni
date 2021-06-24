using System;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;


        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }

        public Person()
            : this("No name", 1)
        {

        }
        public Person(int age)
            : this("No name", age)
        {
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
