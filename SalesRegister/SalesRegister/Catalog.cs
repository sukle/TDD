using System;
using System.Collections.Generic;

namespace SalesRegister
{
    public interface ICatalog
    {
        decimal? GetPrice(string barcode);
    }

    public class Catalog : ICatalog
    {
        private readonly Dictionary<string, decimal?> pricesByBarcode;

        public Catalog(Dictionary<string, decimal?> pricesByBarcode)
        {
            this.pricesByBarcode = pricesByBarcode;
        }

        public decimal? GetPrice(string barcode)
        {
            return pricesByBarcode.ContainsKey(barcode)
                ? pricesByBarcode[barcode]
                : null;
        }
    }
}
