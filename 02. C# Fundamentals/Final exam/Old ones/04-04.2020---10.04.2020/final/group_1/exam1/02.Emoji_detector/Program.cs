using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Emoji_detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string emojiPattern = @"(:{2}|\*{2})(?<emojiName>[A-Z][a-z]{2,})\1";
            string numberPattern = @"(?<number>[0-9])";

            string input = Console.ReadLine();

            BigInteger coolThreshold = 1;

            MatchCollection coolDigits = Regex.Matches(input, numberPattern);

            foreach (Match number in coolDigits)
            {
                coolThreshold *= int.Parse(number.Groups[0].Value);
            }

            MatchCollection emojis = Regex.Matches(input, emojiPattern);



            List<string> coolEmojis = new List<string>();
            int numOfEmojis = 0;

            foreach (Match emoji in emojis)
            {
                numOfEmojis++;
                StringBuilder currEmoji = new StringBuilder(emoji.Groups["emojiName"].Value);

                int totalCount = 0;

                foreach (var letter in currEmoji.ToString())
                {
                    totalCount += (int)letter;
                }

                if (totalCount > coolThreshold)
                {
                    coolEmojis.Add(emoji.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{numOfEmojis} emojis found in the text. The cool ones are:");

            if (coolEmojis.Count != 0)
            {
                foreach (var emoji in coolEmojis)
                {
                    Console.WriteLine(emoji);
                }
            }
        }
    }
}
