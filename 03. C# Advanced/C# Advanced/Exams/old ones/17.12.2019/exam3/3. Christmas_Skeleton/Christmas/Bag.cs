using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        private Bag()
        {
            data = new List<Present>();
        }

        public Bag(string color, int capacity)
            : this()
        {
            this.Color = color;
            this.Capacity = capacity;
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count {
            get
            {
                return data.Count;
            }
        }

        public void Add(Present present)
        {
            if (Count < Capacity)
            {
                data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.Find(x => x.Name == name));
        }

        public Present GetHeaviestPresent()
        {
            return data.OrderByDescending(x=>x.Weight).First();
        }

        public Present GetPresent(string name)
        {
            return data.First(p => p.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");
            sb.AppendLine(String.Join(Environment.NewLine, data));

            return sb.ToString().TrimEnd();
        }

    }
}
