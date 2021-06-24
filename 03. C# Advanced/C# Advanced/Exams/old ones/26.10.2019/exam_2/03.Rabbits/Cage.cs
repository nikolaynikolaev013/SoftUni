using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        private Cage()
        {
            this.data = new List<Rabbit>();
        }
        public Cage(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count + 1 <= this.Capacity)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            if (data.Any(x=>x.Name == name))
            {
                data.RemoveAll(x=>x.Name == name);
                return true;
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = this.data.FirstOrDefault(r => r.Name == name);

            if (rabbit != null)
            {
                this.data.Remove(rabbit);
            }
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] newArray = data.Where(x => x.Species == species).Select(x =>
                { x.Available = false;
                    return x;
                }
                ).ToArray();

             return newArray;
        }


        public string Report()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Rabbits available at {this.Name}:");
            str.AppendLine(String.Join(Environment.NewLine, data.Where(x=>x.Available == true)));

            return str.ToString().Trim();
        }
    }
}
