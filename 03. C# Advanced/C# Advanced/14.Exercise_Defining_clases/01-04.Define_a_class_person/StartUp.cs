using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                family.AddMember(new Person(input[0], int.Parse(input[1])));
            }

            var eligblePeople = family.ReturnEligblePeople();

            Console.WriteLine(String.Join(Environment.NewLine, eligblePeople));

        }
    }
}
