using Exercise_1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class CheckoutEventTests
    {
        [TestMethod]
        public void CheckoutEventConstructorTest()
        {
            User user = new User("Albert", "Tomczyk");
            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "description", new DateTime(2008, 5, 11, 8, 30, 23), true);
            Event item = new CheckoutEvent(user, state, new DateTime(2009, 5, 11, 8, 30, 23));

            Assert.AreEqual(user, item.User);
            Assert.AreEqual(state, item.State);
            Assert.AreEqual(new DateTime(2009, 5, 11, 8, 30, 23), item.Date);
        }

        [TestMethod]
        public void CheckoutEventSetTest()
        {
            User user = new User("Albert", "Tomczyk");
            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "description", new DateTime(2008, 5, 11, 8, 30, 23), true);
            Event item = new CheckoutEvent(user, state, new DateTime(2009, 5, 11, 8, 30, 23));

            User user2 = new User("Albert", "Tomczyk");
            Catalog catalog2 = new Catalog("Autor", "Tytul");
            State state2 = new State(catalog, "description", new DateTime(2018, 5, 11, 8, 30, 23), true);

            item.User = user2;
            item.State = state2;
            item.Date = new DateTime(2019, 5, 11, 8, 30, 23);
            

            Assert.AreEqual(user2, item.User);
            Assert.AreEqual(state2, item.State);
            Assert.AreEqual(new DateTime(2019, 5, 11, 8, 30, 23), item.Date);
        }
    }
}