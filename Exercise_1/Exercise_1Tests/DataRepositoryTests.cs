using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(dataRepository.GetUser(dataRepository.DataContext.Users.Count - 1), user);
        }

        [TestMethod()]
        public void GetUserIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Assert.ThrowsException<Exception>(() => dataRepository.GetUser(dataRepository.DataContext.Users.Count));
            Assert.ThrowsException<Exception>(() => dataRepository.GetUser(-1));
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

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
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            User user = new User("Tomek", "Tomkowski");
            dataRepository.AddUser(user);

            Assert.AreEqual(dataRepository.GetUser(dataRepository.DataContext.Users.Count - 1).FirstName, "Tomek");
            Assert.AreEqual(dataRepository.GetUser(dataRepository.DataContext.Users.Count - 1).LastName, "Tomkowski");

            dataRepository.UpdateUser(dataRepository.DataContext.Users.Count - 1, "Marcin", "Nowak");

            Assert.AreEqual(dataRepository.GetUser(dataRepository.DataContext.Users.Count - 1).FirstName, "Marcin");
            Assert.AreEqual(dataRepository.GetUser(dataRepository.DataContext.Users.Count - 1).LastName, "Nowak");
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            int numberOfUsersBeforeAdd = dataRepository.DataContext.Users.Count;

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Assert.AreEqual(numberOfUsersBeforeAdd + 1, dataRepository.DataContext.Users.Count);

            dataRepository.DeleteUser(user);

            Assert.AreEqual(dataRepository.DataContext.Users.Count, numberOfUsersBeforeAdd);
        }

        [TestMethod()]
        public void AddAndGetCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            Assert.AreEqual(dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count - 1), catalog);
        }

        [TestMethod()]
        public void GetAllCatalogsTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

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
        }

        [TestMethod()]
        public void UpdateCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            Assert.AreEqual(dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count - 1).Author, "Autor");
            Assert.AreEqual(dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count - 1).Title, "Tytul");

            dataRepository.UpdateCatalog(dataRepository.DataContext.Catalogs.Count - 1, "Autorzy", "Tytuly");

            Assert.AreEqual(dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count - 1).Author, "Autorzy");
            Assert.AreEqual(dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count - 1).Title, "Tytuly");
        }

        [TestMethod()]
        public void DeleteCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            int numberOfCatalogsBeforeAdd = dataRepository.DataContext.Catalogs.Count;

            Catalog catalog = new Catalog("Autor1", "Tytul1");
            dataRepository.AddCatalog(catalog);

            Assert.AreEqual(numberOfCatalogsBeforeAdd + 1, dataRepository.DataContext.Catalogs.Count);

            dataRepository.DeleteCatalog(catalog);

            Assert.AreEqual(dataRepository.DataContext.Catalogs.Count, numberOfCatalogsBeforeAdd);
        }

        [TestMethod()]
        public void AddAndGetStateTest() 
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            Assert.AreEqual(dataRepository.GetState(dataRepository.DataContext.States.Count - 1), state);
        }

        [TestMethod()]
        public void GetAllStatesTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

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
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            int indexOfState = dataRepository.DataContext.States.Count - 1;

            Assert.AreEqual(dataRepository.GetState(indexOfState).Description, "opis");
            Assert.AreEqual(dataRepository.GetState(indexOfState).DateOfPurchase, new DateTime(2008, 5, 11, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(indexOfState).IsAvailable, true);


            dataRepository.UpdateState(indexOfState, "oPIS", new DateTime(2008, 5, 13, 8, 30, 23), true);

            Assert.AreEqual(dataRepository.GetState(indexOfState).Description, "oPIS");
            Assert.AreEqual(dataRepository.GetState(indexOfState).DateOfPurchase, new DateTime(2008, 5, 13, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(indexOfState).IsAvailable, true);
        }

        [TestMethod()]
        public void DeleteStateTest() //TODO: Amount zniknie i pojawi się available
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            int numberOfStatesBeforeAdd = dataRepository.DataContext.States.Count;

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            Assert.AreEqual(numberOfStatesBeforeAdd + 1, dataRepository.DataContext.States.Count);

            dataRepository.DeleteState(state);

            Assert.AreEqual(dataRepository.DataContext.States.Count, numberOfStatesBeforeAdd);
        }

        //[TestMethod()]
        //public void AddAndGetEventTest()
        //{
        //    DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

        //    Catalog catalog = new Catalog("Autor", "Tytul");
        //    State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
        //    User user = new User("Tomek", "Kowalski");
        //    Event item = new Event(user, state, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));
        //    dataRepository.AddEvent(item);

        //    Assert.AreEqual(dataRepository.GetEvent(0), item);
        //}

        //[TestMethod()]
        //public void GetAllEventsTest()
        //{
        //    DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

        //    IEnumerable<Event> enumerable = dataRepository.GetAllEvents();
        //    List<Event> items = enumerable.ToList();

        //    Assert.AreEqual(items.Count, dataRepository.DataContext.Events.Count);

        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        if (items[i] != dataRepository.DataContext.Events[i])
        //        {
        //            Assert.Fail();
        //        }
        //    }
        //}

        //[TestMethod()]
        //public void UpdateEventTest()
        //{
        //    DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

        //    Catalog catalog = new Catalog("Autor", "Tytul");
        //    State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
        //    User user = new User("Tomek", "Kowalski");
        //    Event item = new Event(user, state, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));
        //    dataRepository.AddEvent(item);

        //    dataRepository.UpdateEvent(0, new DateTime(2008, 5, 14, 8, 30, 23), new DateTime(2008, 5, 16, 8, 30, 23));

        //    Assert.AreEqual(dataRepository.GetEvent(0).RentalDate, new DateTime(2008, 5, 14, 8, 30, 23));
        //    Assert.AreEqual(dataRepository.GetEvent(0).GiveBackDate, new DateTime(2008, 5, 16, 8, 30, 23));
        //}

        //[TestMethod()]
        //public void DeleteEventTest()
        //{
        //    DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

        //    Catalog catalog = new Catalog("Autor", "Tytul");
        //    State state = new State(catalog, "opis", 5, new DateTime(2008, 5, 11, 8, 30, 23));
        //    User user = new User("Tomek", "Kowalski");
        //    Event item = new Event(user, state, new DateTime(2008, 5, 13, 8, 30, 23), new DateTime(2008, 5, 15, 8, 30, 23));

        //    Catalog catalog2 = new Catalog("Autorzy", "Tytuly");
        //    State state2 = new State(catalog2, "opisy", 6, new DateTime(2008, 5, 11, 8, 30, 23));
        //    User user2 = new User("Tomek", "Kowalski");
        //    Event item2 = new Event(user2, state2, new DateTime(2008, 5, 14, 8, 30, 23), new DateTime(2008, 5, 17, 8, 30, 23));

        //    dataRepository.AddEvent(item);
        //    dataRepository.AddEvent(item2);

        //    dataRepository.DeleteEvent(item2);

        //    Assert.AreEqual(dataRepository.DataContext.Events.Count, 1);
        //}
    }
}