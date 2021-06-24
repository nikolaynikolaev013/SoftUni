using NUnit.Framework;
using System.Reflection;
using System.Linq;
using Databasee;

namespace Tests
{
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IfAddOperationAddsToTheDataArray()
        {
            db = new Database(new int[] { 1, 2, 3 });

            db.Add(23);

            Assert.That(db.Fetch().Last(), Is.EqualTo(23));
        }

        [Test]
        public void IfArrayCannotAddMoreThan16Items()
        {

            db = new Database(new int[] { 1 });

            for (int i = 0; i < 15; i++)
            {
                db.Add(i);
            }

            Assert.That(() => db.Add(1), Throws.InvalidOperationException, "The array is not throwing invalid operation exception when trying" +
                "to add more than 16 numbers!");
        }

        [Test]
        public void IfRemoveOperationRemovesTheLastItemOnly()
        {
            db = new Database(new int[] { 1, 2 });

            db.Remove();

            Assert.That(db.Fetch().Length, Is.EqualTo(1));
        }

        [Test]
        public void IfRemovingFromAnEmptyArrayThrowsAnInvalidOperationException()
        {
            db = new Database(new int[] { 1, 2 });

            db.Remove();
            db.Remove();
            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void CheckIfFetchReturnsAnArray()
        {
            db = new Database(new int[] { 1, 2 });

            int[] res = db.Fetch();

            Assert.That(res.GetType().ToString(), Is.EqualTo("System.Int32[]"));
        }

        [Test]
        public void EmptyConstructorShouldReturnCountZero()
        {
            db = new Database();
            Assert.That(db.Count == 0);
        }

        [Test]
        public void CheckIfConstructorSetsDataCorrectly()
        {
            int[] data = new int[] { 1, 2, 3 };
            db = new Database(data);

            Assert.That(db.Fetch(), Is.EqualTo(data));
        }

        [Test]
        public void AddShouldIncreaseCount()
        {
            db = new Database(new int[] { 1, 2, 3 });

            db.Add(4);

            Assert.That(db.Count, Is.EqualTo(4));
        }

        [Test]
        public void RemoveShouldDecreaseCount()
        {
            db = new Database(new int[] { 1, 2, 3 });
            db.Remove();

            Assert.That(db.Count, Is.EqualTo(2));
        }
    }
}