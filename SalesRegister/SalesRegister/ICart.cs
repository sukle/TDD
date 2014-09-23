using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
