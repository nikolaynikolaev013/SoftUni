using System;
namespace Grand_Prix.Models.Tyre.Contracts
{
    public interface ITyre
    {
        public string Name { get; }
        public float Hardness { get; }
        public float Degradation { get; }
    }
}
