using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pizza_Calorie
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var pizzaName = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var pizza = new Pizza(pizzaName[1]);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                    switch (command[0])
                    {
                        case "Dough":
                            pizza.Dough = new Dough(command[1], command[2], double.Parse(command[3]));
                            break;
                        case "Topping":
                            pizza.AddTopping(new Topping(command[1], double.Parse(command[2])));
                            break;
                        default:
                            break;
                    }
            }

            Console.WriteLine(pizza.ToString());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
