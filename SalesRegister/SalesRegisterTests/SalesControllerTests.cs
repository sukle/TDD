using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalesRegister;

namespace SalesRegisterTests
{
    [TestFixture]
    internal class SalesControllerTests
    {
        [Test]
        public void GetItemPrice_ShouldFindProduct()
        {
            IDisplay display = new Display();
            ICatalog catalog = new Catalog(new Dictionary<string, decimal?>
            {
                {"12345", 24.50m}
            });
            ISalesController salesController = new SalesController(catalog, display);

            salesController.RunBarcode("12345");

            Assert.AreEqual("24.50 Lt", display.GetDisplayText());
        }

        [Test]
        public void GetItemPrice_ShouldNotFindProduct()
        {
            IDisplay display = new Display();
            ICatalog catalog = new Catalog(new Dictionary<string, decimal?>
            {
                {"anything except 99999", null}
            });
            ISalesController salesController = new SalesController(catalog, display);

            salesController.RunBarcode("99999");

            Assert.AreEqual("Product not found for 99999", display.GetDisplayText());
        }

        [Test]
        public void GetItemPrice_ShouldReturnEmptyBarcodeMessage()
        {

            IDisplay display = new Display();
            ICatalog catalog = new Catalog(null);
            ISalesController salesController = new SalesController(catalog, display);

            salesController.RunBarcode("");

            Assert.AreEqual("Scanning error: empty barcode", display.GetDisplayText());
        }
    }
}
