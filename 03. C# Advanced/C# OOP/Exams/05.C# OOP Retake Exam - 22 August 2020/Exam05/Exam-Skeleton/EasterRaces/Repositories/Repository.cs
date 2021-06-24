using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected IList<T> collection;

        protected Repository()
        {
            this.collection = new List<T>();
        }

        public void Add(T model)
        {
            collection.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)this.collection;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return collection.Remove(model);
        }
    }
}
