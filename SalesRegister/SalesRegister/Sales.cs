using System;

namespace SalesRegister
{
    public class Sales :  ISales
    {
        private readonly ICatalog catalog;
        private readonly IDisplay display;
        
        public Sales(ICatalog catalog, IDisplay display)
        {
            this.catalog = catalog;
            this.display = display;
        }

        public void GetItemPrice(string barcode)
        {
            if (barcode.Equals(string.Empty))
            {
                display.SetEmptyBarcodeMessage();
                return;
            }
            
            var price = catalog.FindPrice(barcode);
            if (price == null) 
            {
                display.SetProductNotFoundMessage(barcode);
            } 
            else 
            {
                display.SetPrice(price);
            }
        }
    }
}
