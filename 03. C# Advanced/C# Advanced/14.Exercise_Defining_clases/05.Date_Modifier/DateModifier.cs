using System;
using System.Linq;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int Diff { get; set; }

        public DateModifier()
        {
        }


        public static int ReturnDifference(string d1, string d2)
        {
            var splittedD1 = d1.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var splittedD2 = d2.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var date1 = new DateTime(splittedD1[0], splittedD1[1], splittedD1[2]);
            var date2 = new DateTime(splittedD2[0], splittedD2[1], splittedD2[2]);

            return Math.Abs((date1 - date2).Days);
        }
    }
}
