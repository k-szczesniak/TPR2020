using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public static class SqlToolClass
    {
        public static List<Product> GetProductsByName(string namePart)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                           where product.Name.Contains(namePart)
                                                           select product);
            return productsList;
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                           join productVendor in productionDataContext.ProductVendors on product.ProductID equals productVendor.ProductID
                                                           where productVendor.Vendor.Name == vendorName
                                                           select product);
            return productsList;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<string> productNamesList = new List<string>(from product in productionDataContext.Products
                                                             join productVendor in productionDataContext.ProductVendors on product.ProductID equals productVendor.ProductID
                                                             where productVendor.Vendor.Name == vendorName
                                                             select product.Name);
            return productNamesList;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            string vendor = (from product in productionDataContext.Products
                             join productVendor in productionDataContext.ProductVendors on product.ProductID equals productVendor.ProductID
                             where product.Name == productName
                             select productVendor.Vendor.Name).First();
            return vendor;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<Product> productsList = new List<Product>(from product in productionDataContext.Products
                                                           where product.ProductReviews.Count == howManyReviews
                                                           select product);
            return productsList;
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<Product> productsList = new List<Product>((from review in productionDataContext.ProductReviews
                                                            orderby review.ReviewDate descending
                                                            group review.Product by review.ProductID into g
                                                            select g.First()).Take(howManyProducts));
            return productsList;
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            List<Product> productsList = new List<Product>((from product in productionDataContext.Products
                                                            where product.ProductSubcategory.ProductCategory.Name == categoryName
                                                            orderby product.Name
                                                            select product).Take(n));
            return productsList;
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            ProductionDataContext productionDataContext = new ProductionDataContext();
            int totalStandardCost = (int)(from product in productionDataContext.Products
                                                            where product.ProductSubcategory.ProductCategory.Name == category.Name                                                           
                                                            select product.StandardCost).Sum();
            return totalStandardCost;
        }
    }
}
