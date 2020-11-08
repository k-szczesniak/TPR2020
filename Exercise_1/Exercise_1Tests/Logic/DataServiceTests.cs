using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class DataServiceTests
    {
        [TestMethod()]
        public void CatalogCheckoutTest_Correct()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(0, numberOfEventsForUser);

            dataService.AddUser(user1);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            dataService.CatalogCheckout(user1, state1);
            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(1, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogCheckoutTest_IncorrectCase1()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            User user2 = new User("Janusz", "Nowak");

            int numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();

            Assert.AreEqual(0, numberOfEventsForUser);

            dataService.AddUser(user1);
            dataService.AddUser(user2);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            dataService.CatalogCheckout(user1, state1);

            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();

            Assert.AreEqual(1, numberOfEventsForUser);
            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogCheckout(user2, state1));
            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(1, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogCheckoutTest_IncorrectCase2()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            dataService.AddUser(user1);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(0, numberOfEventsForUser);

            dataService.CatalogCheckout(user1, state1);

            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(1, numberOfEventsForUser);

            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogCheckout(user1, state1));

            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(1, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogReturnTest_Correct()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            dataService.AddUser(user1);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            dataService.CatalogCheckout(user1, state1);
            int numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(1, numberOfEventsForUser);

            dataService.CatalogReturn(user1, state1);
            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(2, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogReturnTest_IncorrectCase1()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            dataService.AddUser(user1);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            dataService.CatalogCheckout(user1, state1);
            int numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(1, numberOfEventsForUser);

            dataService.CatalogReturn(user1, state1);
            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(2, numberOfEventsForUser);

            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogReturn(user1, state1));
           
            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(2, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogReturnTest_IncorrectCase2()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            dataService.AddUser(user1);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(0, numberOfEventsForUser);

            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogReturn(user1, state1));

            numberOfEventsForUser = dataService.GetAllEventsForUser(user1).Count();
            Assert.AreEqual(0, numberOfEventsForUser);
        }

        [TestMethod()]
        public void GetAllEventsBetweenDatesTest()
        {
            Filler filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            DateTime beginPeriod = DateTime.Now;
            DateTime endPeriod = DateTime.Now.AddMinutes(5);

            Assert.AreEqual(0, dataService.GetAllEventsBetweenDates(beginPeriod, endPeriod).Count());

            User user1 = new User("Jan", "Kowalski");
            dataService.AddUser(user1);
            Catalog book = new Catalog("Autor1", "Tytul1");
            dataService.AddCatalog(book);
            State state = new State(book, "some description", new DateTime(2019, 11, 11), true);
            dataService.AddState(state);

            dataService.CatalogCheckout(user1, state);

            Assert.AreEqual(1, dataService.GetAllEventsBetweenDates(beginPeriod, endPeriod).Count());
        }

        [TestMethod()]
        public void GetAllEventsForUserTest()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user1 = new User("Jan", "Kowalski");
            Catalog catalog1 = new Catalog("Julian Tuwim", "Lokomotywa");
            State state1 = new State(catalog1, "some description1", new DateTime(2019, 11, 11), true);

            dataService.AddUser(user1);
            dataService.AddCatalog(catalog1);
            dataService.AddState(state1);

            dataService.CatalogCheckout(user1, state1);

            Assert.AreEqual(1, dataService.GetAllEventsForUser(user1).Count());
        }

        [TestMethod()]
        public void GetAllEventsForCatalogTest()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            Assert.AreEqual(2, dataService.GetAllEventsForCatalog(dataService.GetCatalog(1)).Count());
        }

        [TestMethod()]
        public void GetAllStatesForCatalogTest()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            Assert.AreEqual(1, dataService.GetAllStatesForCatalog(dataService.GetCatalog(1)).Count());
        }

        [TestMethod()]
        public void GetIndexOfTheStateTest()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            int indexOfState = dataService.GetAllStates().Count();

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataService.AddCatalog(catalog);

            State state = new State(catalog, "description", new DateTime(2008, 3, 15), true);
            dataService.AddState(state);

            Assert.AreEqual(indexOfState, dataService.GetIndexOfTheState(state));
        }

        [TestMethod()]
        public void GetUserConnectedWithStateTest()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user = new User("Szymon", "Tomkowski");
            dataService.AddUser(user);

            Catalog catalog = new Catalog("Autor", "Tytul");
            dataService.AddCatalog(catalog);

            State state = new State(catalog, "description", new DateTime(2008, 3, 15), true);
            dataService.AddState(state);

            dataService.CatalogCheckout(user, state);

            Assert.AreEqual(user, dataService.GetUserConnectedWithState(state));
        }
    }
}