using System;
using System.Linq;

namespace _02.Telephony
{
    public class StationaryPhone : ICallable
    {
        public StationaryPhone()
        {
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {number}";
        }
    }
}
