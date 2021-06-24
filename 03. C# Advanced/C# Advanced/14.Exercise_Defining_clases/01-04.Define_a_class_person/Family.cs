using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {

        public List<Person> members { get; set; } = new List<Person>();

        public Family()
        {
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.members.OrderByDescending(x => x.Age).ToList()[0];
        }

        public List<Person> ReturnEligblePeople()
        {
            return this.members.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
        }


    }
}
