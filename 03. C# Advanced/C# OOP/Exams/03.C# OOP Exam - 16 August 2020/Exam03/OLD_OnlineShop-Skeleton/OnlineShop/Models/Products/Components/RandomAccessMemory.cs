using System;
namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory : Component
    {
        private const double DefaultMultiplier = 1.20;

        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }
        public override double OverallPerformance { get => base.OverallPerformance; protected set => base.OverallPerformance = value * DefaultMultiplier; }
    }
}
