using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            var univInput = Console.ReadLine()
                ;

            foreach (var record in univInput.Split(";").ToArray())
            {
                try
                {
                    var props = record.Split("=");
                    people.Add(new Person(props[0], double.Parse(props[1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            univInput = Console.ReadLine();

            foreach (var record in univInput.Split(";").ToArray())
            {
                try
                {
                    if (!String.IsNullOrEmpty(record))
                    {
                        var props = record.Split("=");
                        products.Add(new Product(props[0], double.Parse(props[1])));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            univInput = String.Empty;

            while ((univInput = Console.ReadLine()) != "END")
            {
                var command = univInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = command[0];
                var product = command[1];

                if (people.Any(x=>x.Name == name) && products.Any(x=>x.Name == product))
                {
                    Console.WriteLine(people.First(x=>x.Name == name).BuyProduct(products.First(x=>x.Name == product)));
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, people));
        }
    }
}
