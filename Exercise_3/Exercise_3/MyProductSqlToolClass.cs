using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class MyProductSqlToolClass
    {
        public static List<MyProduct> GetMyProductsByName(string namePart)
        {
            List<MyProduct> productsList = new List<MyProduct>(from product in MyProductDataContext.MyProductsList
                                                               where product.Name.Contains(namePart)
                                                               select product);
            return productsList;
        }

        public static List<MyProduct> GetMyProductsWithNRecentReviews(int howManyReviews)
        {
            List<MyProduct> productsList = new List<MyProduct>(from product in MyProductDataContext.MyProductsList
                                                               where product.ProductReviews.Count == howManyReviews
                                                               select product);
            return productsList;
        }

        public static List<MyProduct> GetNMyProductsFromCategory(string categoryName, int n)
        {
            List<MyProduct> productsList = new List<MyProduct>((from product in MyProductDataContext.MyProductsList
                                                            where product.ProductSubcategory.ProductCategory.Name == categoryName
                                                            orderby product.Name
                                                            select product).Take(n));
            return productsList;
        }
    }
}
