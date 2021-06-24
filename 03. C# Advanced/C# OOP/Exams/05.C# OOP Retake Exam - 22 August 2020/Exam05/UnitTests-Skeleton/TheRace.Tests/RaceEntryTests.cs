using System;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry re;
        private UnitCar car;
        private UnitDriver driver;

        [SetUp]
        public void Setup()
        {
            re = new RaceEntry();
            car = new UnitCar("Tesla", 650, 1);
            driver = new UnitDriver("Mitko", car);
        }

        //Constructor
        [Test]
        public void TestIfTheConstructorWorksProperly()
        {
            Assert.That(re.Counter, Is.EqualTo(0));
        }

        //AddDriver
        [Test]
        public void AddDriverShouldWorkProperly()
        {
            re.AddDriver(driver);

            Assert.That(re.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriverShouldTrowExcOnNullDriverOrExisting()
        {
            re.AddDriver(driver);

            Assert.That(() => re.AddDriver(null), Throws.InvalidOperationException);
            Assert.That(() => re.AddDriver(driver), Throws.InvalidOperationException);
            Assert.That(re.Counter, Is.EqualTo(1));
        }

        //CalcuateAverageHorsePower
        [Test]
        public void CalculateAvgShouldThrowAnExcOnDriverCountLessThanTwo()
        {
            re.AddDriver(driver);

            Assert.That(() => re.CalculateAverageHorsePower(), Throws.InvalidOperationException);
            Assert.That(re.Counter, Is.EqualTo(1));
        }

        [Test]
        public void CalculateAvgShouldWorkProperly()
        {
            re.AddDriver(driver);
            re.AddDriver(new UnitDriver("Nikolay", new UnitCar("Mitsubishi", 101, 1800)));
            re.AddDriver(new UnitDriver("Sonya", new UnitCar("Open", 67, 1000)));

            double expectedResult = (650 + 101 + 67.0) / 3.0;

            Assert.That( () => re.CalculateAverageHorsePower(), Is.EqualTo(expectedResult));
            Assert.That(re.Counter, Is.EqualTo(3));
        }
    }
}