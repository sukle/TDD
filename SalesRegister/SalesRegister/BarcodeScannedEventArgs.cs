using System;

namespace SalesRegister
{
    public class BarcodeScannedEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }
}