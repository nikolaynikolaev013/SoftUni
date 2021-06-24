using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private IList<IComponent> components;
        private IList<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
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
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
                }
            }
        }

        public override decimal Price =>
            base.Price + this.Components.Sum(x=>x.Price) + this.Peripherals.Sum(x=>x.Price);

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x=>x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.Components.Any(x=>x.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!this.Peripherals.Any(x=>x.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            IPeripheral peri = this.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(peri);
            return peri;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(" " + String.Format(SuccessMessages.ComputerComponentsToString, this.Components.Count));
            foreach (var component in this.Components)
            {
                sb.AppendLine("  " + component.ToString());
            }

            var overallP = this.Peripherals.Count > 0 ? this.Peripherals.Average(x => x.OverallPerformance) : 0.00;
            sb.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString, this.Peripherals.Count, $"{overallP:F2}"));
            foreach (var peri in this.Peripherals)
            {
                sb.AppendLine("  " + peri.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
