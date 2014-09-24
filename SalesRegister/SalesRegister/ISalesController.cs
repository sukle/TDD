using System;

namespace SalesRegister
{
    public interface ISalesController
    {
        void StartTransaction();
        void RunBarcode(string barcode);
        void EndTransaction();
    }
}
