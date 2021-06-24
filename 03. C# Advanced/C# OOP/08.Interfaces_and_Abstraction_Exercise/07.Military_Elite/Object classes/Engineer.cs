using System;
using System.Collections.Generic;
using _07.Military_Elite.Interfaces;

namespace _07.Military_Elite.Objectclasses
{
    public class Engineer
    {

        public Engineer()
        {
        }

        public IReadOnlyCollection<IRepair> repairs { get; private set; }

        public void AddRepair(IRepair rp)
        {
            //repairs.Add(rp);
        }
    }
}
