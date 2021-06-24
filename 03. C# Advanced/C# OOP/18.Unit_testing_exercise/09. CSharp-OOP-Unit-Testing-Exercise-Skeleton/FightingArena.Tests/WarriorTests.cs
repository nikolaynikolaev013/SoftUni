using NUnit.Framework;
//using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
        }


        //Constructor
        [Test]
        public void IfConstructorWorksCorrectly()
        {
            warrior = new Warrior("Nikolay", 20, 100);
            Assert.That(warrior.Name, Is.EqualTo("Nikolay"));
            Assert.That(warrior.Damage, Is.EqualTo(20));
            Assert.That(warrior.HP, Is.EqualTo(100));
        }

        [TestCase(" ")]
        [TestCase("")]
        public void IfNameIsWhitespaceOfNullShouldThrowExc(string name)
        {
            Assert.That(() => new Warrior(name, 20, 100), Throws.ArgumentException);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void IfDamageIsZeroOrNegativeShouldThrowExc(int damage)
        {
            Assert.That(() => new Warrior("Nikolay", damage, 100), Throws.ArgumentException);
        }

        [TestCase(-2)]
        public void IfHPsZeroOrNegativeShouldThrowExc(int hp)
        {
            Assert.That(() => new Warrior("Nikolay", 20, hp), Throws.ArgumentException);
        }


        //Attack
        [TestCase(100, 20)]
        [TestCase(100, 30)]
        [TestCase(20, 100)]
        [TestCase(30, 100)]
        public void IfWarriorsHPIsZeroOrNegativeShouldThrowExc(int hp1, int hp2)
        {
            Warrior thisWarrior = new Warrior("Nikolay", 20, hp1);
            Warrior attackedWarrior = new Warrior("Nikolay", 20, hp2);

            Assert.That(() => thisWarrior.Attack(attackedWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void IfAttackingWarriorDamageIsBiggerThanAttackerHP()
        {
            Warrior thisWarrior = new Warrior("Nikolay", 100, 90);
            Warrior attackedWarrior = new Warrior("Nick", 100, 100);

            Assert.That(() => thisWarrior.Attack(attackedWarrior), Throws.InvalidOperationException);
        }

        [Test]
        public void AttackingWarriourShouldGetHPDecreasedOnAttack()
        {
            Warrior thisWarrior = new Warrior("Nikolay", 50, 100);
            Warrior attackedWarrior = new Warrior("Nick", 40, 100);
            thisWarrior.Attack(attackedWarrior);

            Assert.That(thisWarrior.HP, Is.EqualTo(60));
        }

        [Test]
        public void IfAttackerDamageIsBiggerThanEnemyHPWhouldSetTheEnemyHPToZero()
        {
            Warrior thisWarrior = new Warrior("Nikolay", 50, 100);
            Warrior attackedWarrior = new Warrior("Nick", 40, 40);

            thisWarrior.Attack(attackedWarrior);

            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void IfAttackerDamageIsLowerhanEnemyHPWhouldDecreaseItCorrectly()
        {
            Warrior thisWarrior = new Warrior("Nikolay", 50, 100);
            Warrior attackedWarrior = new Warrior("Nick", 40, 60);

            thisWarrior.Attack(attackedWarrior);

            Assert.That(attackedWarrior.HP, Is.EqualTo(10));
        }

    }
}