using System;
using System.Linq;

namespace _02.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {
        }

        public string Browse(string website)
        {
            if (website.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {website}!";
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Calling... {number}";
        }
    }
}
