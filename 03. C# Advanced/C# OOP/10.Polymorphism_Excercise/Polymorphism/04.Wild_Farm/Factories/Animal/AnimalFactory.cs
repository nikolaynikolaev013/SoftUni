using System;
using _04.Wild_Farm.Models.Animals;
using _04.Wild_Farm.Models.Animals.Birds;
using _04.Wild_Farm.Models.Animals.Mammals;
using _04.Wild_Farm.Models.Animals.Mammals.Felines;

namespace _04.Wild_Farm.Factories.Animal
{
    public class AnimalFactory : IAnimalFactory
    {
        public AnimalFactory()
        {
        }

        public IAnimal CreateAnimal(string[] args)
        {
            var type = args[0];
            var name = args[1];
            var weight = double.Parse(args[2]);

            IAnimal animal = null;

            if (type == nameof(Owl) || type == nameof(Hen))
            {
                var wingSize = double.Parse(args[3]);

                if (type == nameof(Owl))
                {
                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == nameof(Hen))
                {
                    animal = new Hen(name, weight, wingSize);
                }
            }

            else if (type == nameof(Mouse) || type == nameof(Dog)
                || type == nameof(Cat) || type == nameof(Tiger))
            {
                string livingRegion = args[3];

                if (type == nameof(Cat) || type == nameof(Tiger))
                {
                    string breed = args[4];

                    if (type== nameof(Cat))
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == nameof(Tiger))
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }

                else if (type == nameof(Mouse))
                {
                    animal = new Mouse(name, weight, livingRegion);
                }

                else if (type == nameof(Dog))
                {
                    animal = new Dog(name, weight, livingRegion);
                }
            }

            return animal;
        }
    }
}
