using System;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return this.collection.FirstOrDefault(x => x.Name == name);
        }
    }
}
