using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class ReturnEventTests
    {
        [TestMethod]
        public void ReturnEventConstructorTest()
        {
            User user = new User("Albert", "Tomczyk");
            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "description", new DateTime(2008, 5, 11, 8, 30, 23), true);
            Event item = new ReturnEvent(user, state, new DateTime(2009, 5, 11, 8, 30, 23));

            Assert.AreEqual(user, item.User);
            Assert.AreEqual(state, item.State);
            Assert.AreEqual(new DateTime(2009, 5, 11, 8, 30, 23), item.Date);
        }

        [TestMethod]
        public void ReturnEventSetTest()
        {
            User user = new User("Albert", "Tomczyk");
            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "description", new DateTime(2008, 5, 11, 8, 30, 23), true);
            Event item = new ReturnEvent(user, state, new DateTime(2009, 5, 11, 8, 30, 23));

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