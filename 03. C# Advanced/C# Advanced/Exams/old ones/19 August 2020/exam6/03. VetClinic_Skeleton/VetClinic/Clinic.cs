using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count { get => data.Count; }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.FirstOrDefault(x => x.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(x => (x.Name == name && x.Owner == owner));
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            sb.AppendLine(String.Join(Environment.NewLine, data));

            return sb.ToString().TrimEnd();
        }
    }
}
