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

            IComputer computer = ValidateComputerID(computerId);

            if (this.components.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (!Enum.TryParse(componentType, out ComponentType componentTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
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
            computer.AddComponent(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computer.Id);
        }


        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!Enum.TryParse(computerType, out ComputerType computerTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
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

            this.computers.Add(computer);

            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = ValidateComputerID(computerId);

            if (this.peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (!Enum.TryParse(peripheralType, out PeripheralType periTypeEnum))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
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
            computer.AddPeripheral(peri);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computer.Id);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computerMatch = this.computers.OrderByDescending(x => x.OverallPerformance).ThenBy(x=>x.Price).FirstOrDefault(x => x.Price <= budget);

            if (computerMatch == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computerMatch);
            return computerMatch.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = ValidateComputerID(id);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = ValidateComputerID(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = ValidateComputerID(computerId);

            IComponent componentToRemove = components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(componentType);
            this.components.Remove(componentToRemove);

            return String.Format(SuccessMessages.RemovedComponent, componentType, componentToRemove.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = ValidateComputerID(computerId);

            IPeripheral peri = computer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peri);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peri.Id);
        }


        private IComputer ValidateComputerID(int computerId)
        {
            if (!this.computers.Any(x => x.Id == computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computers.FirstOrDefault(x => x.Id == computerId);
        }
    }
}
