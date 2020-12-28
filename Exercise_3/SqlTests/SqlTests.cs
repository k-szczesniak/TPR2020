using Exercise_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SqlTests
{
    [TestClass]
    public class SqlTests
    {
        [TestMethod]
        public void TestGetProductsByName()
        {
            List<Product> listOfProducts = SqlToolClass.GetProductsByName("Decal");

            Assert.AreEqual(listOfProducts.Count, 2);

            Assert.AreEqual(listOfProducts[0].ProductID, 325);
            Assert.AreEqual(listOfProducts[0].Name, "Decal 1");

            Assert.AreEqual(listOfProducts[1].ProductID, 326);
            Assert.AreEqual(listOfProducts[1].Name, "Decal 2");
        }

        [TestMethod]
        public void TestGetProductsByVendorName()
        {
            List<Product> listOfProducts = SqlToolClass.GetProductsByVendorName("Bike Satellite Inc.");

            Assert.AreEqual(listOfProducts.Count, 3);

            Assert.AreEqual(listOfProducts[0].ProductID, 320);
            Assert.AreEqual(listOfProducts[0].Name, "Chainring Bolts");

            Assert.AreEqual(listOfProducts[1].ProductID, 321);
            Assert.AreEqual(listOfProducts[1].Name, "Chainring Nut");

            Assert.AreEqual(listOfProducts[2].ProductID, 322);
            Assert.AreEqual(listOfProducts[2].Name, "Chainring");
        }

        [TestMethod]
        public void TestGetProductNamesByVendorName()
        {
            List<string> listOfProducts = SqlToolClass.GetProductNamesByVendorName("Beaumont Bikes");

            Assert.AreEqual(listOfProducts.Count, 3);

            Assert.AreEqual(listOfProducts[0], "Chainring Bolts");

            Assert.AreEqual(listOfProducts[1], "Chainring Nut");

            Assert.AreEqual(listOfProducts[2], "Chainring");
        }
    }
}
