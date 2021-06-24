using NUnit.Framework;
using ExtendedDatabaseNS;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
        }


        //CONSTRUCTOR

        [Test]
        public void IfPersonsAreAddedCorrectly()
        {
           //TODO
        }

        [Test]
        public void IfMoreThanSixteenPErsonsExcIsThrown()
        {
            Assert.That(() => db = new ExtendedDatabase(new Person[17]), Throws.ArgumentException);
        }

        [Test]
        public void IfCountIsUpdatedOnAdd()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });

            Assert.That(db.Count, Is.EqualTo(1));
        }

        //ADD
        [Test]
        public void IfAddingMoreThanSixteenPersonsThrowsAnExc()
        {
            db = new ExtendedDatabase();

            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, "user" + i));
            }

            Assert.That(() => db.Add(new Person(21, "Kokolay")), Throws.InvalidOperationException);
        }

        [Test]
        public void IfAddingTheSameUserThrowsException()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });


            Assert.That(() => db.Add(new Person(22, "Nikolay")), Throws.InvalidOperationException);
        }

        [Test]
        public void IfAddingTheSameIDThrowsExceptiondatedOnAdd()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });


            Assert.That(() => db.Add(new Person(21, "Kokolay")), Throws.InvalidOperationException);
        }


        //Null
        [Test]
        public void IfAddingANullNameThrowsException()
        {
            Assert.That(() =>
            db = new ExtendedDatabase(new Person[] {
                new Person(21, null)
            }), Throws.InvalidOperationException);
        }

        //FindByUserName
        [Test]
        public void IfSearchingByEmptyStringThrowsAnExc()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });


            Assert.That(() => db.FindByUsername(string.Empty), Throws.ArgumentNullException);
        }

        [Test]
        public void IfUserNotFoundThrowsExc()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });


            Assert.That(() => db.FindByUsername("Kokolay"), Throws.InvalidOperationException);
        }

        [Test]
        public void IfUserIsFoundReturnsTheUser()
        {
            Person p = new Person(21, "Nikolay");

            db = new ExtendedDatabase(new Person[] {
                p
            });


            Assert.That(() => db.FindByUsername(p.UserName), Is.EqualTo(p));
        }

        //FindByID
        [Test]
        public void IfSearchByNegativeIDThrowsExc()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });


            Assert.That(() => db.FindById(-1), Throws.Exception);
        }

        [Test]
        public void IfIDNotFoundThrowsExc()
        {
            db = new ExtendedDatabase(new Person[] {
                new Person(21, "Nikolay")
            });


            Assert.That(() => db.FindById(20), Throws.InvalidOperationException);
        }

        [Test]
        public void IfUserByIDIsFoundReturnsTheUser()
        {
            Person p = new Person(21, "Nikolay");

            db = new ExtendedDatabase(new Person[] {
                p
            });


            Assert.That(() => db.FindById(p.Id), Is.EqualTo(p));
        }

        //Remove
        [Test]
        public void IfCountIsZeroRemoveShouldReturnExc()
        {
            Person p = new Person(21, "Nikolay");

            db = new ExtendedDatabase(new Person[] {
                p
            });

            db.Remove();

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            Person p = new Person(21, "Nikolay");

            db = new ExtendedDatabase(new Person[] {
                p
            });

            db.Remove();

            Assert.That(db.Count, Is.EqualTo(0));
        }
    }
}