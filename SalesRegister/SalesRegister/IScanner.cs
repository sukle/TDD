using System;

namespace SalesRegister
{
    public interface IScanner
    {
        event EventHandler BarcodeScanned;
    }
}
