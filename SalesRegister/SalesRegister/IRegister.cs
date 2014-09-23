using System;

namespace SalesRegister
{
    public interface IRegister
    {
        string GetItemPrice(string barcode);
    }
}
