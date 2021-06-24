using System;
namespace _01.Vehicles.IO
{
    public class Reader : IReader
    {
        public string CustomReader()
        {
            return Console.ReadLine();
        }
    }
}
