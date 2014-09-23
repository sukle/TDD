using System;

namespace SalesRegister
{
    public class Register :  RegisterBase, IRegister
    {
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
