using System;

namespace _03.Extract_file
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Console.ReadLine();

            int indexOfFileName = file.LastIndexOf('\\');
            int indexOfFileExtention = file.LastIndexOf('.') + 1;
            int lengthOfFileName = indexOfFileExtention - indexOfFileName - 2;
            int lengthOfExtension = file.Length - indexOfFileExtention;

            Console.WriteLine($"File name: " + file.Substring(indexOfFileName + 1, lengthOfFileName));
            Console.WriteLine("File extension: " + file.Substring(indexOfFileExtention, lengthOfExtension));
        }
    }
}
