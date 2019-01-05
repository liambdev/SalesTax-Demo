using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesTax.Code;

namespace SalesTax.Models
{
    public class Receipt
    {
        public List<Product> products { get; set; } = new List<Product>();
        public decimal totalTax { get { return (this.products.Sum(p => p.taxValue)); } }
        public decimal grandTotal { get { return (this.products.Sum(p => p.postTax)); } }

        public void AddProduct(Product prod)
        {
            decimal importTax = 0;
            decimal basicTax = 0;

            // if product is eligable for basic tax, work out how much needs adding
            if (prod.basicTax)
                basicTax = CalcTax((prod.preTax), GlobalMethods.basicTaxPerc);

            // if product is eligable for import tax, work out how much needs adding
            if (prod.importTax)
                importTax = CalcTax(prod.preTax, GlobalMethods.importTaxPerc);

            // Add the value of tax for this product
            prod.taxValue = importTax + basicTax;

            // Add the product to this receipt now everything has been calculated
            this.products.Add(prod);
        }

        /// <summary>
        /// Method to calculate tax to add
        /// </summary>
        /// <param name="prodTotal">Total value of goods</param>
        /// <param name="tax">Percentage of tax added to goods total</param>
        /// <returns>Return the value of the tax that requires adding</returns>
        private decimal CalcTax(decimal prodTotal, int tax)
        {

            decimal percToDecimal = ((decimal)tax / (decimal)100) + 1;
            // Divide final amount by the decimal value of tax added
            decimal postTaxVal = prodTotal * percToDecimal;
            // work out the difference to get the amount that has been added
            decimal taxVal = postTaxVal - prodTotal;

            // round to the nearest 0.05
            //taxVal = Math.Round(taxVal * (decimal)20) / (decimal)20;

            // round UP to the nearest 0.05
            taxVal = Math.Ceiling(taxVal * (decimal)20) / (decimal)20;

            return taxVal;
        }
    }
}