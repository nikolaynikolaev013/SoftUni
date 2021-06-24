using System;

namespace Projects_Creation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int numOfProjects = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {numOfProjects * 3} hours to complete {numOfProjects} project/s.");
        }
    }
}
