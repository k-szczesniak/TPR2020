using Exercise_1.Data;
using Exercise_1.TestFiller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests.Data
{
    [TestClass()]
    public class FillerTests
    {
        [TestMethod()]
        public void FillTest()
        {
            IFiller filler = new Filler();
            DataContext dataContext = new DataContext();

            filler.Fill(dataContext);

            Assert.AreEqual(dataContext.Users.Count, 5);
            Assert.AreEqual(dataContext.Catalogs.Count, 5);
            Assert.AreEqual(dataContext.States.Count, 5);
            Assert.AreEqual(dataContext.Events.Count, 10);
        }
    }
}