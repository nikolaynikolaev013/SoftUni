using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();


            string input = String.Empty;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] command = input.Split(" ");
                string productName = command[0];
                double productPrice = double.Parse(command[1]);
                double productQuantity = double.Parse(command[2]);


                if (products.ContainsKey(productName))
                {
                    products[productName][0] = productPrice;
                    products[productName][1] += productQuantity;
                }
                else
                {
                    products.Add(productName, new List<double> { productPrice, productQuantity });
                }
            }

            double totalPrice = 0;

            foreach (var item in products)
            {
                totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:F2}");
            }

        }
    }
}
