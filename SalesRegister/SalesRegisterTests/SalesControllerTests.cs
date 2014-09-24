using System;

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
            const string barcode = "12345";

            var display = new Mock<IDisplay>();
            display.Setup(m => m.SetPrice(It.Is<decimal>(p => p == price)))
                .Callback(() => display.Setup(m => m.DisplayText).Returns(price.ToString("C")));

            var catalog = new Mock<ICatalog>();
            catalog.Setup(c => c.GetPrice(It.Is<string>(s => s.Equals(barcode))))
                .Returns(price);

            var scanner = new Mock<IScanner>();
            
            new SalesController(catalog.Object, display.Object, scanner.Object);
            
            scanner.Raise(s => s.BarcodeScanned += null, new BarcodeScannedEventArgs{Barcode = barcode});
            
            Assert.AreEqual(price.ToString("C"), display.Object.DisplayText);

            Console.WriteLine(display.Object.DisplayText);
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

            var scanner = new Mock<IScanner>();

            new SalesController(catalog.Object, display.Object, scanner.Object);

            scanner.Raise(s => s.BarcodeScanned += null, new BarcodeScannedEventArgs { Barcode = barcode });
            
            Assert.AreEqual("Product not found for " + barcode, display.Object.DisplayText);

            Console.WriteLine(display.Object.DisplayText);
        }

        [Test]
        public void GetItemPrice_ShouldReturnEmptyBarcodeMessage()
        {
            var display = new Mock<IDisplay>();
            display.Setup(m => m.SetEmptyBarcodeMessage())
                .Callback(() => display.SetupGet(m => m.DisplayText).Returns("Scanning error: empty barcode"));
            
            var catalog = new Mock<ICatalog>();
            var scanner = new Mock<IScanner>();
            
            new SalesController(catalog.Object, display.Object, scanner.Object);

            scanner.Raise(s => s.BarcodeScanned += null, new BarcodeScannedEventArgs { Barcode = string.Empty });

            Assert.AreEqual("Scanning error: empty barcode", display.Object.DisplayText);

            Console.WriteLine(display.Object.DisplayText);
        }
    }
}
