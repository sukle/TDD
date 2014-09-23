using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalesRegister;

namespace SalesRegisterTests
{
    [TestFixture]
    internal class Tests
    {
        [Test]
        public void Sales_GetItemPrice_ShouldFindProduct()
        {
            IDisplay display = new Display();
            ICatalog catalog = new Catalog(new Dictionary<string, string>
            {
                {"12345", "24.50 Lt"}
            });
            ISales sales = new Sales(catalog, display);

            sales.GetItemPrice("12345");

            Assert.AreEqual("24.50 Lt", display.DisplayText());
        }

        [Test]
        public void Sales_GetItemPrice_ShouldNotProduct()
        {
            IDisplay display = new Display();
            ICatalog catalog = new Catalog(new Dictionary<string, string>
            {
                {"anything except 99999", "irrelevant price"}
            });
            ISales sales = new Sales(catalog, display);

            sales.GetItemPrice("99999");

            Assert.AreEqual("Product not found for 99999", display.DisplayText());
        }

        [Test]
        public void Sales_GetItemPrice_ShouldReturnEmptyBarcodeMessage()
        {

            IDisplay display = new Display();
            ICatalog catalog = new Catalog(null);
            ISales sales = new Sales(catalog, display);

            sales.GetItemPrice("");

            Assert.AreEqual("Scanning error: empty barcode", display.DisplayText());
        }
    }
}
