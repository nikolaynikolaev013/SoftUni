using System;

namespace _04.Password_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool fail = false;

            string password = Console.ReadLine();
            CheckPassLength(password, ref fail);
            CheckForSpecialSymbols(password, ref fail);
            CheckForAtLeastTwoDigits(password, ref fail);

            if (!fail)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static void CheckPassLength(string pass, ref bool fail)
        {
            if (pass.Length < 6 || pass.Length > 10)
            {
                fail = true;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
        }


        static void CheckForSpecialSymbols(string pass, ref bool fail)
        {
            for (int i = 0; i < pass.Length; i++)
            {
                if ((int)pass[i] < 48 || (int)pass[i] > 57 && (int)pass[i] < 65 || (int)pass[i] > 90 && (int)pass[i] < 97 || (int)pass[i] > 122)
                {
                    fail = true;
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }
        }

        static void CheckForAtLeastTwoDigits(string pass, ref bool fail)
        {
            int counter = 0;

            for (int i = 0; i < pass.Length; i++)
            {
                if ((int)pass[i] >= 48 && (int)pass[i] <= 57 )
                {
                    counter++;
                }
            }

            if (counter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                fail = true;
            }
        }


    }
}
