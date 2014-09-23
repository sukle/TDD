using System;

namespace SalesRegister
{
    public class Scanner :  ScannerBase, IScanner
    {
        private const string PRICE_NOT_FOUND = "Price not found for {0}";
        private const string EMPTY_BARCODE = "Scanner error: empty barcode";

        public string GetItemPrice(string barcode)
        {
            string result;
            
            if (string.IsNullOrEmpty(barcode))
            {
                result = EMPTY_BARCODE;
            } 
            else if (Prices.ContainsKey(barcode))
            {
                result = Prices[barcode].ToString("C");
            }
            else
            {
                result = string.Format(PRICE_NOT_FOUND, barcode);
            }

            return result;
        }
    }
}
