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

        //public static string GetProductVendorByProductName(string productName)
        //{

        //}

        //public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        //{

        //}

        //public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        //{

        //}

        //public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        //{

        //}

        //public static int GetTotalStandardCostByCategory(ProductCategory category)
        //{

        //}


    }
}
