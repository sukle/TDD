using System;
using System.Collections.Generic;

namespace SalesRegister
{
    public abstract class RegisterBase
    {
        protected const string PRICE_NOT_FOUND = "Price not found for {0}";
        protected const string EMPTY_BARCODE = "Scanning error: empty barcode";
        
        protected Dictionary<string, double> Prices { get; private set; }

        protected RegisterBase()
        {
            Prices = new Dictionary<string, double>();
            PopulatePrices();
        }

        private void PopulatePrices()
        {
            Prices.Add("12345", 24.50);
            Prices.Add("23456", 39);
        }
    }
}
