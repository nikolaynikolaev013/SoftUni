using System;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufaacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this.id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id can not be less or equal than 0.");
                }
                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufaacturer;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty");
                }
                this.manufaacturer = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");
                }
                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => this.overallPerformance;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.overallPerformance = value;
            }
        }

        public override string ToString()
        {
            //TODO:Check that??
            return $"Overall Performance: {this.OverallPerformance:F2}. Price: {this.Price:F2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})";
        }
    }
}
