using System;
namespace _04.Wild_Farm.IO
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
