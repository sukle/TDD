using System;

namespace SalesRegister
{
    public interface ISales
    {
        void StartTransaction();
        void RunBarcode(string barcode);
        void EndTransaction();
    }
}
