using System;

using SalesRegister.DomainObjects;

namespace SalesRegister
{
    public interface ICart
    {
        void AddProduct(Product product, int count, DateTime date);
        
        decimal GetTotalPriceWithTax();
        decimal GetTotalPriceWithoutTax();
        decimal GetTotalTax();
    }

    public class Cart : ICart
    {
        public void AddProduct(Product product, int count, DateTime date)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPriceWithTax()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPriceWithoutTax()
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalTax()
        {
            throw new NotImplementedException();
        }
    }
}
