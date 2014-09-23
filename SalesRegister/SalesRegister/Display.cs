using System;

namespace SalesRegister
{
    public class Display : IDisplay
    {
        private string text;
        
        public string DisplayText()
        {
            return text;
        }

        public void SetPrice(string price)
        {
            text = price;
        }

        public void SetEmptyBarcodeMessage()
        {
            text = "Scanning error: empty barcode";
        }

        public void SetProductNotFoundMessage(string barcode)
        {
            text = "Product not found for " + barcode;
        }
    }
}
