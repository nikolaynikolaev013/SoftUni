using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
              int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0].ToLower().ToString() == "exchange")
                {
                    Exchange(ref arr, int.Parse(command[1]));
                }

                else if (command[0].ToLower().ToString() == "max")
                {
                    Max(arr, command[1].ToLower().ToString());
                }

                else if (command[0].ToString().ToLower() == "min")
                {
                    Min(arr, command[1].ToString().ToLower());
                }

                else if (command[0].ToString().ToLower() == "first")
                {
                    FirstElements(arr, int.Parse(command[1].ToString()), command[2].ToString().ToLower());
                }
                else if (command[0].ToString().ToLower() == "last")
                {
                    LastElements(arr, int.Parse(command[1].ToString()), command[2].ToString().ToLower());
                }
            }

            PrintArr(arr);
        }

        static void Exchange(ref int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            int[] newArr = new int[arr.Length];

            int counter = 0;

            for (int i = index+1; i < arr.Length; i++)
            {
                newArr[counter] = arr[i];
                counter++;
            }

            for (int i = 0; i <= index; i++)
            {
                newArr[counter] = arr[i];
                counter++;
            }

            arr = newArr;
        }

        static void Max(int[] arr, string command)
        {
            int max = int.MinValue;
            int index = 0;
            bool found = false;

     
            if (command == "odd")
            {

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)
                    {
                        if (arr[i] >= max)
                        {
                            max = arr[i];
                            index = i;
                            found = true;
                        }
                    }
                }

            }

            else if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (arr[i] >= max)
                        {
                            max = arr[i];
                            index = i;
                            found = true;
                        }
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void Min(int[] arr, string command)
        {
            int min = int.MaxValue;
            int index = 0;
            bool found = false;

            if (command == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)
                    {
                        if (arr[i] < min)
                        {
                            min = arr[i];
                            index = i;
                            found = true;
                        }
                    }
                }
            }
            else if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (arr[i] < min)
                        {
                            min = arr[i];
                            index = i;
                            found = true;
                        }
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void FirstElements(int[] arr, int howMany, string command)
        {
            if (howMany > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int counter = 0;
            List<int> list = new List<int>();

            if (command == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 1)
                    {
                        if (counter == howMany)
                        {
                            break;
                        }
                        counter++;
                        list.Add(arr[i]);
                    }
                }
            }
            else if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        if (counter == howMany)
                        {
                            break;
                        }
                        counter++;
                        list.Add(arr[i]);
                    }
                }
            }

            Console.WriteLine($"[{String.Join(", ", list)}]");
        }

        static void LastElements(int[] arr, int howMany, string command)
        {
            if (howMany > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int counter = 0;
            List<int> list = new List<int>();

            if (command == "odd")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[arr.Length - 1 - i] % 2 == 1)
                    {
                        if (counter == howMany)
                        {
                            break;
                        }
                        counter++;
                        list.Add(arr[arr.Length - 1 - i]);
                    }
                }
            }
            else if (command == "even")
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[arr.Length - 1 - i] % 2 == 0)
                    {
                        if (counter == howMany)
                        {
                            break;
                        }
                        counter++;
                        list.Add(arr[arr.Length - 1 - i]);
                    }
                }
            }
            Console.WriteLine($"[{String.Join(", ", list)}]");
        }

        static void PrintArr(int[] arr)
        {
            Console.WriteLine($"[{String.Join(", ", arr)}]");
        }
    }
}
