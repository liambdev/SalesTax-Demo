using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesTax.Code
{
    public class GlobalMethods
    {
        public static int basicTaxPerc = 10;
        public static int importTaxPerc = 5;

        internal static List<KeyValuePair<bool, string>> GetProdTypes()
        {
            List<KeyValuePair<bool, string>> prodTypes = new List<KeyValuePair<bool, string>>();

            // Retrieve product types
            prodTypes.Add(new KeyValuePair<bool, string>(true, "Other"));
            prodTypes.Add(new KeyValuePair<bool, string>(false, "Books"));
            prodTypes.Add(new KeyValuePair<bool, string>(false, "Food"));
            prodTypes.Add(new KeyValuePair<bool, string>(false, "Medicine"));

            return prodTypes;
        }
    }
}