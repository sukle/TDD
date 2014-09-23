using System;

namespace SalesRegister
{
    public interface ISales
    {
        string GetItemPrice(string barcode);
    }
}
