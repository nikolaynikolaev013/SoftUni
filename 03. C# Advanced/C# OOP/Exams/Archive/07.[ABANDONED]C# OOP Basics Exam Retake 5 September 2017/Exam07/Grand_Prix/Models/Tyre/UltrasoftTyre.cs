using System;
namespace Grand_Prix.Models.Tyre
{
    public class UltrasoftTyre : Tyre
    {
        private const string DefaultTyreName = "Hard";

        public UltrasoftTyre() : base(DefaultTyreName)
        {
        }

        public float Grip { get; private set; }
    }
}
