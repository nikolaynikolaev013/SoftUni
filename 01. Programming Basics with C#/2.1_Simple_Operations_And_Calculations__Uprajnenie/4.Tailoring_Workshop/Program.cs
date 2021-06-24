using System;

namespace Tailoring_Workshop
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numOfTables = int.Parse(Console.ReadLine());
            double lengthOfTables = double.Parse(Console.ReadLine());
            double widthOfTables = double.Parse(Console.ReadLine());

            double tablecloths = numOfTables * (lengthOfTables + 2*0.3) * (widthOfTables+2*0.3);
            double squares = numOfTables * ((lengthOfTables / 2) * (lengthOfTables / 2));

            Console.WriteLine($"{(tablecloths * 7) + squares * 9:F2} USD");
            Console.WriteLine($"{((tablecloths * 7) + squares * 9)*1.85:F2} BGN");

        }
    }
}
