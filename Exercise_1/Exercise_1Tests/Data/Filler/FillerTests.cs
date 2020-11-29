using Exercise_1.Data;
using Exercise_1.Tests.ImplementationsForTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests.Data
{
    [TestClass()]
    public class FillerTests
    {
        [TestMethod()]
        public void ConstantFillerTest()
        {
            IFiller filler = new ConstantFiller();
            IDataContext dataContext = new TestDataContext();

            filler.Fill(dataContext);

            Assert.AreEqual(dataContext.Users.Count, 5);
            Assert.AreEqual(dataContext.Catalogs.Count, 5);
            Assert.AreEqual(dataContext.States.Count, 5);
            Assert.AreEqual(dataContext.Events.Count, 10);
        }

        [TestMethod()]
        public void RandomFillerTest()
        {
            IFiller filler = new RandomFiller();
            IDataContext dataContext = new TestDataContext();

            filler.Fill(dataContext);

            Assert.AreEqual(dataContext.Users.Count, 5);
            Assert.AreEqual(dataContext.Catalogs.Count, 5);
            Assert.AreEqual(dataContext.States.Count, 5);
            Assert.AreEqual(dataContext.Events.Count, 10);
        }
    }

}