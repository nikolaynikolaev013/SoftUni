using System;
namespace Animals
{
    public class Tomcat : Animal
    {
        private const string Gender = "Male";
        public Tomcat(string name, int age, string? gender) : base(name, age, Gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
