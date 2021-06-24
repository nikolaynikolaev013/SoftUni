using System;

namespace Login
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = ReverseString(user);

            string temp = String.Empty;
            int counter = 0;

            while (pass != temp)
            {
                counter++;

                temp = Console.ReadLine();

                if (temp != pass && counter <= 3)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else if (temp != pass && counter >= 4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    break;
                }
                else if (temp == pass)
                {
                    Console.WriteLine($"User {user} logged in.");
                    break;
                }

            } 
        }

        static string ReverseString(string str)
        {
            string revStr = String.Empty;

            for (int i = str.Length-1; i >= 0; i--)
            {

                revStr += str[i];
            }

            return revStr;
        }
    }
}
