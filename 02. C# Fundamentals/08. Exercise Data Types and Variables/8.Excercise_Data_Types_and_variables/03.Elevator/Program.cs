using System;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            double capacity = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling(numOfPeople / capacity);
            Console.WriteLine(courses);
        }
    }
}
