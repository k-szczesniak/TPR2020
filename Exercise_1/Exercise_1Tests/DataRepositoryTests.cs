using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_1.Tests
{
    [TestClass()]
    public class DataRepositoryTests
    {

        [TestMethod()]
        public void AddAndGetUserTest()
        {
            DataRepository dataRepository = new DataRepository(new DataContext(), new Filler());

            User user = new User("Tomek", "Kowalski");
            dataRepository.AddUser(user);
            Assert.AreEqual(dataRepository.GetUser(0), user);
        }

        [TestMethod()]
        public void GetAllUsersTest() //TODO: Nie jestem tego pewny
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

            for (int i = 0; i < 3; i++)
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
        public void AddCatalogTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetCatalogTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllCatalogsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateCatalogTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCatalogTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllStatesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteStateTest()
        {
            Assert.Fail();
        }
    }
}