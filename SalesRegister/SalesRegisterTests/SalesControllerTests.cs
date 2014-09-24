using System;
using System.Collections.Generic;
using Moq;
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
            const decimal price = 24.50m;

            var display = new Mock<IDisplay>();
            display.Setup(m => m.SetPrice(It.Is<decimal>(p => p == price)))
                .Callback(() => display.Setup(m => m.DisplayText).Returns(price.ToString("C")));

            var catalog = new Mock<ICatalog>();
            catalog.Setup(c => c.GetPrice(It.Is<string>(s => s.Equals("12345"))))
                .Returns(price);
            
            ISalesController salesController = new SalesController(catalog.Object, display.Object);
            salesController.RunBarcode("12345");

            Assert.AreEqual("24.50 Lt", display.Object.DisplayText);
        }

        [Test]
        public void GetItemPrice_ShouldNotFindProduct()
        {
            const string barcode = "99999";

            var display = new Mock<IDisplay>();
            display.Setup(m => m.SetProductNotFoundMessage(It.Is<string>(s => s == barcode)))
                .Callback(() => display.SetupGet(m => m.DisplayText).Returns("Product not found for " + barcode));

            var catalog = new Mock<ICatalog>();
            catalog.Setup(m => m.GetPrice(barcode)).Returns((decimal?)null);

            ISalesController salesController = new SalesController(catalog.Object, display.Object);

            salesController.RunBarcode(barcode);

            Assert.AreEqual("Product not found for " + barcode, display.Object.DisplayText);
        }

        [Test]
        public void GetItemPrice_ShouldReturnEmptyBarcodeMessage()
        {
            var display = new Mock<IDisplay>();
            display.Setup(m => m.SetEmptyBarcodeMessage())
                .Callback(() => display.SetupGet(m => m.DisplayText).Returns("Scanning error: empty barcode"));
            
            var catalog = new Mock<ICatalog>();
            
            ISalesController salesController = new SalesController(catalog.Object, display.Object);

            salesController.RunBarcode("");

            Assert.AreEqual("Scanning error: empty barcode", display.Object.DisplayText);
        }
    }
}
