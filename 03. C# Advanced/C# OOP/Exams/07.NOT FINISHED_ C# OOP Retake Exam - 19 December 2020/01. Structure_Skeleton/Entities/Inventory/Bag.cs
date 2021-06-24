using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity {
            get => this.capacity;

            set {
                this.capacity = value;
            }
        }

        public int Load => this.Items.Sum(x=>x.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (!this.Items.Any(x=>x.GetType().Name == name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            var item = this.Items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
