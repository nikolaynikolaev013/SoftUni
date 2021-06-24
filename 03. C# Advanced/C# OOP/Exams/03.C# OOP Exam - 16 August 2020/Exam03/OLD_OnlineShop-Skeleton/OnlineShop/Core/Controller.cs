using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private IList<IComputer> computers;
        private IList<IComponent> components;
        private IList<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            ValidateComputerID(computerId);

            if (!Enum.TryParse(componentType, out ComponentType componentTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            switch (componentTypeEnum)
            {
                case ComponentType.CentralProcessingUnit:
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.Motherboard:
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.PowerSupply:
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.RandomAccessMemory:
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.SolidStateDrive:
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.VideoCard:
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
            }

            this.components.Add(component);
            this.computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);

            return String.Format(SuccessMessages.AddedComponent, component.GetType().Name, component.Id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {

            if (!Enum.TryParse(computerType, out ComputerType computerTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            switch (computerTypeEnum)
            {
                case ComputerType.DesktopComputer:
                    computer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case ComputerType.Laptop:
                    computer = new Laptop(id, manufacturer, model, price);
                    break;
            }


            computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, computer.Id);

        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            ValidateComputerID(computerId);

            if (!Enum.TryParse(peripheralType, out PeripheralType periTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (this.peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peri = null;

            switch (periTypeEnum)
            {
                case PeripheralType.Headset:
                    peri = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Keyboard:
                    peri = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Monitor:
                    peri = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Mouse:
                    peri = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            this.peripherals.Add(peri);
            this.computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peri);

            return String.Format(SuccessMessages.AddedPeripheral, peri.GetType().Name, peri.Id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer bestComputer = this.computers.OrderBy(x => x.OverallPerformance).FirstOrDefault(x => x.Price <= budget);

            if (bestComputer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(bestComputer);
            return bestComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            ValidateComputerID(id);

            IComputer comp = this.computers.FirstOrDefault(x => x.Id == id);
            this.computers.Remove(comp);

            return comp.ToString();
        }

        public string GetComputerData(int id)
        {
            ValidateComputerID(id);

            return this.computers.FirstOrDefault(x => x.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            //TODO:??
            ValidateComputerID(computerId);

            IComponent component = this.computers.FirstOrDefault(x=>x.Id == computerId).RemoveComponent(componentType);

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            ValidateComputerID(computerId);

             IPeripheral peri =  this.computers.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peri.Id);
        }

        private void ValidateComputerID(int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
