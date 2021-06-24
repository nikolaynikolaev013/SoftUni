using System;
namespace Grand_Prix.Models.Tyre
{
    public class HardTyre : Tyre
    {
        private const string DefaultTyreName = "Hard";

        public HardTyre() : base(DefaultTyreName)
        {
        }
    }
}
