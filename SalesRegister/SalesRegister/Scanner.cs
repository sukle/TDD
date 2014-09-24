using System;

namespace SalesRegister
{
    public interface IScanner
    {
        event EventHandler BarcodeScanned;
    }

    public class BarcodeScannedEventArgs : EventArgs
    {
        public string Barcode { get; set; }
    }

    public class Scanner : IScanner
    {
        public event EventHandler BarcodeScanned;
       
        public void ScanBarcode(string barcode)
        {
            OnBarcodeScanned(new BarcodeScannedEventArgs {Barcode = barcode});
        }

        protected virtual void OnBarcodeScanned(BarcodeScannedEventArgs e)
        {
            if (BarcodeScanned != null)
            {
                BarcodeScanned(this, e);
            }
        }
    }
}
