using System;
using System.Collections.Generic;
using System.Text;

namespace _18.Excerise_generics
{
    public class Box<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public Box()
        {
        }

        public Box(T value)
        {
            this.Value = value;
        }

        public Box(Box<T> item)
        {
            this.Value = item.Value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Value.GetType());
            sb.Append(": ");
            sb.Append(Value);
            return sb.ToString();
        }

        public static List<Box<T>> Swap(List<Box<T>> list, int index1, int index2)
        {
            Box<T> temp = new Box<T>(list[index1]);

            list[index1] = list[index2];
            list[index2] = temp;

            return list;
        }


        public static int MyCompareTo(List<Box<T>> list, Box<T> item)
        {
            var counter = 0;

            foreach (var listItem in list)
            {
                if (listItem.Value.CompareTo(item.Value) == 1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
