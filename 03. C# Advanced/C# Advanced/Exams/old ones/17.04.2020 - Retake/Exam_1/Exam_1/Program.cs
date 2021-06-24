using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numOfPiles = int.Parse(Console.ReadLine());

            var wallsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var walls = new Queue<int>(wallsInput);

            var counter = 0;

            for (int i = 0; i < numOfPiles; i++)
            {
                counter++;

                var pileInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();

                var currPile = new Stack<int>(pileInput);

                if (counter == 3)
                {
                    var newWall = int.Parse(Console.ReadLine());
                    walls.Enqueue(newWall);
                    counter = 0;
                }

                if (walls.Count > 0)
                {
                    walls = Attack(walls, currPile);
                }
            }

            if (walls.Count > 0)
            {
                Console.WriteLine($"Walls left: {String.Join(", ", walls)}");
            }
            else
            {
                //Console.WriteLine($"Rocks left: {String.Join(", ", )}");
            }
        }

        private static Queue<int> Attack(Queue<int> walls, Stack<int> currPile)
        {
            var currWall = walls.Peek();
            var currPileInitialCount = currPile.Count;

            for (int j = 0; j < currPileInitialCount; j++)
            {
                var currRock = currPile.Peek();

                if (currRock < currWall)
                {
                    currWall -= currRock;

                    var tempWalls = new Queue<int>();
                    for (int k = 0; k < walls.Count + tempWalls.Count; k++)
                    {
                        if (k == 0)
                        {
                            tempWalls.Enqueue(currWall);
                            walls.Dequeue();
                        }
                        else
                        {
                            tempWalls.Enqueue(walls.Dequeue());
                        }
                    }

                    walls = new Queue<int>(tempWalls);
                    currPile.Pop();
                }

                else if (currRock > currWall)
                {
                    walls.Dequeue();
                    currPile.Pop();
                    currRock -= currWall;
                    currPile.Push(currRock);
                }
                else if (currRock == currWall)
                {
                    walls.Dequeue();
                    currPile.Pop();
                }
            }

            return walls;
        }
    }
}
