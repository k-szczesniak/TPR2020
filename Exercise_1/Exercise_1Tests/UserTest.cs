using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserConstructorTest()
        {
            User user = new User("Jan", "Kowalski");

            Assert.AreEqual("Jan", user.FirstName);
            Assert.AreEqual("Kowalski", user.LastName);
        }

        [TestMethod]
        public void UserSetTest()
        {
            User user = new User("Jan", "Kowalski");

            user.FirstName = "Janusz";
            user.LastName = "Nowak";

            Assert.AreEqual("Janusz", user.FirstName);
            Assert.AreEqual("Nowak", user.LastName);
        }
    }
}
