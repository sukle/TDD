using System;
using System.Collections.Generic;

namespace SalesRegister
{
    public abstract class RegisterBase
    {
        protected Dictionary<string, double> Prices { get; private set; }

        protected RegisterBase()
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
