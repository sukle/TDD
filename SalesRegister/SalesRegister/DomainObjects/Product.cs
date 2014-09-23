using System;

namespace SalesRegister.DomainObjects
{
    public class Product
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsGstApplied { get; set; }
        public bool IsPstApplied { get; set; }
    }
}
