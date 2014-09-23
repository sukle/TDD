using System;
using System.Collections.Generic;

using SalesRegister;

namespace SalesRegisterTests
{
    internal class FakeRegisterDataProvider : IRegister
    {
        private const string PRICE_NOT_FOUND = "Price not found for {0}";

        private Dictionary<string, string> prices;

        public FakeRegisterDataProvider()
        {
            PopulatePrices();
        }

        private void PopulatePrices()
        {
            prices = new Dictionary<string, string>
            {
                {"12345", (24.50).ToString("C")},
                {"", "Scanning error: empty barcode"}
            };
        }

        public string GetItemPrice(string barcode)
        {
            return prices.ContainsKey(barcode) ? prices[barcode] : string.Format(PRICE_NOT_FOUND, barcode);
        }
    }
}
