using System;

namespace SalesRegister
{
    public interface IDisplay
    {
        string GetDisplayText();
        void SetPrice(decimal price);
        void SetEmptyBarcodeMessage();
        void SetProductNotFoundMessage(string barcode);
        void ClearDisplayText();
    }
}
