using NUnit.Framework;
using CarManager;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
        }

        //Constructors

        public void ConstructorShouldSedFuelAmountToZero()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
        //Make
        [Test]
        public void IfEmptyMakeThrowsArgExc()
        {
            Assert.That(() => car = new Car(string.Empty, "Benz", 2.2, 50.0), Throws.ArgumentException);
        }
        [Test]
        public void IfMakeIsCorrectlySet()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            Assert.That(car.Make, Is.EqualTo("Mercedes"));
        }

        //Model
        [Test]
        public void IfEmptyModelThrowsArgExc()
        {
            Assert.That(() => car = new Car("Mercedes", string.Empty, 2.2, 50.0), Throws.ArgumentException);
        }
        [Test]
        public void IfModelIfCorrectlySet()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            Assert.That(car.Model, Is.EqualTo("Benz"));
        }

        //FuelConsumption
        [TestCase(0)]
        [TestCase(-2)]
        public void IfNegativeOfZeroFuelConsumptionThrowsArgExc(double fuel)
        {
            Assert.That(() => car = new Car("Mercedes", "Benz", fuel, 50.0), Throws.ArgumentException);
        }
        [Test]
        public void IfFuelConsumptionIsCorrectlySet()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            Assert.That(car.FuelConsumption, Is.EqualTo(2.2));
        }

        //FuelCapacity
        [TestCase(0)]
        [TestCase(-2)]
        public void IfNegativeOfZeroFuelCapacityThrowsArgExc(double capacity)
        {
            Assert.That(() => car = new Car("Mercedes", "Benz", 2.2, capacity), Throws.ArgumentException);
        }
        [Test]
        public void IfFuelCapacityIsCorrectlySet()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            Assert.That(car.FuelCapacity, Is.EqualTo(50.0));
        }

        //Refuel

        [TestCase(0)]
        [TestCase(-5)]
        public void IfNEgativeOfZeroReFuelThrowsArgExc(int fuel)
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            Assert.That(() => car.Refuel(fuel), Throws.ArgumentException);
        }

        [Test]
        public void IfFUelAmountIsUpdatedOnRefuel()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            car.Refuel(1);
            Assert.That(car.FuelAmount, Is.EqualTo(1));
        }

        [Test]
        public void IfMoreFuelIsRefilledThatCapacityTheyBecomeEqual()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            car.Refuel(52.00);
            Assert.That(car.FuelAmount, Is.EqualTo(50.0));
        }

        //Drive
        [Test]
        public void IfNotEnoughFuelThrowsAnExc()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            
            Assert.That(() => car.Drive(1), Throws.InvalidOperationException);
        }

        [Test]
        public void IfDrivenSuccessfullyAndFuelAmountIsUpdated()
        {
            car = new Car("Mercedes", "Benz", 2.2, 50.0);
            car.Refuel(2.2);
            car.Drive(100);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
    }
}