using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private const int DefaultMinCapacity = 0;
        private const int DefaultMinNumOfPeople = 0;

        private ICollection<IFood> FoodOrders;
        private ICollection<IDrink> DrinkOrders;

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.FoodOrders = new List<IFood>();
            this.DrinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < DefaultMinCapacity)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value < DefaultMinNumOfPeople)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => PricePerPerson * NumberOfPeople;


        public void Clear()
        {
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            return this.FoodOrders.Sum(x => x.Price) + this.DrinkOrders.Sum(x => x.Price) + this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson:F2}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
