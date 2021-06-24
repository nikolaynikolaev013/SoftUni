using System;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class ComputerTests
    {
        private Computer computer;
        private Part part;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("comp");
            part = new Part("test", 1);
        }

        [Test]
        public void TestThatConstructorSetsValuesProperly()
        {
            Assert.That(computer.Name, Is.EqualTo("comp"));
            Assert.That(computer.Parts.Count, Is.EqualTo(0));
            Assert.That(computer.TotalPrice, Is.EqualTo(0));
        }

        [TestCase(" ")]
        [TestCase(null)]
        public void ConstructurMustReturnExcWhenNameNullOrWhiteSpace(string name)
        {
            Assert.That(() => new Computer(name), Throws.ArgumentNullException);
        }

        [Test]
        public void TestIfAddPartWorksCorrectlyAndSetsTotalPrice()
        {
            computer.AddPart(part);

            Assert.That(computer.Parts.Count, Is.EqualTo(1));
            Assert.That(computer.TotalPrice, Is.EqualTo(1));
            Assert.That(computer.Parts.Last, Is.EqualTo(part));

        }

        [Test]
        public void TestIfAddNullPartThrowsExc()
        {
            Assert.That(() => computer.AddPart(null), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovePartShouldRemovePartAndReturnBool()
        {
            computer.AddPart(part);
            bool res = computer.RemovePart(part);

            Assert.That(computer.Parts.Count, Is.EqualTo(0));
            Assert.That(res, Is.EqualTo(true));
        }

        [Test]
        public void GetPartShouldReturnPart()
        {
            computer.AddPart(part);

            Assert.That(() => computer.GetPart(part.Name), Is.EqualTo(part));
        }

        [Test]
        public void GetPartShouldReturnNullWhenNotFound()
        {
            Assert.That(()=>computer.GetPart("hey"), Is.EqualTo(null));
        }

    }
}