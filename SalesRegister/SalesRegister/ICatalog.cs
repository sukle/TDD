using System;

namespace SalesRegister
{
    public interface ICatalog
    {
        string FindPrice(string barcode);
    }
}
