using Exercise_1.Data;
using Exercise_1.Tests.ImplementationsForTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_1.Tests.Data
{
    [TestClass()]
    public class DataRepositoryTests
    {
        [TestMethod()]
        public void AddAndGetUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Assert.AreEqual(dataRepository.GetUser(dataRepository.DataContext.Users.Count - 1), user);
        }

        [TestMethod()]
        public void GetUserIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Assert.ThrowsException<Exception>(() => dataRepository.GetUser(dataRepository.DataContext.Users.Count));
            Assert.ThrowsException<Exception>(() => dataRepository.GetUser(-1));
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

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
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            User user = new User("Tomek", "Tomkowski");
            dataRepository.AddUser(user);

            int userIndex = dataRepository.DataContext.Users.Count - 1;

            Assert.AreEqual(dataRepository.GetUser(userIndex).FirstName, "Tomek");
            Assert.AreEqual(dataRepository.GetUser(userIndex).LastName, "Tomkowski");

            dataRepository.UpdateUser(userIndex, "Marcin", "Nowak");

            Assert.AreEqual(dataRepository.GetUser(userIndex).FirstName, "Marcin");
            Assert.AreEqual(dataRepository.GetUser(userIndex).LastName, "Nowak");
        }

        [TestMethod()]
        public void UpdateUserIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            User user = new User("Tomek", "Tomkowski");
            dataRepository.AddUser(user);

            int userIndex = dataRepository.DataContext.Users.Count - 1;

            Assert.AreEqual(dataRepository.GetUser(userIndex).FirstName, "Tomek");
            Assert.AreEqual(dataRepository.GetUser(userIndex).LastName, "Tomkowski");

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateUser(userIndex + 1, "Marcin", "Nowak"));
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateUser(-1, "Marcin", "Nowak"));

            Assert.AreEqual(dataRepository.GetUser(userIndex).FirstName, "Tomek");
            Assert.AreEqual(dataRepository.GetUser(userIndex).LastName, "Tomkowski");
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfUsersBeforeAdd = dataRepository.DataContext.Users.Count;

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Assert.AreEqual(numberOfUsersBeforeAdd + 1, dataRepository.DataContext.Users.Count);

            dataRepository.DeleteUser(user);

            Assert.AreEqual(dataRepository.DataContext.Users.Count, numberOfUsersBeforeAdd);
        }

        [TestMethod()]
        public void TryingToDeleteUserConnectedWithEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfUsersBeforeAdd = dataRepository.DataContext.Users.Count;

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Event item = new CheckoutEvent(user, state, new DateTime(2008, 5, 13, 8, 30, 23));
            dataRepository.AddEvent(item);

            Assert.AreEqual(numberOfUsersBeforeAdd + 1, dataRepository.DataContext.Users.Count);

            Assert.ThrowsException<Exception>(() => dataRepository.DeleteUser(user));

            Assert.AreEqual(dataRepository.DataContext.Users.Count, numberOfUsersBeforeAdd + 1);
        }

        [TestMethod()]
        public void AddAndGetCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            Assert.AreEqual(dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count - 1), catalog);
        }

        [TestMethod()]
        public void GetCatalogIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Assert.ThrowsException<Exception>(() => dataRepository.GetCatalog(dataRepository.DataContext.Catalogs.Count));
            Assert.ThrowsException<Exception>(() => dataRepository.GetCatalog(-1));
        }

        [TestMethod()]
        public void GetAllCatalogsTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

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
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            int catalogIndex = dataRepository.DataContext.Catalogs.Count - 1;

            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Author, "Autor");
            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Title, "Tytul");

            dataRepository.UpdateCatalog(catalogIndex, "Autorzy", "Tytuly");

            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Author, "Autorzy");
            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Title, "Tytuly");
        }

        [TestMethod()]
        public void UpdateCatalogIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            int catalogIndex = dataRepository.DataContext.Catalogs.Count - 1;

            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Author, "Autor");
            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Title, "Tytul");

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateUser(catalogIndex + 1, "Marcin", "Nowak"));
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateUser(-1, "Marcin", "Nowak"));

            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Author, "Autor");
            Assert.AreEqual(dataRepository.GetCatalog(catalogIndex).Title, "Tytul");
        }

        [TestMethod()]
        public void DeleteCatalogTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfCatalogsBeforeAdd = dataRepository.DataContext.Catalogs.Count;

            Catalog catalog = new Catalog("Autor1", "Tytul1");
            dataRepository.AddCatalog(catalog);

            Assert.AreEqual(numberOfCatalogsBeforeAdd + 1, dataRepository.DataContext.Catalogs.Count);

            dataRepository.DeleteCatalog(catalog);

            Assert.AreEqual(dataRepository.DataContext.Catalogs.Count, numberOfCatalogsBeforeAdd);
        }

        [TestMethod()]
        public void TryingToDeleteCatalogConnectedWithStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfCatalogsBeforeAdd = dataRepository.DataContext.Catalogs.Count;

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Assert.AreEqual(numberOfCatalogsBeforeAdd + 1, dataRepository.DataContext.Catalogs.Count);

            Assert.ThrowsException<Exception>(() => dataRepository.DeleteCatalog(catalog));

            Assert.AreEqual(dataRepository.DataContext.Catalogs.Count, numberOfCatalogsBeforeAdd + 1);
        }

        [TestMethod()]
        public void AddAndGetStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            Assert.AreEqual(dataRepository.GetState(dataRepository.DataContext.States.Count - 1), state);
        }

        [TestMethod()]
        public void GetStateIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Assert.ThrowsException<Exception>(() => dataRepository.GetState(dataRepository.DataContext.States.Count));
            Assert.ThrowsException<Exception>(() => dataRepository.GetState(-1));
        }

        [TestMethod()]
        public void GetAllStatesTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

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
        public void UpdateStateTestCase1()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            int indexOfState = dataRepository.DataContext.States.Count - 1;

            Assert.AreEqual(dataRepository.GetState(indexOfState).Description, "opis");
            Assert.AreEqual(dataRepository.GetState(indexOfState).DateOfPurchase, new DateTime(2008, 5, 11, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(indexOfState).IsAvailable, true);


            dataRepository.UpdateState(indexOfState, "oPIS", new DateTime(2008, 5, 13, 8, 30, 23), false);

            Assert.AreEqual(dataRepository.GetState(indexOfState).Description, "oPIS");
            Assert.AreEqual(dataRepository.GetState(indexOfState).DateOfPurchase, new DateTime(2008, 5, 13, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(indexOfState).IsAvailable, false);
        }

        [TestMethod()]
        public void UpdateStateTestCase2_Overload()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            int indexOfState = dataRepository.DataContext.States.Count - 1;

            Assert.AreEqual(dataRepository.GetState(indexOfState).Description, "opis");
            Assert.AreEqual(dataRepository.GetState(indexOfState).DateOfPurchase, new DateTime(2008, 5, 11, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(indexOfState).IsAvailable, true);


            dataRepository.UpdateState(indexOfState, false);

            Assert.AreEqual(dataRepository.GetState(indexOfState).Description, "opis");
            Assert.AreEqual(dataRepository.GetState(indexOfState).DateOfPurchase, new DateTime(2008, 5, 11, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(indexOfState).IsAvailable, false);
        }

        [TestMethod()]
        public void UpdateStateIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            int stateIndex = dataRepository.DataContext.States.Count - 1;

            Assert.AreEqual(dataRepository.GetState(stateIndex).Description, "opis");
            Assert.AreEqual(dataRepository.GetState(stateIndex).DateOfPurchase, new DateTime(2008, 5, 11, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(stateIndex).IsAvailable, true);

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateState(stateIndex + 1, "Zmieniony opis", new DateTime(2009, 5, 11, 8, 30, 23), false));
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateState(-1, "Zmieniony opis", new DateTime(2009, 5, 11, 8, 30, 23), false));

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateState(stateIndex + 1, false));
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateState(-1, false));

            Assert.AreEqual(dataRepository.GetState(stateIndex).Description, "opis");
            Assert.AreEqual(dataRepository.GetState(stateIndex).DateOfPurchase, new DateTime(2008, 5, 11, 8, 30, 23));
            Assert.AreEqual(dataRepository.GetState(stateIndex).IsAvailable, true);
        }

        [TestMethod()]
        public void DeleteStateTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfStatesBeforeAdd = dataRepository.DataContext.States.Count;

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), true);
            dataRepository.AddState(state);

            Assert.AreEqual(numberOfStatesBeforeAdd + 1, dataRepository.DataContext.States.Count);

            dataRepository.DeleteState(state);

            Assert.AreEqual(dataRepository.DataContext.States.Count, numberOfStatesBeforeAdd);
        }

        [TestMethod()]
        public void TryingToDeleteStateConnectedWithEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfStatesBeforeAdd = dataRepository.DataContext.States.Count;

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Event item = new CheckoutEvent(user, state, new DateTime(2008, 5, 13, 8, 30, 23));
            dataRepository.AddEvent(item);

            Assert.AreEqual(numberOfStatesBeforeAdd + 1, dataRepository.DataContext.States.Count);

            Assert.ThrowsException<Exception>(() => dataRepository.DeleteState(state));

            Assert.AreEqual(dataRepository.DataContext.States.Count, numberOfStatesBeforeAdd + 1);
        }

        [TestMethod()]
        public void AddAndGetEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Event item = new CheckoutEvent(user, state, new DateTime(2008, 5, 13, 8, 30, 23));
            dataRepository.AddEvent(item);

            Assert.AreEqual(dataRepository.GetEvent(dataRepository.DataContext.Events.Count - 1), item);
        }

        [TestMethod()]
        public void GetEventIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            Assert.ThrowsException<Exception>(() => dataRepository.GetEvent(dataRepository.DataContext.Events.Count));
            Assert.ThrowsException<Exception>(() => dataRepository.GetEvent(-1));
        }

        [TestMethod()]
        public void GetAllEventsTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

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
        }

        [TestMethod()]
        public void UpdateEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Event item = new CheckoutEvent(user, state, new DateTime(2008, 5, 13, 8, 30, 23));
            dataRepository.AddEvent(item);

            int indexOfEvent = dataRepository.DataContext.Events.Count - 1;

            Assert.AreEqual(dataRepository.GetEvent(indexOfEvent).Date, new DateTime(2008, 5, 13, 8, 30, 23));

            dataRepository.UpdateEvent(indexOfEvent, new DateTime(2008, 5, 15, 8, 30, 23));

            Assert.AreEqual(dataRepository.GetEvent(indexOfEvent).Date, new DateTime(2008, 5, 15, 8, 30, 23));
        }

        [TestMethod()]
        public void UpdateEventIncorrectIndexTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Event item = new CheckoutEvent(user, state, new DateTime(2008, 5, 13, 8, 30, 23));
            dataRepository.AddEvent(item);

            int eventIndex = dataRepository.DataContext.Events.Count - 1;

            Assert.AreEqual(dataRepository.GetEvent(eventIndex).Date, new DateTime(2008, 5, 13, 8, 30, 23));

            Assert.ThrowsException<Exception>(() => dataRepository.UpdateEvent(eventIndex + 1, new DateTime(2009, 5, 13, 8, 30, 23)));
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateEvent(-1, new DateTime(2009, 5, 13, 8, 30, 23)));

            Assert.AreEqual(dataRepository.GetEvent(eventIndex).Date, new DateTime(2008, 5, 13, 8, 30, 23));
        }

        [TestMethod()]
        public void DeleteEventTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new ConstantFiller());

            int numberOfEventsBeforeAdd = dataRepository.DataContext.Events.Count;

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataRepository.AddCatalog(catalog);

            State state = new State(catalog, "opis", new DateTime(2008, 5, 11, 8, 30, 23), false);
            dataRepository.AddState(state);

            Event item = new CheckoutEvent(user, state, new DateTime(2008, 5, 13, 8, 30, 23));
            dataRepository.AddEvent(item);

            Assert.AreEqual(numberOfEventsBeforeAdd + 1, dataRepository.DataContext.Events.Count);

            dataRepository.DeleteEvent(item);

            Assert.AreEqual(numberOfEventsBeforeAdd, dataRepository.DataContext.Events.Count);
        }
    }
}