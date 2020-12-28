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

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            int totalStandardCost = (int)(from product in MyProductDataContext.MyProductsList
                                          where product.ProductSubcategory != null && product.ProductSubcategory.ProductCategory.Name == category.Name
                                          select product.StandardCost).Sum();
            return totalStandardCost;
        }
    }
}
