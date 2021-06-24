using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace exam7
{
    class Program
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bombEffects = new Queue<int>(univInput);

            univInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bombCasings = new Stack<int>(univInput);

            var numOfDaturaBombs = 0;
            var numOfCherryBombs = 0;
            var numOfSmokeDecoyBombs = 0;

            while (bombEffects.Count > 0 && bombCasings.Count > 0
                && (numOfCherryBombs < 3 || numOfDaturaBombs < 3 || numOfSmokeDecoyBombs < 3))
            {
                var currBombEffect = bombEffects.Peek();
                var currBombCasing = bombCasings.Pop();

                var sum = currBombEffect + currBombCasing;


                switch (sum)
                {
                    case 40:
                        numOfDaturaBombs++;
                        bombEffects.Dequeue();
                        break;
                    case 60:
                        numOfCherryBombs++;
                        bombEffects.Dequeue();
                        break;
                    case 120:
                        numOfSmokeDecoyBombs++;
                        bombEffects.Dequeue();
                        break;
                    default:

                        bombCasings.Push(currBombCasing - 5);
                        break;
                }
            }

            var filledPouchOrNotString = numOfCherryBombs > 2 && numOfDaturaBombs > 2 && numOfSmokeDecoyBombs > 2 ?
                "Bene! You have successfully filled the bomb pouch!" : "You don't have enough materials to fill the bomb pouch.";

            var bombEffectsString = bombEffects.Count > 0 ? $"Bomb Effects: {String.Join(", ", bombEffects)}" : "Bomb Effects: empty";

            var bombCasingsString = bombCasings.Count > 0 ? $"Bomb Casings: {String.Join(" ", bombCasings)}" : "Bomb Casings: empty";

            Console.WriteLine(filledPouchOrNotString);
            Console.WriteLine(bombEffectsString);
            Console.WriteLine(bombCasingsString);
            Console.WriteLine($"Cherry Bombs: {numOfCherryBombs}");
            Console.WriteLine($"Datura Bombs: {numOfDaturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {numOfSmokeDecoyBombs}");
        }
    }
}
