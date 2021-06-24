using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public class Computer: Product, IComputer
    {
        private const int DefaultOverallPerformance = 0;

        private readonly IList<IComponent> components;
        private readonly IList<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price) : base(id, manufacturer, model, price, 1)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override double OverallPerformance
        {
            get
            {
                //TODO:??
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + components.Average(x => x.OverallPerformance);
                }
            }
            protected set => base.OverallPerformance = value;
        }

        //TODO:??
        public override decimal Price => base.Price + Components.Sum(x=>x.Price) + Peripherals.Sum(x=>x.Price);

        public void AddComponent(IComponent component)
        {
            //TODO:??
            if (this.Components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            //TODO:??
            if (this.Components.Count == 0 || !this.Components.Any(x=>x.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent componentToRemove = this.Components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals.Count == 0 || !this.Peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peripheralToRemove = this.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            //TODO:??
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");
            foreach (var component in this.Components)
            {
                sb.AppendLine("  " + component.ToString());
            }
            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance " +
                $"({ (this.Peripherals.Count > 0 ? this.Peripherals.Average(x => x.OverallPerformance) : DefaultOverallPerformance):F2}):");
            foreach (var peri in this.Peripherals)
            {
                sb.AppendLine("  " + peri.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
