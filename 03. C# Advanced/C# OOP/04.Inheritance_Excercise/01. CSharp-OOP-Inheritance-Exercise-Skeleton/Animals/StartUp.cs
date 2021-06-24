using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string animalType = string.Empty;

            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalProps = Console.ReadLine().Split().ToArray();

                try
                {
                    switch (animalType)
                    {
                        case "Cat":
                            animals.Add(new Cat(animalProps[0], int.Parse(animalProps[1]), animalProps[2]));
                            break;
                        case "Dog":
                            animals.Add(new Dog(animalProps[0], int.Parse(animalProps[1]), animalProps[2]));
                            break;
                        case "Frog":
                            animals.Add(new Frog(animalProps[0], int.Parse(animalProps[1]), animalProps[2]));
                            break;
                        case "Kitten":
                            animals.Add(new Cat(animalProps[0], int.Parse(animalProps[1]), String.Empty));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(animalProps[0], int.Parse(animalProps[1]), String.Empty));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound().ToString());
            }
        }
    }
}
