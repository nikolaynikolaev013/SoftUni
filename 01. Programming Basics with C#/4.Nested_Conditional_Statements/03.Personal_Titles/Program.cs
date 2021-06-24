using System;

namespace Personal_Titles
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            string title = "";

            if (gender == "m")
            {
                if (age >= 16)
                {
                    title = "Mr.";
                }
                else if (age < 16)
                {
                    title = "Master";
                }
            }

            if (gender == "f")
            {
                if (age >= 16)
                {
                    title = "Ms.";
                }
                else if (age < 16)
                {
                    title = "Miss";
                }
            }

            Console.WriteLine(title);
        }
    }
}
