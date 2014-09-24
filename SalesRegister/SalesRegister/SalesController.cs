using System;

namespace SalesRegister
{
    public interface ISalesController
    {
        void RunBarcode(string barcode);
    }

    public class SalesController :  ISalesController
    {
        private readonly ICatalog catalog;
        private readonly IDisplay display;

        public SalesController(ICatalog catalog, IDisplay display, IScanner scanner)
        {
            this.catalog = catalog;
            this.display = display;

            scanner.BarcodeScanned += scanner_BarcodeScanned;
        }

        void scanner_BarcodeScanned(object sender, EventArgs e)
        {
            var scannerEventArts = e as BarcodeScannedEventArgs;
            if (scannerEventArts != null)
            {
                RunBarcode(scannerEventArts.Barcode);
            }
        }

        public void RunBarcode(string barcode)
        {
            if (barcode.Equals(string.Empty))
            {
                display.SetEmptyBarcodeMessage();
                return;
            }
            
            var price = catalog.GetPrice(barcode);
            if (price == null) 
            {
                display.SetProductNotFoundMessage(barcode);
            } 
            else 
            {
                display.SetPrice(price.Value);
            }
        }
    }
}
