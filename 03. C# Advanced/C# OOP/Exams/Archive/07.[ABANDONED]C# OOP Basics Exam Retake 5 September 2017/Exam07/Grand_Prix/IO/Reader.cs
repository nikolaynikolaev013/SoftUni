using System;
using Grand_Prix.IO.Contracts;

namespace Grand_Prix.IO
{
    public class Reader : IReader
    {
        public Reader()
        {
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
