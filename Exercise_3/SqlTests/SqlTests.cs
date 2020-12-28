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
        public void GetProductsByNameTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetProductsByName("Decal");

            Assert.AreEqual(listOfProducts.Count, 2);

            Assert.AreEqual(listOfProducts[0].ProductID, 325);
            Assert.AreEqual(listOfProducts[0].Name, "Decal 1");

            Assert.AreEqual(listOfProducts[1].ProductID, 326);
            Assert.AreEqual(listOfProducts[1].Name, "Decal 2");
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
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
        public void GetProductNamesByVendorNameTest()
        {
            List<string> listOfProducts = SqlToolClass.GetProductNamesByVendorName("Beaumont Bikes");

            Assert.AreEqual(listOfProducts.Count, 3);

            Assert.AreEqual(listOfProducts[0], "Chainring Bolts");

            Assert.AreEqual(listOfProducts[1], "Chainring Nut");

            Assert.AreEqual(listOfProducts[2], "Chainring");
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendor = SqlToolClass.GetProductVendorByProductName("Adjustable Race");

            Assert.AreEqual(vendor, "Litware, Inc.");
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetProductsWithNRecentReviews(1);

            Assert.AreEqual(listOfProducts.Count, 2);

            Assert.AreEqual(listOfProducts[0].ProductID, 709);
            Assert.AreEqual(listOfProducts[0].Name, "Mountain Bike Socks, M");

            Assert.AreEqual(listOfProducts[1].ProductID, 798);
            Assert.AreEqual(listOfProducts[1].Name, "Road-550-W Yellow, 40");
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetNRecentlyReviewedProducts(3);

            Assert.AreEqual(listOfProducts.Count, 3);

            Assert.AreEqual(listOfProducts[0].ProductID, 937);
            Assert.AreEqual(listOfProducts[0].Name, "HL Mountain Pedal");

            Assert.AreEqual(listOfProducts[1].ProductID, 798);
            Assert.AreEqual(listOfProducts[1].Name, "Road-550-W Yellow, 40");

            Assert.AreEqual(listOfProducts[2].ProductID, 709);
            Assert.AreEqual(listOfProducts[2].Name, "Mountain Bike Socks, M");
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetNProductsFromCategory("Clothing", 3);

            Assert.AreEqual(listOfProducts.Count, 3);

            Assert.AreEqual(listOfProducts[0].ProductID, 712);
            Assert.AreEqual(listOfProducts[0].Name, "AWC Logo Cap");

            Assert.AreEqual(listOfProducts[1].ProductID, 866);
            Assert.AreEqual(listOfProducts[1].Name, "Classic Vest, L");

            Assert.AreEqual(listOfProducts[2].ProductID, 865);
            Assert.AreEqual(listOfProducts[2].Name, "Classic Vest, M");
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            ProductCategory productCategory = new ProductCategory();
            productCategory.Name = "Clothing";

            int totalStandardCost = SqlToolClass.GetTotalStandardCostByCategory(productCategory);

            Assert.AreEqual(totalStandardCost, 868);
        }
    }
}
