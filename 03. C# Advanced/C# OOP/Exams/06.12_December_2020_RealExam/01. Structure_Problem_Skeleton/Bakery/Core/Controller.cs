using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            this.bakedFoods = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Enum.TryParse(type, out DrinkType typeEnum);

            IDrink drink = null;

            switch (typeEnum)
            {
                case DrinkType.Tea:
                    drink = new Tea(name, portion, brand);
                    break;
                case DrinkType.Water:
                    drink = new Water(name, portion, brand);
                    break;
            }

            if (drink != null)
            {
                this.drinks.Add(drink);
                return String.Format(OutputMessages.DrinkAdded, name, brand);
            }
            else
            {
                return null;
            }
        }

        public string AddFood(string type, string name, decimal price)
        {
            Enum.TryParse(type, out BakedFoodType typeEnum);

            IFood food = null;

            switch (typeEnum)
            {
                case BakedFoodType.Bread:
                    food = new Bread(name, price);
                    break;
                case BakedFoodType.Cake:
                    food = new Cake(name, price);
                    break;
            }

            if (food != null)
            {
                this.bakedFoods.Add(food);
                return String.Format(OutputMessages.FoodAdded, name, type);
            }
            else
            {
                return null;
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Enum.TryParse(type, out TableType typeEnum);

            ITable table = null;

            switch (typeEnum)
            {
                case TableType.InsideTable:
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case TableType.OutsideTable:
                    table = new OutsideTable(tableNumber, capacity);
                    break;
            }

            if (table != null)
            {
                this.tables.Add(table);
                return String.Format(OutputMessages.TableAdded, tableNumber);
            }
            else
            {
                return null;
            }
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x=>x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:F2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            this.totalIncome += table.GetBill();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():F2}");

            table.Clear();
            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }


            IDrink drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            IFood food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);

        }
    }
}
