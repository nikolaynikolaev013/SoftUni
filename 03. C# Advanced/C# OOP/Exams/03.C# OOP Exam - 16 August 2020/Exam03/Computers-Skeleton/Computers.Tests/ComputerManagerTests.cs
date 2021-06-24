using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private const string CanNotBeNullMessage = "Can not be null!";

        private Computer computer;
        private ComputerManager cm;

        [SetUp]
        public void Setup()
        {
            this.computer = new Computer("Apple", "Macbook", 2300);
            this.cm = new ComputerManager();
        }

        [Test]
        public void TestIfConstructorWorksProperly()
        {
            Assert.That(this.cm.Computers.Count, Is.EqualTo(0));
            Assert.That(this.cm.Count, Is.EqualTo(0));
        }

        //AddComputer
        [Test]
        public void CheckIfAddComputerNullThrowsAnExc()
        {
            Assert.That(() => cm.AddComputer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void CheckIfAddingDuplicatedComputerThrowsAnExc()
        {
            cm.AddComputer(computer);
            Assert.That(() => cm.AddComputer(computer), Throws.ArgumentException);
        }

        [Test]
        public void CheckIfAddComputerWorksCorrectly()
        {
            cm.AddComputer(computer);
            Assert.That(cm.Computers.Count, Is.EqualTo(1));
            Assert.That(cm.Computers.Last, Is.EqualTo(computer));
            Assert.That(cm.Count, Is.EqualTo(1));
        }

        //RemoveComputer
        [Test]
        public void CheckIfRemoveComputerWorksProperly()
        {
            cm.AddComputer(computer);
            Computer comp2 =  cm.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.That(cm.Count, Is.EqualTo(0));
            Assert.That(cm.Computers.Count, Is.EqualTo(0));
            Assert.That(comp2, Is.EqualTo(computer));
        }

        //GetComputer
        [Test]
        public void CheckIfNullManufacturerOrModelOrNullComputerReturnsAnExc()
        {
            cm.AddComputer(computer);
            Assert.That(() => cm.GetComputer(null, "model"), Throws.ArgumentNullException);
            Assert.That(()=>cm.GetComputer(computer.Manufacturer, null), Throws.ArgumentNullException);
            Assert.That(() => cm.GetComputer("asus", "something"), Throws.ArgumentException);
        }

        [Test]
        public void CheckIfGetComputerWorksProperly()
        {
            cm.AddComputer(computer);
            Assert.That(() => cm.GetComputer(computer.Manufacturer, computer.Model), Is.EqualTo(computer));
        }

        //GetComputerByManufacturer
        [Test]
        public void CheckIfGetByManuReturnsExcOnNullManu()
        {
            this.cm.AddComputer(computer);

            Assert.That(() => cm.GetComputersByManufacturer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ChecIfGetByManuWorksProperly()
        {
            this.cm.AddComputer(computer);

            ICollection<Computer> comps = new List<Computer>();
            comps.Add(computer);
            Assert.That(() => cm.GetComputersByManufacturer(computer.Manufacturer), Is.EqualTo(comps));
        }
    }
}