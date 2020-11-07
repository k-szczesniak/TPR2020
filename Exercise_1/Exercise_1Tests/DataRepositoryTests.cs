using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {
        //TODO: Zastanowić się czy badać negatywne przypadki?
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
        public void AddStateTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void GetStateTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void GetAllStatesTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void DeleteStateTest()
        {
            Assert.Inconclusive();
        }
    }
}