using System;
namespace DefiningClasses
{
    public class Engine
    {
        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }


        public Engine()
        {
        }
        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
    }
}
