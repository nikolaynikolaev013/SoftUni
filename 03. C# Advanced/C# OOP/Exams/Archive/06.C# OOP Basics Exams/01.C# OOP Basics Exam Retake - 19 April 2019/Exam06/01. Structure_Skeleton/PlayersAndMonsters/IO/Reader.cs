using System;
using PlayersAndMonsters.IO.Contracts;

namespace PlayersAndMonsters.IO
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
