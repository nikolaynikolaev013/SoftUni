using System;
using Grand_Prix.IO.Contracts;

namespace Grand_Prix.IO
{
    public class Writer : IWriter
    {
        public Writer()
        {
        }

        public void CustomWrite(string text)
        {
            Console.WriteLine(text);
        }

        public void CustomWriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
