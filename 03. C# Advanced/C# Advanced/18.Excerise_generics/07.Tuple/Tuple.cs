using System;
namespace _07.Tuple
{
    public class Tuple<T, V, U>
    {
        public T item1 { get; set; }
        public V item2 { get; set; }
        public U item3 { get; set; }


        public Tuple(T item1, V item2, U item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return item1 + " -> " + item2 + " -> " + item3;
        }
    }
}
