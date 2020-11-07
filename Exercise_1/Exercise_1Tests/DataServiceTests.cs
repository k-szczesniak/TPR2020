using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise_1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class DataServiceTests
    {
        [TestMethod()]
        public void GetAllEventsBetweenDatesTest()
        {
            Filler filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            DateTime beginPeriod = DateTime.Now;
            DateTime endPeriod = DateTime.Now;

            Assert.AreEqual(0, dataService.GetAllEventsBetweenDates(beginPeriod, endPeriod).Count());

            Catalog book = new Catalog("Autor1", "Tytul1");
            dataService.AddCatalog(book);
            State state = new State(book, "some description", 1, new DateTime(2019, 11, 11));
            Event checkout = new Event(dataService.GetUser(0), state, DateTime.Now, DateTime.MinValue);

            dataService.AddEvent(checkout);
            Assert.AreEqual(1, dataService.GetAllEventsBetweenDates(beginPeriod.AddDays(-1), endPeriod.AddDays(1)).Count());
        }

        [TestMethod()]
        public void GetAllEventsForUserTest()
        {
            Filler filler = new Filler();
            DataContext dataContext = new DataContext();
            DataRepository dataRepository = new DataRepository(dataContext, filler);
            DataService dataService = new DataService(dataRepository);

            User user = new User("Imie", "Nazwisko");
            dataService.AddUser(user);
            Catalog book = new Catalog("Autor", "Tytul");
            dataService.AddCatalog(book);
            State state = new State(book, "some description", 1, new DateTime(2019, 11, 11));

            Assert.AreEqual(0, dataService.GetAllEventsForUser(user).Count());
            
            Event checkout = new Event(user, state, DateTime.Now, DateTime.MinValue);
            dataService.AddEvent(checkout);
            
            Assert.AreEqual(1, dataService.GetAllEventsForUser(user).Count());

            Event returnBook = new Event(user, state, DateTime.Now.AddDays(-1), DateTime.Now);
            dataService.AddEvent(returnBook);

            Assert.AreEqual(2, dataService.GetAllEventsForUser(user).Count());
        }
    }
}