using System;

namespace SalesRegister
{
    public interface IScanner
    {
        string GetItemPrice(string barcode);
    }
}
