using Exercise_1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise_1.Tests.Data
{
    [TestClass()]
    public class CatalogTests
    {
        [TestMethod]
        public void CatalogConstructorTest()
        {
            Catalog catalog = new Catalog("Autor", "Tytul");

            Assert.AreEqual("Autor", catalog.Author);
            Assert.AreEqual("Tytul", catalog.Title);
        }

        [TestMethod]
        public void CatalogSetTest()
        {
            Catalog catalog = new Catalog("Autor", "Tytul");

            catalog.Author = "Autorzy";
            catalog.Title = "Tytuly";

            Assert.AreEqual("Autorzy", catalog.Author);
            Assert.AreEqual("Tytuly", catalog.Title);
        }
    }
}