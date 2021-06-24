using System;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
{
    public class Writer : IWriter
    {
        public Writer()
        {
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
