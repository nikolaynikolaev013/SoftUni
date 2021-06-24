using System;
namespace _04.Border_Control
{
    public class Pet : INamable, IBirthable
    {
        public Pet(string name, string birthDate)
        {
            this.Name = name;
            this.Birthdate = birthDate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
