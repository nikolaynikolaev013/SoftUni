using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bv;
        private Item item;
        private new Dictionary<string, Item> vaultCells;

           [SetUp]
        public void Setup()
        {
           this.bv = new BankVault();
           this.item = new Item("Nikolay", "123");

            vaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
        }

        //Constructor
        [Test]
        public void IfConstructorWorksCorrect()
        {

            Assert.That(bv.VaultCells.Count, Is.EqualTo(12));
            Assert.That(bv.VaultCells, Is.EqualTo(vaultCells));
        }

        //addItem
        [Test]
        public void AddItemShouldThrowExceptionOnInvalidCell()
        {
            Assert.That(() => bv.AddItem("A5", item), Throws.ArgumentException);
        }

        [Test]
        public void AddItemShouldThrowExceptionOnTakenCelll()
        {
            Item item2 = new Item("Nick", "124");
            bv.AddItem("A1", item);
            Assert.That(() => bv.AddItem("A1", item2), Throws.ArgumentException);
        }
        [Test]
        public void AddItemShouldThrowAnExcOnItemAlreadyInCell()
        {
            bv.AddItem("A1", item);
            Assert.That(() => bv.AddItem("A2", item), Throws.InvalidOperationException);
            Assert.That(bv.VaultCells.Count, Is.EqualTo(12));
        }
        [Test]
        public void AddItemShouldWorkCorrectly()
        {
            Assert.That(() => bv.AddItem("A1", item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
            Assert.That(bv.VaultCells["A1"], Is.EqualTo(item));
            Assert.That(bv.VaultCells.Count, Is.EqualTo(12));
        }

        //RemoveItem
        [Test]
        public void RemoveItemShouldThrowAnExcOnCellNotExists()
        {
            Assert.That(() => bv.RemoveItem("A5", item), Throws.ArgumentException);
            Assert.That(bv.VaultCells.Count, Is.EqualTo(12));
            Assert.That(bv.VaultCells, Is.EqualTo(vaultCells));
        }

        [Test]
        public void RemoveItemShouldThrowAnExcOnItemDoesntExist()
        {
            bv.AddItem("A1", new Item("Nick", "124"));
            Assert.That(() => bv.RemoveItem("A1", item), Throws.ArgumentException);
            Assert.That(bv.VaultCells.Count, Is.EqualTo(12));
        }

        [Test]
        public void RemoveItemShouldWorkProperly()
        {
            bv.AddItem("A1", item);
            Assert.That(() => bv.RemoveItem("A1", item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
            Assert.That(bv.VaultCells["A1"], Is.EqualTo(null));
            Assert.That(bv.VaultCells.Count, Is.EqualTo(12));
        }

    }
}