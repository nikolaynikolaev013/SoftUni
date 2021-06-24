using System;
namespace _04.Border_Control
{
    public interface IBuyer : IPerson
    {
        int Food { get; }

        void BuyFood();
    }
}
