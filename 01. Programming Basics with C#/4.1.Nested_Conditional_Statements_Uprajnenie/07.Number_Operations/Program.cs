using System;

namespace Number_Operations
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());

            double finalResult = 0;
            //"{N1} {оператор} {N2} = {резултат} – {even/odd}"

            if (op == '+')
            {
                finalResult = n1 + n2;

                if (finalResult % 2 == 0)
                {
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult} - odd");
                }
            }

            else if (op == '-')
            {
                finalResult = n1 - n2;

                if (finalResult % 2 == 0)
                {
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult} - odd");
                }
            }

            else if (op == '*')
            {
                finalResult = n1 * n2;

                if (finalResult % 2 == 0)
                {
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult} - odd");
                }
            }

            else if (op == '/')
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }else
                {
                    finalResult = n1 / (n2 * 1.0);
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult:F2}");
                }
            }
            else if (op == '%')
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    finalResult = n1 % n2;
                    Console.WriteLine($"{n1} {op} {n2} = {finalResult}");
                }
            }
            

        }
    }
}
