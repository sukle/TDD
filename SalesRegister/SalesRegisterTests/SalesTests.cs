using System;

using NUnit.Framework;
using SalesRegister;

namespace SalesRegisterTests
{
    [TestFixture]
    internal class SalesTests : TestBase
    {
        [Test]
        public void GetItemPrice_ShouldGetPriceFor12345()
        {
            const string barcode = "12345";
            var expectedPrice = SalesDataProvider.GetItemPrice(barcode);

            ISales sales = new Sales();
            var price = sales.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldGetPriceFor23456()
        {
            const string barcode = "23456";
            var expectedPrice = SalesDataProvider.GetItemPrice(barcode);

            ISales sales = new Sales();
            var price = sales.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldNotFindProductOnGoodBarcode()
        {
            const string barcode = "99999";
            var expectedPrice = SalesDataProvider.GetItemPrice(barcode);

            ISales sales = new Sales();
            var price = sales.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldNotFindProductOnGarbaggeCharacters()
        {
            const string barcode = "xx9x98spjd9w8d98";
            var expectedPrice = SalesDataProvider.GetItemPrice(barcode);

            ISales sales = new Sales();
            var price = sales.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldShowScannerErrorOnEmptyBarcode()
        {
            var barcode = string.Empty;
            var expectedPrice = SalesDataProvider.GetItemPrice(barcode);

            ISales sales = new Sales();
            var price = sales.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }
    }
}
