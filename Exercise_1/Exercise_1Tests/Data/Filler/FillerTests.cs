using Exercise_1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests
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