using System;
using System.Linq;
using Exercise_1.Data;
using Exercise_1.Tests.ImplementationsForTests;
using Exercise_1.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests.Logic
{
    [TestClass()]
    public class DataServiceTests
    {
        [TestMethod()]
        public void CatalogCheckoutTest_Correct()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(2, numberOfEventsForUser);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));
            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(3, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogCheckoutTest_IncorrectCase1()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();

            Assert.AreEqual(2, numberOfEventsForUser);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));

            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();

            Assert.AreEqual(3, numberOfEventsForUser);
            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogCheckout(dataService.GetUser(2), dataService.GetState(1)));
            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(3, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogCheckoutTest_IncorrectCase2()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(2, numberOfEventsForUser);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));

            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(3, numberOfEventsForUser);

            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1)));

            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(3, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogReturnTest_Correct()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));
            int numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(3, numberOfEventsForUser);

            dataService.CatalogReturn(dataService.GetUser(1), dataService.GetState(1));
            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(4, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogReturnTest_IncorrectCase1()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));
            int numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(3, numberOfEventsForUser);

            dataService.CatalogReturn(dataService.GetUser(1), dataService.GetState(1));
            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(4, numberOfEventsForUser);

            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogReturn(dataService.GetUser(1), dataService.GetState(1)));

            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(4, numberOfEventsForUser);
        }

        [TestMethod()]
        public void CatalogReturnTest_IncorrectCase2()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            int numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(2, numberOfEventsForUser);

            Assert.ThrowsException<ArgumentException>(() => dataService.CatalogReturn(dataService.GetUser(1), dataService.GetState(1)));

            numberOfEventsForUser = dataService.GetAllEventsForUser(dataService.GetUser(1)).Count();
            Assert.AreEqual(2, numberOfEventsForUser);
        }

        [TestMethod()]
        public void GetAllEventsBetweenDatesTest()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            DateTime beginPeriod = DateTime.Now;
            DateTime endPeriod = DateTime.Now.AddMinutes(5);

            Assert.AreEqual(0, dataService.GetAllEventsBetweenDates(beginPeriod, endPeriod).Count());

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));

            Assert.AreEqual(1, dataService.GetAllEventsBetweenDates(beginPeriod, endPeriod).Count());
        }

        [TestMethod()]
        public void GetAllEventsForUserTest()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));

            Assert.AreEqual(3, dataService.GetAllEventsForUser(dataService.GetUser(1)).Count());
        }

        [TestMethod()]
        public void GetAllEventsForCatalogTest()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            Assert.AreEqual(2, dataService.GetAllEventsForCatalog(dataService.GetCatalog(1)).Count());
        }

        [TestMethod()]
        public void GetAllStatesForCatalogTest()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            Assert.AreEqual(1, dataService.GetAllStatesForCatalog(dataService.GetCatalog(1)).Count());
        }

        [TestMethod()]
        public void GetIndexOfTheStateTest()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            int indexOfState = dataService.GetAllStates().Count() - 1;

            Assert.AreEqual(indexOfState, dataService.GetIndexOfTheState(dataService.GetState(indexOfState)));
        }

        [TestMethod()]
        public void GetUserConnectedWithStateTest()
        {
            IFiller filler = new Filler();
            IDataContext dataContext = new TestDataContext();
            IRepository dataRepository = new TestRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            dataService.CatalogCheckout(dataService.GetUser(1), dataService.GetState(1));

            Assert.AreEqual(dataService.GetUser(1), dataService.GetUserConnectedWithState(dataService.GetState(1)));
        }
    }
}