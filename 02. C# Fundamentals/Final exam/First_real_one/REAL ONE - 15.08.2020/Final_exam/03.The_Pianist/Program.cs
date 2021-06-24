using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPieces = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();


            for (int i = 0; i < numOfPieces; i++)
            {
                string[] command = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = command[0];
                string composer = command[1];
                string key = command[2];

                if (!pieces.ContainsKey(piece))
                {
                    pieces.Add(piece, new List<string> { composer, key });
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] command = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Add":
                        Add(pieces: pieces, command: command);
                        break;
                    case "Remove":
                        Remove(pieces: pieces, command: command);
                        break;
                    case "ChangeKey":
                        ChangeKey(pieces: pieces, command: command);
                        break;
                    default:
                        break;
                }
            }

            var sorted = pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]);

            foreach (var piece in sorted)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }

        private static void ChangeKey(Dictionary<string, List<string>> pieces, string[] command)
        {

            string piece = command[1];
            string newKey = command[2];

            if (pieces.ContainsKey(piece))
            {
                pieces[piece][1] = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        private static void Remove(Dictionary<string, List<string>> pieces, string[] command)
        {
            string piece = command[1];

            if (pieces.ContainsKey(piece))
            {
                pieces.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        private static void Add(Dictionary<string, List<string>> pieces, string[] command)
        {
            string piece = command[1];
            string composer = command[2];
            string key = command[3];

            if (!pieces.ContainsKey(piece))
            {
                pieces.Add(piece, new List<string> { composer, key });
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
            else
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }
        }
    }
}
