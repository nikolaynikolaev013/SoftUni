using System;
using System.Text;

namespace _04.Caeser_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalText = Console.ReadLine();
            StringBuilder encryptedText = new StringBuilder();

            foreach (var letter in originalText)
            {
                encryptedText.Append((char)((int)letter + 3));
            }

            Console.WriteLine(encryptedText.ToString());
        }
    }
}
