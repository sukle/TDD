using System;
using System.Collections.Generic;

namespace SalesRegister
{
    public abstract class ScannerBase
    {
        protected Dictionary<string, double> Prices { get; private set; }

        protected ScannerBase()
        {
            Prices = new Dictionary<string, double>();
            PopulatePrices();
        }

        private void PopulatePrices()
        {
            Prices.Add("12345", 24.50);
        }
    }
}
