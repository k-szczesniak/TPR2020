using Exercise_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;

namespace SqlTests
{
    [TestClass]
    public class MyProductTests
    {
        [TestMethod]
        public void GetMyProductsByNameTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                MyProductDataContext myProductDataContext = new MyProductDataContext(productionDataContext);
                List<MyProduct> listOfProducts = MyProductSqlToolClass.GetMyProductsByName("Decal");

                Assert.AreEqual(listOfProducts.Count, 2);

                Assert.AreEqual(listOfProducts[0].ProductID, 325);
                Assert.AreEqual(listOfProducts[0].Name, "Decal 1");

                Assert.AreEqual(listOfProducts[1].ProductID, 326);
                Assert.AreEqual(listOfProducts[1].Name, "Decal 2");
            }
        }

        [TestMethod]
        public void GetMyProductsWithNRecentReviewsTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                MyProductDataContext myProductDataContext = new MyProductDataContext(productionDataContext);
                List<MyProduct> listOfProducts = MyProductSqlToolClass.GetMyProductsWithNRecentReviews(2);

                Assert.AreEqual(listOfProducts.Count, 1);

                Assert.AreEqual(listOfProducts[0].ProductID, 937);
                Assert.AreEqual(listOfProducts[0].Name, "HL Mountain Pedal");
            }
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                
                MyProductDataContext myProductDataContext = new MyProductDataContext(productionDataContext);
                Thread.Sleep(200);
                List<MyProduct> listOfProducts = MyProductSqlToolClass.GetNMyProductsFromCategory("Clothing", 3);

                Assert.AreEqual(listOfProducts.Count, 3);

                //Assert.AreEqual(listOfProducts[0].ProductID, 712);
                //Assert.AreEqual(listOfProducts[0].Name, "AWC Logo Cap");

                //Assert.AreEqual(listOfProducts[1].ProductID, 866);
                //Assert.AreEqual(listOfProducts[1].Name, "Classic Vest, L");

                //Assert.AreEqual(listOfProducts[2].ProductID, 865);
                //Assert.AreEqual(listOfProducts[2].Name, "Classic Vest, M");
            }
        }
    }
}
