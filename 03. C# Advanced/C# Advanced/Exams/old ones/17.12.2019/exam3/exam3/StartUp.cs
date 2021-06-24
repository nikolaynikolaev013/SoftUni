using System;
using System.Collections.Generic;
using System.Linq;

namespace exam3
{
    class Program
    {
        static void Main(string[] args)
        {
            var univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var materials = new Stack<int>(univInput);

            univInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var magic = new Queue<int>(univInput);

            var presents = new Dictionary<string, int>(){
                { "Doll", 0},
                { "Wooden train", 0},
                { "Teddy bear", 0},
                { "Bicycle", 0}
            };
            

            while (materials.Count > 0 && magic.Count > 0)
            {
                var currMaterial = materials.Peek();
                var currMagic = magic.Peek();


                if (currMagic == 0 || currMaterial == 0)
                {
                    if (currMaterial == 0)
                    {
                        materials.Pop();
                    }

                    if (currMagic == 0)
                    {
                        magic.Dequeue();
                    }
                    continue;
                }

                var result = currMaterial * currMagic;

                if (result < 0)
                {
                    result = currMagic + currMaterial;
                    materials.Pop();
                    magic.Dequeue();
                    materials.Push(result);
                    continue;
                }

                materials.Pop();
                magic.Dequeue();

                switch (result)
                {
                    case 150:
                        presents["Doll"]++;
                        break;
                    case 250:
                        presents["Wooden train"]++;
                        break;
                    case 300:
                        presents["Teddy bear"]++;
                        break;
                    case 400:
                        presents["Bicycle"]++;
                        break;
                    default:
                        materials.Push(currMaterial + 15);
                        break;
                }
            }

            var isSuccessful = false;

            if (presents["Doll"] >= 1 && presents["Wooden train"] >= 1 || presents["Teddy bear"] >= 1 && presents["Bicycle"] >= 1)
            {
                isSuccessful = true;
            }

            string successfullString = isSuccessful ? "The presents are crafted! Merry Christmas!" : "No presents this Christmas!";

            string materialsString = materials.Count > 0 ? $"Materials left: {String.Join(", ", materials)}{Environment.NewLine}" : null;
            string magicString = magic.Count > 0 ? $"Magic left: {String.Join(", ", magic)}{Environment.NewLine}" : null;

            Console.WriteLine(successfullString);
            Console.Write(materialsString + magicString);
            foreach (var present in presents.OrderBy(x=>x.Key).Where(x=>x.Value > 0))
            {
                Console.WriteLine($"{present.Key}: {present.Value}");
            }
        }
    }
}
