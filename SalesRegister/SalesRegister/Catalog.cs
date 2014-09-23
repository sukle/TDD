using System;
using System.Collections.Generic;

namespace SalesRegister
{
    public class Catalog : ICatalog
    {
        private readonly Dictionary<string, string> pricesByBarcode;

        public Catalog(Dictionary<string, string> pricesByBarcode)
        {
            this.pricesByBarcode = pricesByBarcode;
        }

        public string FindPrice(string barcode)
        {
            return pricesByBarcode.ContainsKey(barcode)
                ? pricesByBarcode[barcode]
                : null;
        }
    }
}
