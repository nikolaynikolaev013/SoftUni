using System;
namespace Grand_Prix.Models.Drivers
{
    public class AggressiveDriver : Driver
    {
        public AggressiveDriver()
        {
        }

        public override float Speed => throw new NotImplementedException();// * 1.3
    }
}
