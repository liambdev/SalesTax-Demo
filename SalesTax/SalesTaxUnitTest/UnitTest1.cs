using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTax.Models;
using SalesTax.Code;

namespace SalesTaxUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Input1Tax()
        {
            Receipt receipt = new Receipt();

            Product prod1 = new Product();
            prod1.productDescription = "Book";
            prod1.preTax = 12.49M;
            prod1.basicTax = false;
            prod1.importTax = false;

            Product prod2 = new Product();
            prod2.productDescription = "Music CD";
            prod2.preTax = 14.99M;
            prod2.basicTax = true;
            prod2.importTax = false;

            Product prod3 = new Product();
            prod3.productDescription = "Chocolate Bar";
            prod3.preTax = 0.85M;
            prod3.basicTax = false;
            prod3.importTax = false;

            receipt.AddProduct(prod1);
            receipt.AddProduct(prod2);
            receipt.AddProduct(prod3);

            Assert.AreEqual(receipt.totalTax, (decimal)1.50);
        }

        [TestMethod]
        public void Input1Total()
        {
            Receipt receipt = new Receipt();

            Product prod1 = new Product();
            prod1.productDescription = "Book";
            prod1.preTax = 12.49M;
            prod1.basicTax = false;
            prod1.importTax = false;

            Product prod2 = new Product();
            prod2.productDescription = "Music CD";
            prod2.preTax = 14.99M;
            prod2.basicTax = true;
            prod2.importTax = false;

            Product prod3 = new Product();
            prod3.productDescription = "Chocolate Bar";
            prod3.preTax = 0.85M;
            prod3.basicTax = false;
            prod3.importTax = false;

            receipt.AddProduct(prod1);
            receipt.AddProduct(prod2);
            receipt.AddProduct(prod3);

            Assert.AreEqual(receipt.grandTotal, (decimal)29.83);
        }

        [TestMethod]
        public void Input2Tax()
        {
            Receipt receipt = new Receipt();

            Product prod1 = new Product();
            prod1.productDescription = "Imported box of chocolates";
            prod1.preTax = 10.00M;
            prod1.basicTax = false;
            prod1.importTax = true;

            Product prod2 = new Product();
            prod2.productDescription = "Imported bottle of perfume";
            prod2.preTax = 47.50M;
            prod2.basicTax = true;
            prod2.importTax = true;

            receipt.AddProduct(prod1);
            receipt.AddProduct(prod2);

            Assert.AreEqual(receipt.totalTax, (decimal)7.65);
        }

        [TestMethod]
        public void Input2Total()
        {
            Receipt receipt = new Receipt();

            Product prod1 = new Product();
            prod1.productDescription = "Imported box of chocolates";
            prod1.preTax = 10.00M;
            prod1.basicTax = false;
            prod1.importTax = true;

            Product prod2 = new Product();
            prod2.productDescription = "Imported bottle of perfume";
            prod2.preTax = 47.50M;
            prod2.basicTax = true;
            prod2.importTax = true;

            receipt.AddProduct(prod1);
            receipt.AddProduct(prod2);

            Assert.AreEqual(receipt.grandTotal, (decimal)65.15);
        }

        [TestMethod]
        public void Input3Tax()
        {
            Receipt receipt = new Receipt();

            Product prod1 = new Product();
            prod1.productDescription = "Imported bottle of perfume";
            prod1.preTax = 27.99M;
            prod1.basicTax = true;
            prod1.importTax = true;

            Product prod2 = new Product();
            prod2.productDescription = "Bottle of perfume";
            prod2.preTax = 18.99M;
            prod2.basicTax = true;
            prod2.importTax = false;

            Product prod3 = new Product();
            prod3.productDescription = "Packet of paracetemol";
            prod3.preTax = 9.75M;
            prod3.basicTax = false;
            prod3.importTax = false;

            Product prod4 = new Product();
            prod4.productDescription = "Box of imported chocolates";
            prod4.preTax = 11.25M;
            prod4.basicTax = false;
            prod4.importTax = true;

            receipt.AddProduct(prod1);
            receipt.AddProduct(prod2);
            receipt.AddProduct(prod3);
            receipt.AddProduct(prod4);

            Assert.AreEqual(receipt.totalTax, (decimal)6.70);
        }

        [TestMethod]
        public void Input3Total()
        {
            Receipt receipt = new Receipt();

            Product prod1 = new Product();
            prod1.productDescription = "Imported bottle of perfume";
            prod1.preTax = 27.99M;
            prod1.basicTax = true;
            prod1.importTax = true;

            Product prod2 = new Product();
            prod2.productDescription = "Bottle of perfume";
            prod2.preTax = 18.99M;
            prod2.basicTax = true;
            prod2.importTax = false;

            Product prod3 = new Product();
            prod3.productDescription = "Packet of paracetemol";
            prod3.preTax = 9.75M;
            prod3.basicTax = false;
            prod3.importTax = false;

            Product prod4 = new Product();
            prod4.productDescription = "Box of imported chocolates";
            prod4.preTax = 11.25M;
            prod4.basicTax = false;
            prod4.importTax = true;

            receipt.AddProduct(prod1);
            receipt.AddProduct(prod2);
            receipt.AddProduct(prod3);
            receipt.AddProduct(prod4);

            Assert.AreEqual(receipt.grandTotal, (decimal)74.68);
        }
    }
}
