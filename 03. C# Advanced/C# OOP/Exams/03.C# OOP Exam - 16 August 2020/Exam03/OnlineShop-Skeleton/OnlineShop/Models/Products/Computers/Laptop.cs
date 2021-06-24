using System;
namespace OnlineShop.Models.Products.Computers
{
    public class Laptop : Computer
    {
        private const int DefaultOverallPerformance = 10;

        public Laptop(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, DefaultOverallPerformance)
        {
        }
    }
}
