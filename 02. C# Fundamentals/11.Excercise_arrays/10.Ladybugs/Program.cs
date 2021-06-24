using System;
using System.Linq;

namespace _10.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            //3
            //0 1
            //0 right 1
            //2 right 1
            //end


            int fieldSize = int.Parse(Console.ReadLine()); //3
            int[] field = new int[fieldSize];
            int[] indexes = Console.ReadLine() //0 1
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < field.Length && indexes[i] >= 0)
                {
                    field[indexes[i]] = 1;
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split().ToArray();
                int ladybugIndex = int.Parse(command[0]);
                int distance = int.Parse(command[2]);
                string comm = command[1];
               
                if (ladybugIndex < 0 || ladybugIndex > field.Length-1 || field[ladybugIndex] == 0)
                {
                    continue;
                }

                if (comm == "right")
                {
                    int flyingIndex = ladybugIndex + distance;

                    if (flyingIndex >= field.Length)
                    {
                        continue;
                    }

                    field[ladybugIndex] = 0;

                    if (field[flyingIndex] == 1)
                    {
                        while (field[flyingIndex] == 1)
                        {
                            if (flyingIndex+1 >= field.Length)
                            {
                                break;
                            }
                            flyingIndex++;
                        }

                    }
                    if (flyingIndex < field.Length-1)
                    {
                        field[flyingIndex] = 1;
                    }
                }
                else if (comm == "left")
                {
                    int flyingIndex = ladybugIndex - distance;

                    if (flyingIndex < 0)
                    {
                        continue;
                    }

                    field[ladybugIndex] = 0;

                    if (field[flyingIndex] == 1)
                    {
                        while (field[flyingIndex] == 1)
                        {
                            if (flyingIndex < 0)
                            {
                                break;
                            }
                            flyingIndex--;
                        }

                    }
                    if (flyingIndex >= 0)
                    {
                        field[flyingIndex] = 1;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", field));
        }

        }
    }
