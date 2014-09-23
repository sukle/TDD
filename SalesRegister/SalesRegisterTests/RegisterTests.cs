using System;

using NUnit.Framework;
using SalesRegister;

namespace SalesRegisterTests
{
    [TestFixture]
    internal class RegisterTests : TestBase
    {
        [Test]
        public void GetItemPrice_ShouldGetPrice()
        {
            const string barcode = "12345";
            var expectedPrice = RegisterDataProvider.GetItemPrice(barcode);

            IRegister register = new Register();
            var price = register.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldNotFindProductOnGoodBarcode()
        {
            const string barcode = "99999";
            var expectedPrice = RegisterDataProvider.GetItemPrice(barcode);

            IRegister register = new Register();
            var price = register.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldNotFindProductOnGarbaggeCharacters()
        {
            const string barcode = "xx9x98spjd9w8d98";
            var expectedPrice = RegisterDataProvider.GetItemPrice(barcode);

            IRegister register = new Register();
            var price = register.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }

        [Test]
        public void GetItemPrice_ShouldShowScannerErrorOnEmptyBarcode()
        {
            var barcode = string.Empty;
            var expectedPrice = RegisterDataProvider.GetItemPrice(barcode);

            IRegister register = new Register();
            var price = register.GetItemPrice(barcode);
            Assert.AreEqual(price, expectedPrice);
        }
    }
}
