﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        //TODO: Zbadać negatywne przypadki!
        //TODO: Zmienić trochę po dodaniu Fillera
        [TestMethod()]
        public void AddAndGetUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Assert.AreEqual(dataRepository.GetUser(0), user);
        }

        [TestMethod()]
        public void GetAllUsersTest() //TODO: Nie jestem tego pewny, czy ten test dobrze testuje
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            User user1 = new User("Tomek", "Kowalski");
            User user2 = new User("Mateusz", "Kowalski");
            User user3 = new User("Wojtek", "Kowalski");
            User user4 = new User("Jan", "Kowalski");

            dataRepository.AddUser(user1);
            dataRepository.AddUser(user2);
            dataRepository.AddUser(user3);
            dataRepository.AddUser(user4);

            IEnumerable<User> enumerable = dataRepository.GetAllUsers();
            List<User> users = enumerable.ToList();

            Assert.AreEqual(users.Count, dataRepository.DataContext.Users.Count);

            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] != dataRepository.DataContext.Users[i])
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            dataRepository.UpdateUser(0, "Marcin", "Nowak");

            Assert.AreEqual(dataRepository.GetUser(0).FirstName, "Marcin");
            Assert.AreEqual(dataRepository.GetUser(0).LastName, "Nowak");
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            dataRepository.DeleteUser(user);

            Assert.AreEqual(dataRepository.DataContext.Users.Count, 0);
        }

        [TestMethod()]
        public void AddAndGetCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            Assert.AreEqual(dataRepository.GetCatalog(0), catalog);
        }

        [TestMethod()]
        public void GetAllCatalogsTest() //TODO: Nie jestem tego pewny, czy ten test dobrze testuje  
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog1 = new Catalog("Autor1", "Tytul1");
            Catalog catalog2 = new Catalog("Autor2", "Tytul2");
            Catalog catalog3 = new Catalog("Autor3", "Tytul3");
            Catalog catalog4 = new Catalog("Autor4", "Tytul4");

            dataRepository.AddCatalog(catalog1);
            dataRepository.AddCatalog(catalog2);
            dataRepository.AddCatalog(catalog3);
            dataRepository.AddCatalog(catalog4);

            IEnumerable<Catalog> enumerable = dataRepository.GetAllCatalogs();
            List<Catalog> catalogs = enumerable.ToList();

            Assert.AreEqual(catalogs.Count, dataRepository.DataContext.Catalogs.Count);

            for (int i = 0; i < catalogs.Count; i++)
            {
                if (catalogs[i] != dataRepository.DataContext.Catalogs[i])
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            dataRepository.UpdateCatalog(0, "Autorzy", "Tytuly");

            Assert.AreEqual(dataRepository.GetCatalog(0).Author, "Autorzy");
            Assert.AreEqual(dataRepository.GetCatalog(0).Title, "Tytuly");
        }

        [TestMethod()]
        public void DeleteCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog1 = new Catalog("Autor1", "Tytul1");
            Catalog catalog2 = new Catalog("Autor2", "Tytul2");

            dataRepository.AddCatalog(catalog1);
            dataRepository.AddCatalog(catalog2);

            dataRepository.DeleteCatalog(catalog2);

            Assert.AreEqual(dataRepository.DataContext.Catalogs.Count, 1);
        }

        [TestMethod()]
        public void AddAndGetStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            dataRepository.AddState(state);

            Assert.AreEqual(dataRepository.GetState(0), state);
        }

        [TestMethod()]
        public void GetAllStatesTest() //TODO: Nie jestem tego pewny, czy ten test dobrze testuje
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog1 = new Catalog("Autor1", "Tytul1");
            Catalog catalog2 = new Catalog("Autor2", "Tytul2");
            Catalog catalog3 = new Catalog("Autor3", "Tytul3");
            Catalog catalog4 = new Catalog("Autor4", "Tytul4");

            State state1 = new State(catalog1, "opis1", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            State state2 = new State(catalog2, "opis2", 6, new DateTime(2008, 5, 12, 8, 30, 23));
            State state3 = new State(catalog3, "opis3", 7, new DateTime(2008, 5, 13, 8, 30, 23));
            State state4 = new State(catalog4, "opis4", 8, new DateTime(2008, 5, 14, 8, 30, 23));

            dataRepository.AddState(state1);
            dataRepository.AddState(state2);
            dataRepository.AddState(state3);
            dataRepository.AddState(state4);

            IEnumerable<State> enumerable = dataRepository.GetAllStates();
            List<State> states = enumerable.ToList();

            Assert.AreEqual(states.Count, dataRepository.DataContext.States.Count);

            for (int i = 0; i < states.Count; i++)
            {
                if (states[i] != dataRepository.DataContext.States[i])
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            dataRepository.AddState(state);


            dataRepository.UpdateState(0, "oPIS", 7, new DateTime(2008, 5, 13, 8, 30, 23));

            Assert.AreEqual(dataRepository.GetState(0).Description, "oPIS");
            Assert.AreEqual(dataRepository.GetState(0).Amount, 7);
            Assert.AreEqual(dataRepository.GetState(0).DateOfPurchase, new DateTime(2008, 5, 13, 8, 30, 23));
        }

        [TestMethod()]
        public void DeleteStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog1 = new Catalog("Autor", "Tytul");
            State state1 = new State(catalog1, "opis", 7, new DateTime(2008, 5, 11, 8, 30, 23));

            Catalog catalog2 = new Catalog("Autorzy", "Tytuly");
            State state2 = new State(catalog2, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));

            dataRepository.AddState(state1);
            dataRepository.AddState(state2);

            dataRepository.DeleteState(state2);

            Assert.AreEqual(dataRepository.DataContext.States.Count, 1);
        }

        [TestMethod()]
        public void AddAndGetEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            User user = new User("Tomek", "Kowalski");
            Event item = new Event(user, state, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));
            dataRepository.AddEvent(item);

            Assert.AreEqual(dataRepository.GetEvent(0), item);
        }

        [TestMethod()]
        public void GetAllEventsTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog1 = new Catalog("Autor", "Tytul");
            State state1 = new State(catalog1, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            User user1 = new User("Tomek", "Kowalski");
            Event item1 = new Event(user1, state1, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));
            dataRepository.AddEvent(item1);

            Catalog catalog2 = new Catalog("Autor", "Tytul");
            State state2 = new State(catalog2, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            User user2 = new User("Tomek", "Kowalski");
            Event item2 = new Event(user2, state2, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));
            dataRepository.AddEvent(item2);


            IEnumerable<Event> enumerable = dataRepository.GetAllEvents();
            List<Event> items = enumerable.ToList();

            Assert.AreEqual(items.Count, dataRepository.DataContext.Events.Count);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] != dataRepository.DataContext.Events[i])
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            User user = new User("Tomek", "Kowalski");
            Event item = new Event(user, state, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));
            dataRepository.AddEvent(item);

            dataRepository.UpdateEvent(0, new DateTime(2008, 5, 14, 8, 30, 23), new DateTime(2008, 5, 16, 8, 30, 23));

            Assert.AreEqual(dataRepository.GetEvent(0).RentalDate, new DateTime(2008, 5, 14, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetEvent(0).GiveBackDate, new DateTime(2008, 5, 16, 8, 30, 23));
        }

        [TestMethod()]
        public void DeleteEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
            User user = new User("Tomek", "Kowalski");
            Event item = new Event(user, state, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));

            Catalog catalog2 = new Catalog("Autorzy", "Tytuly");
            State state2 = new State(catalog2, "opisy", 6, new DateTime(2008, 5, 11, 8, 30, 23));
            User user2 = new User("Tomek", "Kowalski");
            Event item2 = new Event(user2, state2, new DateTime(2008, 5, 14, 8, 30, 23), new DateTime(2008, 5, 17, 8, 30, 23));

            dataRepository.AddEvent(item);
            dataRepository.AddEvent(item2);

            dataRepository.DeleteEvent(item2);

            Assert.AreEqual(dataRepository.DataContext.Events.Count, 1);
        }
    }
}