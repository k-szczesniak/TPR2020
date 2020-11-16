using Exercise_1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exercise_1.Tests.Data
{
    [TestClass()]
    public class StateTests
    {
        [TestMethod]
        public void StateConstructorTest()
        {
            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "description", new DateTime(2008, 5, 11, 8, 30, 23), true);

            Assert.AreEqual(catalog, state.Catalog);
            Assert.AreEqual("description", state.Description);
            Assert.AreEqual(new DateTime(2008, 5, 11, 8, 30, 23), state.DateOfPurchase);
            Assert.AreEqual(true, state.IsAvailable);
        }

        [TestMethod]
        public void StateSetTest()
        {
            Catalog catalog = new Catalog("Autor", "Tytul");
            Catalog catalog2 = new Catalog("Autorzy", "Tytuly");
            State state = new State(catalog, "description", new DateTime(2008, 5, 11, 8, 30, 23), true);

            state.Catalog = catalog2;
            state.Description = "description";
            state.DateOfPurchase = new DateTime(2008, 5, 17, 8, 30, 23);
            state.IsAvailable = false;

            Assert.AreEqual(catalog2, state.Catalog);
            Assert.AreEqual("description", state.Description);
            Assert.AreEqual(new DateTime(2008, 5, 17, 8, 30, 23), state.DateOfPurchase);
            Assert.AreEqual(false, state.IsAvailable);
        }
    }
}