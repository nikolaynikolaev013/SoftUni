using System;

namespace Homework
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());

            string str = String.Empty;

            if (age >= 0 && age <= 2)
            {
                str = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                str = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                str = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                str = "adult";
            }
            else if (age >= 66)
            {
                str = "elder";
            }

            Console.WriteLine(str);
        }
    }
}
