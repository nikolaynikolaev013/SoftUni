using System;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            Console.WriteLine(DateModifier.ReturnDifference(date1, date2));
        }
    }
}
