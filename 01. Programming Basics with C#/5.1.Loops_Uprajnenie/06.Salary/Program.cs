using System;

namespace Salary
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            string temp="";

            for (int i = 0; i <= tabs-1; i++)
            {
                temp = Console.ReadLine();

                if (temp == "Facebook")
                {
                    salary -= 150;
                }
                else if (temp == "Instagram")
                {
                    salary -= 100;
                }
                else if (temp == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }
            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
