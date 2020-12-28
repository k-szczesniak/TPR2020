using Exercise_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
                ProductCategory productCategory = new ProductCategory();
                productCategory.Name = "Clothing";

                MyProductDataContext myProductDataContext = new MyProductDataContext(productionDataContext);
                int totalStandardCost = MyProductSqlToolClass.GetTotalStandardCostByCategory(productCategory);

                Assert.AreEqual(totalStandardCost, 868);
            }
        }
    }
}
