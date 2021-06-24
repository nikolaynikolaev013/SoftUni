using System;
namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag
    {
        private const int DefaultCapacity = 100;

        public Satchel() : base(DefaultCapacity)
        {
        }
    }
}
