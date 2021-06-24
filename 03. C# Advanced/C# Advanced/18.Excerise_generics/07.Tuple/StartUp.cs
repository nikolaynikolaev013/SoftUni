using System;
using System.Linq;

namespace _07.Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();

            var city = String.Join(" ", command, 3, command.Length - 3);
            var tuple1 = new Tuple<string, string, string>($"{command[0]} {command[1]}", command[2], city);
            Console.WriteLine(tuple1.ToString());

            command = Console.ReadLine().Split();

            var tuple2 = new Tuple<string, int, bool>(command[0], int.Parse(command[1]), (command[2] == "drunk") ? true : false);
            Console.WriteLine(tuple2.ToString());

            command = Console.ReadLine().Split();

            var tuple3 = new Tuple<string, double, string>(command[0], double.Parse(command[1]), command[2]);
            Console.WriteLine(tuple3.ToString());
        }
    }
}
