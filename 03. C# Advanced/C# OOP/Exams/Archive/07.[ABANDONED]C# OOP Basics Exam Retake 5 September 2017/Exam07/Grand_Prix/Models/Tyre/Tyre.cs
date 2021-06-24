using System;
using Grand_Prix.Models.Tyre.Contracts;

namespace Grand_Prix.Models.Tyre
{
    public abstract class Tyre : ITyre
    {
        private const float DefaultDegradationLevel = 100;

        protected Tyre(string name)
        {
            this.Name = name;
            this.Degradation = DefaultDegradationLevel;
        }

        public string Name { get; private set; }

        public float Hardness => throw new NotImplementedException();

        public float Degradation { get; private set; }
    }
}
