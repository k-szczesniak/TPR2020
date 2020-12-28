using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public static class SqlToolClass
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                               where product.Name.Contains(namePart)
                                                               select product);
                return productsList;
            }
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                               join productVendor in productionDataContext.ProductVendors on product.ProductID equals productVendor.ProductID
                                                               where productVendor.Vendor.Name == vendorName
                                                               select product);
                return productsList;
            }
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<string> productNamesList = new List<string>(from product in productionDataContext.Products
                                                                 join productVendor in productionDataContext.ProductVendors on product.ProductID equals productVendor.ProductID
                                                                 where productVendor.Vendor.Name == vendorName
                                                                 select product.Name);
                return productNamesList;
            }
        }

        public static string GetProductVendorByProductName(string productName)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                string vendor = (from product in productionDataContext.Products
                                 join productVendor in productionDataContext.ProductVendors on product.ProductID equals productVendor.ProductID
                                 where product.Name == productName
                                 select productVendor.Vendor.Name).First();
                return vendor;
            }
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                               where product.ProductReviews.Count == howManyReviews
                                                               select product);
                return productsList;
            }
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = new List<Product>((from review in productionDataContext.ProductReviews
                                                                orderby review.ReviewDate descending
                                                                group review.Product by review.ProductID into g
                                                                select g.First()).Take(howManyProducts));
                return productsList;
            }
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = new List<Product>((from product in productionDataContext.Products
                                                                where product.ProductSubcategory.ProductCategory.Name == categoryName
                                                                orderby product.Name
                                                                select product).Take(n));
                return productsList;
            }
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                int totalStandardCost = (int)(from product in productionDataContext.Products
                                              where product.ProductSubcategory.ProductCategory.Name == category.Name
                                              select product.StandardCost).Sum();
                return totalStandardCost;
            }
        }

        public static bool AddProduct(Product product)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                try
                {
                    productionDataContext.Products.InsertOnSubmit(product);
                    productionDataContext.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static Product GetProduct(int productId)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                IQueryable<Product> result = (from product in productionDataContext.GetTable<Product>()
                                              where product.ProductID == productId
                                              select product);
                return result.First();
            }
        }


        public static bool RemoveProduct(Product product)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                try
                {
                    var existing = productionDataContext.Products.Single(result => product.ProductID == result.ProductID);
                    productionDataContext.Products.DeleteOnSubmit(existing);
                    productionDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool UpdateProduct(Product product, int productId)
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                try
                {
                    Product productToUpdate = productionDataContext.Products.Single(result => result.ProductID == productId);
                    productToUpdate.Name = product.Name;
                    productToUpdate.ProductNumber = product.ProductNumber;
                    productToUpdate.MakeFlag = product.MakeFlag;
                    productToUpdate.FinishedGoodsFlag = product.FinishedGoodsFlag;
                    productToUpdate.Color = product.Color;
                    productToUpdate.SafetyStockLevel = product.SafetyStockLevel;
                    productToUpdate.ReorderPoint = product.ReorderPoint;
                    productToUpdate.StandardCost = product.StandardCost;
                    productToUpdate.ListPrice = product.ListPrice;
                    productToUpdate.Size = product.Size;
                    productToUpdate.SizeUnitMeasureCode = product.SizeUnitMeasureCode;
                    productToUpdate.WeightUnitMeasureCode = product.WeightUnitMeasureCode;
                    productToUpdate.Weight = product.Weight;
                    productToUpdate.DaysToManufacture = product.DaysToManufacture;
                    productToUpdate.ProductLine = product.ProductLine;
                    productToUpdate.Class = product.Class;
                    productToUpdate.Style = product.Style;
                    productToUpdate.ProductSubcategoryID = product.ProductSubcategoryID;
                    productToUpdate.ProductModelID = product.ProductModelID;
                    productToUpdate.SellStartDate = product.SellStartDate;
                    productToUpdate.SellEndDate = product.SellEndDate;
                    productToUpdate.DiscontinuedDate = product.DiscontinuedDate;
                    productToUpdate.ModifiedDate = DateTime.Today;
                    productionDataContext.SubmitChanges(ConflictMode.ContinueOnConflict);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }

        public static List<Product> GetAllProducts()
        {
            using (ProductionDataContext productionDataContext = new ProductionDataContext())
            {
                List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                               orderby product.ProductID
                                                               select product);
                return productsList;
            }
        }
    }
}
