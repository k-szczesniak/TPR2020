using Exercise_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SqlTests
{
    [TestClass]
    public class ExtendedSqlToolClassTests
    {

        [TestMethod]
        public void GetProductsWithoutCategoryListDeclarativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = productionDataContext.GetTable<Product>().ToList();
                List<Product> resultList = productsList.GetProductsWithoutCategoryListDeclarative();

                foreach (var singleResult in resultList)
                {
                    Assert.AreEqual(singleResult.ProductSubcategory, null);
                }

                Assert.AreEqual(resultList.Count, 209);
            }
        }

        [TestMethod]
        public void GetProductsWithoutCategoryListImperativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = productionDataContext.GetTable<Product>().ToList();
                List<Product> resultList = productsList.GetProductsWithoutCategoryListImperative();

                foreach (var singleResult in resultList)
                {
                    Assert.AreEqual(singleResult.ProductSubcategory, null);
                }

                Assert.AreEqual(resultList.Count, 209);
            }
        }

        [TestMethod]
        public void GetProductsPageDeclarativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = productionDataContext.GetTable<Product>().ToList();
                List<Product> resultList = productsList.GetProductsPageDeclarative(5, 10);

                Assert.AreEqual(resultList.Count, 5);

                Assert.AreEqual(productsList[45].ProductID, resultList[0].ProductID);
                Assert.AreEqual(productsList[45].Name, resultList[0].Name);

                Assert.AreEqual(productsList[46].ProductID, resultList[1].ProductID);
                Assert.AreEqual(productsList[46].Name, resultList[1].Name);

                Assert.AreEqual(productsList[47].ProductID, resultList[2].ProductID);
                Assert.AreEqual(productsList[47].Name, resultList[2].Name);

                Assert.AreEqual(productsList[48].ProductID, resultList[3].ProductID);
                Assert.AreEqual(productsList[48].Name, resultList[3].Name);

                Assert.AreEqual(productsList[49].ProductID, resultList[4].ProductID);
                Assert.AreEqual(productsList[49].Name, resultList[4].Name);
            }
        }

        [TestMethod]
        public void GetProductsPageImperativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = productionDataContext.GetTable<Product>().ToList();
                List<Product> resultList = productsList.GetProductsPageImperative(5, 6);

                Assert.AreEqual(resultList.Count, 5);

                Assert.AreEqual(productsList[25].ProductID, resultList[0].ProductID);
                Assert.AreEqual(productsList[25].Name, resultList[0].Name);

                Assert.AreEqual(productsList[26].ProductID, resultList[1].ProductID);
                Assert.AreEqual(productsList[26].Name, resultList[1].Name);

                Assert.AreEqual(productsList[27].ProductID, resultList[2].ProductID);
                Assert.AreEqual(productsList[27].Name, resultList[2].Name);

                Assert.AreEqual(productsList[28].ProductID, resultList[3].ProductID);
                Assert.AreEqual(productsList[28].Name, resultList[3].Name);

                Assert.AreEqual(productsList[29].ProductID, resultList[4].ProductID);
                Assert.AreEqual(productsList[29].Name, resultList[4].Name);
            }
        }

        [TestMethod]
        public void GetProductVendorPairsDeclarativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = productionDataContext.GetTable<Product>().ToList();
                List<ProductVendor> vendorsList = productionDataContext.GetTable<ProductVendor>().ToList();

                string result = productsList.GetProductVendorPairsDeclarative(vendorsList);
                string[] lines = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(lines.Length, 460);
                Assert.IsTrue(lines.Contains("Headset Ball Bearings - American Bicycles and Wheels"));
                Assert.IsTrue(lines.Contains("Decal 2 - SUPERSALES INC."));
                Assert.IsTrue(lines.Contains("ML Grip Tape - National Bike Association"));
                Assert.IsTrue(lines.Contains("Thin-Jam Hex Nut 11 - WestAmerica Bicycle Co."));
                Assert.IsTrue(lines.Contains("Hex Nut 9 - Norstan Bike Hut"));
                Assert.IsTrue(lines.Contains("Internal Lock Washer 4 - Aurora Bike Center"));
                Assert.IsTrue(lines.Contains("Lock Nut 6 - Bergeron Off-Roads"));
                Assert.IsTrue(lines.Contains("HL Spindle/Axle - Hill Bicycle Center"));
            }
        }

        [TestMethod]
        public void GetProductVendorPairsImperativeTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = productionDataContext.GetTable<Product>().ToList();
                List<ProductVendor> vendorsList = productionDataContext.GetTable<ProductVendor>().ToList();

                string result = productsList.GetProductVendorPairsImperative(vendorsList);
                string[] lines = result.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                Assert.AreEqual(lines.Length, 460);
                Assert.IsTrue(lines.Contains("Hex Nut 19 - Norstan Bike Hut"));
                Assert.IsTrue(lines.Contains("External Lock Washer 1 - Pro Sport Industries"));
                Assert.IsTrue(lines.Contains("HL Nipple - Lindell"));
                Assert.IsTrue(lines.Contains("ML Road Pedal - Mitchell Sports"));
                Assert.IsTrue(lines.Contains("Lock Washer 2 - Inner City Bikes"));
                Assert.IsTrue(lines.Contains("Flat Washer 9 - Continental Pro Cycles"));
                Assert.IsTrue(lines.Contains("ML Crankarm - Proseware, Inc."));
                Assert.IsTrue(lines.Contains("Thin-Jam Hex Nut 7 - WestAmerica Bicycle Co."));
            }
        }
    }
}
