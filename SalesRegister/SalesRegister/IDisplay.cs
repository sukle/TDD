using System;

namespace SalesRegister
{
    public interface IDisplay
    {
        string DisplayText();
        void SetPrice(string price);
        void SetEmptyBarcodeMessage();
        void SetProductNotFoundMessage(string barcode);
    }
}
