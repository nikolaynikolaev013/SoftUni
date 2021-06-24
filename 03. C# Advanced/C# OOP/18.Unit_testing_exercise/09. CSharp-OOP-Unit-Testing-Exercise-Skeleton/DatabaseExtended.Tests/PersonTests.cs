using NUnit.Framework;
using ExtendedDatabaseNS;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private Person p;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IfIDisAssignedPRoperly()
        {
            p = new Person(12, "userName");

            Assert.That(12, Is.EqualTo(p.Id));
        }

        [Test]
        public void IfNameIsAssignedPRoperly()
        {
            p = new Person(12, "userName");

            Assert.That("userName", Is.EqualTo(p.UserName));
        }
    }
}
