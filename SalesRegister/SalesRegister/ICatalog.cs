using System;

namespace SalesRegister
{
    public interface ICatalog
    {
        decimal? GetPrice(string barcode);
    }
}
