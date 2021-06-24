using System;
using NUnit.Framework;

namespace Robots.Tests
{
    [TestFixture]
    public class RobotClassTests
    {
        [Test]
        public void RobotConstructorShouldWorkProperly()
        {
            Robot robot = new Robot("Nik", 2);
            Assert.That(robot.Name, Is.EqualTo("Nik"));
            Assert.That(robot.MaximumBattery, Is.EqualTo(2));
        }
    }
}
