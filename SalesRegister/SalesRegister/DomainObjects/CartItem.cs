using System;

namespace SalesRegister.DomainObjects
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalGst { get; set; }
        public decimal TotalPst { get; set; }
        public decimal TotalTax { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
