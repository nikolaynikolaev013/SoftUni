using System;
using System.Collections.Generic;
using System.Linq;

namespace _18.Excerise_generics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var list = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                var box = new Box<double>(double.Parse(Console.ReadLine()));
                list.Add(box);
            }


            var itemToCompareTo = new Box<double>(double.Parse(Console.ReadLine()));

            Console.WriteLine(Box<double>.MyCompareTo(list, itemToCompareTo));
        }
    }
}
