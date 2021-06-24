using System;
namespace _04.Wild_Farm.Models
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quality = quantity;
        }

        public int Quality { get; }
    }
}
