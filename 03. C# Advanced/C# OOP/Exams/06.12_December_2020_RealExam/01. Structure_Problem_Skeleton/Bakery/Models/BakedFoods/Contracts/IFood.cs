namespace Bakery.Models.BakedFoods.Contracts
{
    public interface IFood
    {
        string Name { get; }

        int Portion { get; }

        decimal Price { get; }
    }
}
