using NUnit.Framework;
//using FightingArena;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        //Enroll
        [Test]
        public void ThatEnrollAddsTheWarriorAndUpdatesCountAndCollection()
        {
            List<Warrior> collection = new List<Warrior>()
            {
                new Warrior("Nikolay", 10, 100)
            };

            arena.Enroll(collection[0]);

            Assert.That(arena.Count, Is.EqualTo(1));
            Assert.That(arena.Warriors, Is.EqualTo(collection));
        }

        [Test]
        public void EnrollShouldThrowExceptionWhenWarriorIsInTheCollectionAlready()
        {
            List<Warrior> collection = new List<Warrior>()
            {
                new Warrior("Nikolay", 10, 100)
            };

            arena.Enroll(collection[0]);

            Assert.That(() => arena.Enroll(collection[0]), Throws.InvalidOperationException);
        }

        //Fight
        [Test]
        public void ShouldThrowExcIfOneOfTheWarrioursIsNotInTheCollection()
        {
            List<Warrior> collection = new List<Warrior>()
            {
                new Warrior("Nikolay", 10, 100),
                new Warrior("Nick", 20, 100),
                new Warrior("Stefka", 10, 100)
            };

            arena.Enroll(collection[0]);
            arena.Enroll(collection[1]);

            Assert.That(() => arena.Fight(collection[0].Name, collection[2].Name), Throws.InvalidOperationException);
            Assert.That(() => arena.Fight(collection[1].Name, collection[2].Name), Throws.InvalidOperationException);
        }

    }
}
