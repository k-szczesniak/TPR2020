using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class MyProductDataContext
    {
        public static List<MyProduct> MyProductsList { get; private set; }

        public MyProductDataContext(ProductionDataContext myDataContext)
        {
            MyProductsList = myDataContext.Products.AsEnumerable().Select(product => new MyProduct(product)).ToList();
        }
    }
}
    