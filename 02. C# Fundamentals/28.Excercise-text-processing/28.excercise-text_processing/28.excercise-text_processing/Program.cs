using System;
using System.Collections.Generic;

namespace _28.excercise_text_processing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> validNames = new List<string>();

            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool invalid = false;

                    for (int j = 0; j < username.Length; j++)
                    {
                        if (!(char.IsLetterOrDigit(username[j]) || username[j] == '-' || username[j] == '_'))
                        {
                            invalid = true;
                            break;
                        }
                    }

                    if (!invalid)
                    {
                        validNames.Add(username);
                    }
                }
            }


            Console.WriteLine(String.Join(Environment.NewLine, validNames));
        }
    }
}
