using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesTax.Models
{
    public class Product
    {
        public string productDescription { get; set; }
        public decimal taxValue { get; set; }
        public decimal preTax { get; set; }
        public decimal postTax { get { return (this.preTax + this.taxValue); } }
        public bool basicTax { get; set; }
        public bool importTax { get; set; }
    }
}