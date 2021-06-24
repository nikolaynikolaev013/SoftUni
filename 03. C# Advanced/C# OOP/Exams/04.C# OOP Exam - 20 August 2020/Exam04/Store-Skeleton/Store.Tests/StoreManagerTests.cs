using System.Linq;
using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private StoreManager sm;
        [SetUp]
        public void Setup()
        {
            sm = new StoreManager();
        }

        [Test]
        public void TestIfCoonstructorWorksCorrectly()
        {
            Assert.That(sm.Count, Is.EqualTo(0));
            Assert.That(sm.Products.Count, Is.EqualTo(0));
        }

        //AddProduct
        [Test]
        public void AddProductShouldReturnExcOnProductNullOrNegativeQuantity()
        {
            Product testProduct = new Product("Carrots", -1, 1.20m);
            Assert.That(() => sm.AddProduct(null), Throws.ArgumentNullException);
            Assert.That(() => sm.AddProduct(testProduct), Throws.ArgumentException);
            Assert.That(sm.Count, Is.EqualTo(0));
            Assert.That(sm.Products.Count, Is.EqualTo(0));
        }

        //AddProduct
        [Test]
        public void AddProductShoudWorkProperly()
        {
            Product testProduct = new Product("Carrots", 10, 1.20m);
            sm.AddProduct(testProduct);
            Assert.That(() => sm.Products.Last(), Is.EqualTo(testProduct));
            Assert.That(sm.Count, Is.EqualTo(1));
            Assert.That(sm.Products.Count, Is.EqualTo(1));
        }

        //BuyProduct
        [Test]
        public void BuyProductShouldTrowExcOnProductNotFoundOrQuantityLessThanWanted()
        {
            Product product = new Product("Carrots", 2, 1.20m);

            sm.AddProduct(product);

            Assert.That(() => sm.BuyProduct("Potato", 10), Throws.ArgumentNullException);
            Assert.That(() => sm.BuyProduct("Carrots", 3), Throws.ArgumentException);
            Assert.That(sm.Count, Is.EqualTo(1));
            Assert.That(sm.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void BuyProductShouldWorkProperly()
        {
            Product product = new Product("Tomatoes", 3, 2.3m);

            sm.AddProduct(product);

            decimal finalPrice = sm.BuyProduct("Tomatoes", 2);

            Assert.That(sm.Products.FirstOrDefault(x=>x.Name == product.Name).Quantity, Is.EqualTo(1));
            Assert.That(finalPrice, Is.EqualTo(4.6m));

            Assert.That(sm.Count, Is.EqualTo(1));
            Assert.That(sm.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetTheMostExpensiveProductShoudlWokPRoperly()
        {
            Product product = new Product("Tomatoes", 3, 2.3m);
            Product product1 = new Product("Chio", 2, 2.0m);
            Product product2 = new Product("Lazagna", 5, 7.80m);
            Product product3 = new Product("Gum", 10, 1.0m);

            sm.AddProduct(product);
            sm.AddProduct(product1);
            sm.AddProduct(product2);
            sm.AddProduct(product3);

            Assert.That(sm.GetTheMostExpensiveProduct(), Is.EqualTo(product2));

            Assert.That(sm.Count, Is.EqualTo(4));
            Assert.That(sm.Products.Count, Is.EqualTo(4));
        }
    }
}