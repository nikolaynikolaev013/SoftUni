using System;

namespace _10.Poke_mon
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            uint m = uint.Parse(Console.ReadLine());
            byte y = byte.Parse(Console.ReadLine());

            uint originalN = n;

            int count = 0;

            while (n >= m)
            {
                n -= m;
                count++;
                if (n == originalN / 2.0 && y > 0)
                {
                    n /= y;
                    continue;
                }

            }

            Console.WriteLine(n);
            Console.WriteLine(count);
        }
    }
}
