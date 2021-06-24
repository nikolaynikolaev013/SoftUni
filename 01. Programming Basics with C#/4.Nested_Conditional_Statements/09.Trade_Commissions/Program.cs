using System;

namespace Trade_Commissions
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double commission = 0;

            if (city == "Sofia")
            {
                if (quantity >= 0 && quantity <= 500)
                {
                    commission = 0.05;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 500 && quantity <= 1000)
                {
                    commission = 0.07;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 1000 && quantity <= 10000)
                {
                    commission = 0.08;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 10000)
                {
                    commission = 0.12;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity < 0)
                {
                    Console.WriteLine("error");
                }

            }

            else if (city == "Varna")
            {
                if (quantity >= 0 && quantity <= 500)
                {
                    commission = 0.045;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 500 && quantity <= 1000)
                {
                    commission = 0.075;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 1000 && quantity <= 10000)
                {
                    commission = 0.1;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 10000)
                {
                    commission = 0.13;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if(quantity < 0)
                {
                    Console.WriteLine("error");
                }

            }

            else if (city == "Plovdiv")
            {
                if (quantity >= 0 && quantity <= 500)
                {
                    commission = 0.055;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 500 && quantity <= 1000)
                {
                    commission = 0.08;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 1000 && quantity <= 10000)
                {
                    commission = 0.12;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity > 10000)
                {
                    commission = 0.145;
                    Console.WriteLine($"{quantity * commission:F2}");
                }
                else if (quantity < 0)
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
