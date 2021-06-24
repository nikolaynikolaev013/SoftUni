using System;
namespace OnlineShop.Models.Products.Computers
{
    public class DesktopComputer : Computer
    {
        private const double DefaultMultiplier = 15;

        public DesktopComputer(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price)
        {
        }
        public override double OverallPerformance { get => base.OverallPerformance; protected set => base.OverallPerformance = value * DefaultMultiplier; }
    }
}
