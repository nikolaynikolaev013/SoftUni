using System;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private const int DefaultMinIDValue = 0;
        private const int DefaultMinPriceValue = 0;
        private const int DefaultOverallPerformanceValue = 0;

        private int id;
        private string manufacturer;
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
                if (value <= DefaultMinIDValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                this.id = value;
            }
        }
        public string Manufacturer
        {
            get => this.manufacturer;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                this.manufacturer = value;
            }
        }
        public string Model
        {
            get => this.model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                this.model = value;
            }
        }
        public virtual decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= DefaultMinPriceValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }
        public virtual double OverallPerformance
        {
            get => this.overallPerformance;
            private set
            {
                if (value <= DefaultOverallPerformanceValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.overallPerformance = value;
            }
        }


        public override string ToString()
        {
            return String.Format(SuccessMessages.ProductToString, $"{this.OverallPerformance:F2}", $"{this.Price, 2:F2}", this.GetType().Name, this.Manufacturer, this.Model, this.Id);
        }
    }
}
