using Exercise_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SqlTests
{
    [TestClass]
    public class ProductTests
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

        [TestMethod]
        public void AddProductTest()
        {
            Product product = createProduct();          
            Assert.IsTrue(SqlToolClass.AddProduct(product));
        }      

        [TestMethod]
        public void RemoveProductTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetProductsByName("testowy");
            Assert.IsTrue(SqlToolClass.RemoveProduct(listOfProducts[0]));
        }

        [TestMethod]
        public void GetProductTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetProductsByName("Blade");
            Product resultProduct = SqlToolClass.GetProduct(316);
            Assert.AreEqual(listOfProducts[0].ProductID, resultProduct.ProductID);
            Assert.AreEqual(listOfProducts[0].Name, resultProduct.Name);
            Assert.AreEqual(listOfProducts[0].ProductLine, resultProduct.ProductLine);
            Assert.AreEqual(listOfProducts[0].ProductNumber, resultProduct.ProductNumber);
        }

        [TestMethod]
        public void GetAllProductsTest()
        {
            List<Product> listOfProducts = SqlToolClass.GetAllProducts();            
            Assert.AreEqual(listOfProducts.Count, 504);            
        }

        [TestMethod]
        public void UpdateProductTest()
        {
            Product product = createProduct();
            Assert.IsTrue(SqlToolClass.UpdateProduct(product, 527));

            Product productAfterUpdate = SqlToolClass.GetProduct(527);

            Assert.AreEqual(productAfterUpdate.Name, product.Name);
            Assert.AreEqual(productAfterUpdate.ProductNumber, product.ProductNumber);
            Assert.AreEqual(productAfterUpdate.Color, product.Color);
        }

        private Product createProduct()
        {
            Product newProduct = new Product();
            newProduct.Name = "testowy";
            newProduct.ProductNumber = "BB-7421666";
            newProduct.MakeFlag = true;
            newProduct.FinishedGoodsFlag = true;
            newProduct.Color = "Black";
            newProduct.SafetyStockLevel = 100;
            newProduct.ReorderPoint = 75;
            newProduct.StandardCost = 1898.0944m;
            newProduct.ListPrice = 3374.99m;
            newProduct.Size = "48";
            newProduct.SizeUnitMeasureCode = "CM";
            newProduct.WeightUnitMeasureCode = "LB";
            newProduct.Weight = 21.13m;
            newProduct.DaysToManufacture = 4;
            newProduct.ProductLine = "M";
            newProduct.Class = "L";
            newProduct.Style = "U";
            newProduct.ProductSubcategoryID = 2;
            newProduct.ProductModelID = 30;
            newProduct.SellStartDate = DateTime.Today.AddHours(-5);
            newProduct.SellEndDate = DateTime.Today.AddHours(-3);
            newProduct.DiscontinuedDate = null;
            newProduct.rowguid = System.Guid.NewGuid();
            newProduct.ModifiedDate = DateTime.Today;
            return newProduct;
        }

    }
}   
