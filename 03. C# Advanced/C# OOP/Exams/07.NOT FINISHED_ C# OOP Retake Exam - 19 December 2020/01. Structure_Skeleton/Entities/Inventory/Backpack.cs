using System;
namespace WarCroft.Entities.Inventory.Contracts
{
    public class Backpack : Bag
    {
        private const int DefaultCapacity = 100;
        public Backpack() : base(DefaultCapacity)
        {
        }
    }
}
