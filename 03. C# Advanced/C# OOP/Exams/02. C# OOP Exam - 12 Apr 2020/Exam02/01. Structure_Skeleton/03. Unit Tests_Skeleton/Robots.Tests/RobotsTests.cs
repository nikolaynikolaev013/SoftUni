namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RobotsTests
    {
        RobotManager rm;

        [SetUp]
        public void Setup()
        {
            rm = new RobotManager(20);
        }

        //Constructor
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Assert.That(rm.Capacity, Is.EqualTo(20));
            Assert.That(rm.Count, Is.EqualTo(0));
        }

        [Test]
        public void ConstructorThrowAnExcWhenCapacityLessThanZero()
        { 
            Assert.That(() => new RobotManager(-1), Throws.ArgumentException);
        }

        //AddRobot
        [Test]
        public void AddRobotShouldWorkProperly()
        {
            Robot robot = new Robot("Zelda", 10);

            rm.Add(robot);

            Assert.That(rm.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddRobotShouldThrowAnExcOnRobotExistingRobot()
        {
            Robot robot = new Robot("Zelda", 10);

            rm.Add(robot);

            Assert.That(() => rm.Add(robot), Throws.InvalidOperationException);
            Assert.That(rm.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddRobotShouldThrowAnExcWhenNotEnoughCapacity()
        {
            RobotManager rm2 = new RobotManager(1);
            Robot robot = new Robot("Zelda", 10);

            rm2.Add(robot);

            Assert.That(() => rm2.Add(new Robot("KOLAS", 10)), Throws.InvalidOperationException);
            Assert.That(rm2.Count, Is.EqualTo(1));
        }

        //Remove
        [Test]
        public void RemoveShouldWorkProperly()
        {
            Robot robot = new Robot("Zelda", 10);

            rm.Add(robot);

            rm.Remove(robot.Name);
            Assert.That(rm.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveShouldThrowAnExcOnRobotNotFound()
        {
            Robot robot = new Robot("Zelda", 10);

            Assert.That(() => rm.Remove(robot.Name), Throws.InvalidOperationException);
            Assert.That(rm.Count, Is.EqualTo(0));
        }


        //Work
        [Test]
        public void WorkShouldWorkProperly()
        {
            Robot robot = new Robot("Zelda", 10);

            rm.Add(robot);
            rm.Work(robot.Name, "cleaning", 1);

            Assert.That(robot.Battery, Is.EqualTo(9));
            Assert.That(rm.Count, Is.EqualTo(1));
        }

        [Test]
        public void WorkShouldThrowAnExcOnRobotNotFound()
        {
            Assert.That(() => rm.Work("Penka", "cleaning", 1), Throws.InvalidOperationException);
            Assert.That(rm.Count, Is.EqualTo(0));
        }

        [Test]
        public void WorkShouldThrowAnExcOnJobUsageMoreThanAvailableBattery()
        {
            Robot robot = new Robot("Zelda", 10);

            rm.Add(robot);

            Assert.That(() => rm.Work("Penka", "cleaning", 11), Throws.InvalidOperationException);
            Assert.That(rm.Count, Is.EqualTo(1));
        }

        //Charge
        [Test]
        public void ChargeshouldWorkProperly()
        {
            Robot robot = new Robot("Zelda", 10);

            rm.Add(robot);
            rm.Work(robot.Name, "cleaning", 9);
            rm.Charge(robot.Name);

            Assert.That(robot.Battery, Is.EqualTo(10));
            Assert.That(rm.Count, Is.EqualTo(1));
        }

        [Test]
        public void ChargeshouldThrowAnExcOnRobotNotFound()
        {
            Assert.That(() => rm.Charge("Nikolas"), Throws.InvalidOperationException);
            Assert.That(rm.Count, Is.EqualTo(0));
        }
    }
}
