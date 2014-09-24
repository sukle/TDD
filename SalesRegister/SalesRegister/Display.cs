using System;

namespace SalesRegister
{
    public interface IDisplay
    {
        string DisplayText { get; }
        void SetPrice(decimal price);
        void SetEmptyBarcodeMessage();
        void SetProductNotFoundMessage(string barcode);
    }

    public class Display : IDisplay
    {
        public string DisplayText { get; private set; }

        public void SetPrice(decimal price)
        {
            DisplayText = price.ToString("C");
        }

        public void SetEmptyBarcodeMessage()
        {
            DisplayText = "Scanning error: empty barcode";
        }

        public void SetProductNotFoundMessage(string barcode)
        {
            DisplayText = "Product not found for " + barcode;
        }

        public void ClearDisplayText()
        {
            DisplayText = string.Empty;
        }
    }
}
