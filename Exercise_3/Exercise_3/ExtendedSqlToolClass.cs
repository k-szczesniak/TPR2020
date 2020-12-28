using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public static class ExtendedSqlToolClass
    {
        public static List<Product> GetProductsWithoutCategoryListDeclarative(this List<Product> products)
        {
            List<Product> productsWithoutCategory = new List<Product>(from product in products
                                                                      where product.ProductSubcategory == null
                                                                      select product);
            return productsWithoutCategory;
        }

        public static List<Product> GetProductsWithoutCategoryListImperative(this List<Product> products)
        {
            List<Product> productsWithoutCategory = new List<Product>(products.Where(p => p.ProductSubcategory == null));
            return productsWithoutCategory;
        }

        public static List<Product> GetProductsPageDeclarative(this List<Product> products, int numberOfProductsOnPage, int numberOfPage)
        {
            List<Product> productsPage = new List<Product>(from product in products
                                                           select product).Skip(numberOfProductsOnPage * (numberOfPage - 1)).Take(numberOfProductsOnPage).ToList();
            return productsPage;
        }

        public static List<Product> GetProductsPageImperative(this List<Product> products, int numberOfProductsOnPage, int numberOfPage)
        {
            List<Product> productsPage = new List<Product>(products.Skip(numberOfProductsOnPage * (numberOfPage - 1)).Take(numberOfProductsOnPage));
            return productsPage;
        }

        public static string GetProductVendorPairsDeclarative(this List<Product> products, List<ProductVendor> vendors)
        {
            var resultOfQuery = (from product in products
                                 from vendor in vendors
                                 where vendor.ProductID.Equals(product.ProductID)
                                 select product.Name + " - " + vendor.Vendor.Name).ToList();

            string result = "";

            foreach (var singleLine in resultOfQuery)
            {
                result += singleLine + Environment.NewLine;
            }

            return result;
        }

        public static string GetProductVendorPairsImperative(this List<Product> products, List<ProductVendor> vendors)
        {
            var resultOfQuery = products.Join(vendors,
                        singleProduct => singleProduct.ProductID,
                        singleVendor => singleVendor.ProductID,
                        (singleProduct, singleVendor) => singleProduct.Name + " - " + singleVendor.Vendor.Name).ToList();

            string result = "";

            foreach (var singleLine in resultOfQuery)
            {
                result += singleLine + Environment.NewLine;
            }

            return result;
        }
    }
}
