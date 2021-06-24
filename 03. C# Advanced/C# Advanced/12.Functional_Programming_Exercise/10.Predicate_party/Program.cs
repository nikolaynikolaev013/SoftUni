using System;
using System.Linq;

namespace _10.Predicate_party
{
    class Program
    {
        static void Main(string[] args)
        {
            var invitedPeople = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<string, string> startingName = (x, y) => { x => x.};
        }
    }
}
