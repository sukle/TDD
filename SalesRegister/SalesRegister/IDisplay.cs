using System;

namespace SalesRegister
{
    public interface IDisplay
    {
        string GetDisplayText();
        void SetPrice(string price);
        void SetEmptyBarcodeMessage();
        void SetProductNotFoundMessage(string barcode);
        void ClearDisplayText();
    }
}
