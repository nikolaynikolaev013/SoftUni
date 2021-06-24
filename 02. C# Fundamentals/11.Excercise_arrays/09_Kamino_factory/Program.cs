using System;
using System.Linq;

namespace _09_Kamino_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dna = new int[n];

            string input = Console.ReadLine();

            int startingIndex = 0;
            int bestStartingIndex = int.MaxValue;
            int highest = 1;
            int bestHighest = 1;
            int currDna = 0;
            int bestCurrDna = 0;
            int[] bestDna = new int[n];
            int sum = 0;
            int bestSum = 0;

            while (input != "Clone them!")
            {
                if (input != "Clone them!")
                {
                    dna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    currDna++;
                    sum = dna.Sum();

                    for (int i = 0; i < dna.Length-1; i++)
                    {
                        if (dna[i] == dna[i+1])
                        {
                            highest++;

                        }
                        else
                        {
                            highest = 1;
                            startingIndex = i;
                        }


                        if (highest > bestHighest)
                        {
                            bestHighest = highest;
                            bestStartingIndex = startingIndex;
                            bestCurrDna = currDna;
                            bestDna = dna.ToArray();
                            bestSum = sum;
                        }
                        else if(highest == bestHighest)
                        {
                            if (sum > bestSum)
                            {
                                bestHighest = highest;
                                bestStartingIndex = startingIndex;
                                bestCurrDna = currDna;
                                bestDna = dna.ToArray();
                                bestSum = sum;
                            }
                            else if (startingIndex < bestStartingIndex)
                            {
                                bestHighest = highest;
                                bestStartingIndex = startingIndex;
                                bestCurrDna = currDna;
                                bestDna = dna.ToArray();
                                bestSum = sum;
                            }
                        }


                        //if ((highest > bestHighest && startingIndex < bestStartingIndex || highest == bestHighest && startingIndex < bestStartingIndex || highest == bestHighest && sum > bestSum) && highest > 1) 
                        //{
                        //    bestHighest = highest;
                        //    bestStartingIndex = startingIndex;
                        //    bestCurrDna = currDna;
                        //    bestDna = dna.ToArray();
                        //    bestSum = sum;
                        //}
                    }

                    input = Console.ReadLine();
                }
            }

            Console.WriteLine($"Best DNA sample {bestCurrDna} with sum: {bestSum}.");
            Console.WriteLine(String.Join(" ", bestDna));
            
        }
    }
}
