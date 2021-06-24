using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Order_by_age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(command[0], command[1], byte.Parse(command[2])));
            }

            Console.WriteLine(String.Join(Environment.NewLine, people.OrderBy(x=>x.Age)));

        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public byte Age { get; set; }

        public Person(string name, string id, byte age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public override string ToString()
        {

            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
